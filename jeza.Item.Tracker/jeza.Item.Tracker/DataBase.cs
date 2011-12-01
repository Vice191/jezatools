using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SQLite;
using System.IO;
using System.Linq;
using NLog;

namespace jeza.Item.Tracker
{
    public class DataBase
    {
        private static readonly Logger Log = LogManager.GetCurrentClassLogger();
        private readonly SQLiteConnection sqLiteConnection = new SQLiteConnection();

        public DataBase()
        {
            sqLiteConnection = new SQLiteConnection(Config.DataSource);
        }

        public DataTable GetDataTable(string commandText)
        {
            Log.Debug("GetDataTable: '{0}'", commandText);
            DataTable dt = new DataTable();
            try
            {
                using (sqLiteConnection)
                {
                    sqLiteConnection.Open();
                    SQLiteCommand mycommand = new SQLiteCommand(sqLiteConnection) {CommandText = commandText};
                    SQLiteDataReader reader = mycommand.ExecuteReader();
                    dt.Load(reader);
                    reader.Close();
                    sqLiteConnection.Close();
                }
            }
            catch (Exception exception)
            {
                Log.Error(exception.ToString());
            }

            return dt;
        }

        public int ExecuteNonQuery(string commandText)
        {
            Log.Debug("ExecuteNonQuery: '{0}'", commandText);
            try
            {
                using (sqLiteConnection)
                {
                    sqLiteConnection.Open();
                    SQLiteCommand mycommand = new SQLiteCommand(sqLiteConnection) {CommandText = commandText};
                    int rowsUpdated = mycommand.ExecuteNonQuery();
                    sqLiteConnection.Close();
                    return rowsUpdated;
                }
            }
            catch (Exception exception)
            {
                Log.Error(exception.ToString);
                return 0;
            }
        }

        public string ExecuteScalar(string commandText)
        {
            Log.Debug("ExecuteScalar: '{0}'", commandText);
            try
            {
                using (sqLiteConnection)
                {
                    sqLiteConnection.Open();
                    SQLiteCommand mycommand = new SQLiteCommand(sqLiteConnection) {CommandText = commandText};
                    object value = mycommand.ExecuteScalar();
                    sqLiteConnection.Close();
                    return value != null ? value.ToString() : "";
                }
            }
            catch (Exception exception)
            {
                Log.Error(exception.ToString);
                return String.Empty;
            }
        }

        public int ItemDelete(int itemId)
        {
            string commandText = String.Format(@"DELETE FROM Item WHERE Id = {0}", itemId);
            return ExecuteNonQuery(commandText);
        }

        public Item ItemGet(string itemName)
        {
            string commandText =
                String.Format(@"SELECT Id, Name, Description, ItemType, Image FROM Item WHERE Name = '{0}'", itemName);
            return ItemSelect(commandText);
        }

        public Item ItemGet(int itemId)
        {
            string commandText = @"SELECT Id, Name, Description, ItemType, Image FROM Item WHERE Id = " + itemId;
            return ItemSelect(commandText);
        }

        public List<Item> ItemGetAll()
        {
            const string commandText = @"SELECT Id, Name, Description, ItemType, Image FROM Item";
            Log.Debug("ItemGetAll");
            List<Item> items = new List<Item>();
            try
            {
                using (sqLiteConnection)
                {
                    sqLiteConnection.Open();
                    SQLiteCommand mycommand = new SQLiteCommand(sqLiteConnection) {CommandText = commandText};
                    SQLiteDataReader reader = mycommand.ExecuteReader(CommandBehavior.SequentialAccess);
                    while (reader.Read())
                    {
                        int id = reader.GetInt32(0);
                        string name = reader.GetString(1);
                        string description = reader.GetString(2);
                        int itemTypeId = reader.GetInt32(3);
                        byte[] bytes = GetBytes(reader);
                        Item item = new Item
                                    {
                                        Id = id,
                                        Name = name,
                                        Description = description,
                                        ItemTypeId = itemTypeId,
                                        Image = bytes
                                    };
                        items.Add(item);
                        Log.Debug("FoundItem: {0}", item.FormatItem());
                    }
                    reader.Close();
                    sqLiteConnection.Close();
                }
            }
            catch (Exception exception)
            {
                Log.Error(exception.ToString());
            }
            return items;
        }

        public int ItemInsert(Item item)
        {
            try
            {
                const string commandText =
                    @"INSERT INTO Item (Name, Description, ItemType, Image) VALUES(@name, @description, @itemType, @image)";
                Log.Debug("ItemInsert: [{0}], Item={1}", commandText, item.FormatItem());
                using (sqLiteConnection)
                {
                    using (SQLiteCommand sqLiteCommand = new SQLiteCommand(commandText, sqLiteConnection))
                    {
                        sqLiteConnection.Open();
                        sqLiteCommand.Parameters.AddWithValue("@name", item.Name);
                        sqLiteCommand.Parameters.AddWithValue("@description", item.Description);
                        sqLiteCommand.Parameters.AddWithValue("@itemType", item.ItemTypeId);
                        sqLiteCommand.Parameters.AddWithValue("@image", item.Image);
                        int rowsUpdated = sqLiteCommand.ExecuteNonQuery();
                        sqLiteConnection.Close();
                        return rowsUpdated;
                    }
                }
            }
            catch (Exception exception)
            {
                Log.Error(exception.ToString);
                return 0;
            }
        }

        private Item ItemSelect(string commandText)
        {
            Log.Info("ItemSelect: [{0}]", commandText);
            try
            {
                using (sqLiteConnection)
                {
                    sqLiteConnection.Open();
                    SQLiteCommand mycommand = new SQLiteCommand(sqLiteConnection) {CommandText = commandText};
                    SQLiteDataReader reader = mycommand.ExecuteReader(CommandBehavior.SequentialAccess);
                    while (reader.Read())
                    {
                        int id = reader.GetInt32(0);
                        string name = reader.GetString(1);
                        string description = reader.GetString(2);
                        int itemTypeId = reader.GetInt32(3);
                        byte[] bytes = GetBytes(reader);
                        Item item = new Item
                                    {
                                        Id = id,
                                        Name = name,
                                        Description = description,
                                        ItemTypeId = itemTypeId,
                                        Image = bytes
                                    };
                        Log.Debug("FoundItem: {0}", item.FormatItem());
                        return item;
                    }
                    reader.Close();
                    sqLiteConnection.Close();
                }
            }
            catch (Exception exception)
            {
                Log.Error(exception.ToString());
            }
            return null;
        }

        public int ItemStatusDelete(int itemStatusId)
        {
            string commandText = String.Format(@"DELETE FROM ItemStatus WHERE Id = {0}", itemStatusId);
            return ExecuteNonQuery(commandText);
        }

        public ItemStatus ItemStatusGet(int itemStatusId)
        {
            string commandText = @"SELECT Id, Name, Description FROM ItemStatus WHERE Id = " + itemStatusId;
            Log.Info("ItemStatusGet: [{0}]", commandText);
            return ItemStatusSelect(commandText);
        }

        public ItemStatus ItemStatusGet(string itemStatusName)
        {
            string commandText = String.Format(@"SELECT Id, Name, Description FROM ItemStatus WHERE Name = '{0}'",
                                               itemStatusName);
            Log.Info("ItemStatusGet: [{0}]", commandText);
            return ItemStatusSelect(commandText);
        }

        public List<ItemStatus> ItemStatusGetAll()
        {
            DataTable dataTable = GetDataTable(@"SELECT Id, Name, Description FROM ItemStatus");
            DataRowCollection dataRowCollection = dataTable.Rows;
            if (dataRowCollection.Count > 0)
            {
                return (from DataRow dataRow in dataRowCollection
                        select dataRow.ItemArray
                        into itemArray
                        select new ItemStatus
                               {
                                   Id = Misc.String2Number(itemArray[0].ToString()),
                                   Name = itemArray[1].ToString(),
                                   Description = itemArray[2].ToString(),
                               }).ToList();
            }
            return null;
        }

        public int ItemStatusInsert(ItemStatus itemStatus)
        {
            string insertCommand = String.Format(@"INSERT INTO ItemStatus (Name, Description) VALUES('{0}', '{1}')",
                                                 itemStatus.Name, itemStatus.Description);
            return ExecuteNonQuery(insertCommand);
        }

        private ItemStatus ItemStatusSelect(string commandText)
        {
            try
            {
                using (sqLiteConnection)
                {
                    sqLiteConnection.Open();
                    SQLiteCommand mycommand = new SQLiteCommand(sqLiteConnection) {CommandText = commandText};
                    SQLiteDataReader reader = mycommand.ExecuteReader(CommandBehavior.SequentialAccess);
                    while (reader.Read())
                    {
                        int id = reader.GetInt32(0);
                        string name = reader.GetString(1);
                        string description = reader.GetString(2);
                        ItemStatus itemStatus = new ItemStatus
                                                {
                                                    Id = id,
                                                    Name = name,
                                                    Description = description,
                                                };
                        Log.Debug("Found ItemStatus: {0}", itemStatus.FormatItemStatus());
                        return itemStatus;
                    }
                    reader.Close();
                    sqLiteConnection.Close();
                }
            }
            catch (Exception exception)
            {
                Log.Error(exception.ToString());
            }
            return null;
        }

        public int ItemStatusUpdate(ItemStatus itemStatus)
        {
            try
            {
                string commandText =
                    @"UPDATE ItemStatus SET Name = @name, Description = @description WHERE Id = " +
                    itemStatus.Id;
                Log.Debug("ItemStatusUpdate: [{0}], ItemStatus={1}", commandText, itemStatus.FormatItemStatus());
                using (sqLiteConnection)
                {
                    using (SQLiteCommand sqLiteCommand = new SQLiteCommand(commandText, sqLiteConnection))
                    {
                        sqLiteConnection.Open();
                        sqLiteCommand.Parameters.AddWithValue("@name", itemStatus.Name);
                        sqLiteCommand.Parameters.AddWithValue("@description", itemStatus.Description);
                        int rowsUpdated = sqLiteCommand.ExecuteNonQuery();
                        sqLiteConnection.Close();
                        return rowsUpdated;
                    }
                }
            }
            catch (Exception exception)
            {
                Log.Error(exception.ToString);
                return 0;
            }
        }

        public int ItemTypeDelete(int itemTypeId)
        {
            string commandText = String.Format(@"DELETE FROM ItemType WHERE Id = {0}", itemTypeId);
            return ExecuteNonQuery(commandText);
        }

        public ItemType ItemTypeGet(int itemTypeId)
        {
            string commandText = @"SELECT Id, Name, Description FROM ItemType WHERE Id = " + itemTypeId;
            Log.Info("ItemTypeGet: [{0}]", commandText);
            return ItemTypeSelect(commandText);
        }

        public ItemType ItemTypeGet(string itemTypeName)
        {
            string commandText = String.Format(@"SELECT Id, Name, Description FROM ItemType WHERE Name = '{0}'",
                                               itemTypeName);
            Log.Info("ItemTypeGet: [{0}]", commandText);
            return ItemTypeSelect(commandText);
        }

        public List<ItemType> ItemTypeGetAll()
        {
            DataTable dataTable = GetDataTable(@"SELECT Id, Name, Description FROM ItemType");
            DataRowCollection dataRowCollection = dataTable.Rows;
            if (dataRowCollection.Count > 0)
            {
                return (from DataRow dataRow in dataRowCollection
                        select dataRow.ItemArray
                        into itemArray
                        select new ItemType
                               {
                                   Id = Misc.String2Number(itemArray[0].ToString()),
                                   Name = itemArray[1].ToString(),
                                   Description = itemArray[2].ToString(),
                               }).ToList();
            }
            return null;
        }

        public int ItemTypeInsert(ItemType itemType)
        {
            string insertCommand = String.Format(@"INSERT INTO ItemType (Name, Description) VALUES('{0}', '{1}')",
                                                 itemType.Name, itemType.Description);
            return ExecuteNonQuery(insertCommand);
        }

        private ItemType ItemTypeSelect(string commandText)
        {
            try
            {
                using (sqLiteConnection)
                {
                    sqLiteConnection.Open();
                    SQLiteCommand mycommand = new SQLiteCommand(sqLiteConnection) {CommandText = commandText};
                    SQLiteDataReader reader = mycommand.ExecuteReader(CommandBehavior.SequentialAccess);
                    while (reader.Read())
                    {
                        int id = reader.GetInt32(0);
                        string name = reader.GetString(1);
                        string description = reader.GetString(2);
                        ItemType itemType = new ItemType
                                            {
                                                Id = id,
                                                Name = name,
                                                Description = description,
                                            };
                        Log.Debug("Found ItemType: {0}", itemType.FormatItem());
                        return itemType;
                    }
                    reader.Close();
                    sqLiteConnection.Close();
                }
            }
            catch (Exception exception)
            {
                Log.Error(exception.ToString());
            }
            return null;
        }

        public int ItemTypeUpdate(ItemType itemType)
        {
            try
            {
                string commandText =
                    @"UPDATE ItemType SET Name = @name, Description = @description WHERE Id = " +
                    itemType.Id;
                Log.Debug("ItemTypeUpdate: [{0}], ItemType={1}", commandText, itemType.FormatItem());
                using (sqLiteConnection)
                {
                    using (SQLiteCommand sqLiteCommand = new SQLiteCommand(commandText, sqLiteConnection))
                    {
                        sqLiteConnection.Open();
                        sqLiteCommand.Parameters.AddWithValue("@name", itemType.Name);
                        sqLiteCommand.Parameters.AddWithValue("@description", itemType.Description);
                        int rowsUpdated = sqLiteCommand.ExecuteNonQuery();
                        sqLiteConnection.Close();
                        return rowsUpdated;
                    }
                }
            }
            catch (Exception exception)
            {
                Log.Error(exception.ToString);
                return 0;
            }
        }

        public int ItemUpdate(Item item)
        {
            try
            {
                string commandText =
                    @"UPDATE Item SET Name = @name, Description = @description, ItemType = itemType, Image = @image WHERE Id = " +
                    item.Id;
                Log.Debug("ItemUpdate: [{0}], Item={1}", commandText, item.FormatItem());
                using (sqLiteConnection)
                {
                    using (SQLiteCommand sqLiteCommand = new SQLiteCommand(commandText, sqLiteConnection))
                    {
                        sqLiteConnection.Open();
                        sqLiteCommand.Parameters.AddWithValue("@name", item.Name);
                        sqLiteCommand.Parameters.AddWithValue("@description", item.Description);
                        sqLiteCommand.Parameters.AddWithValue("@itemType", item.ItemTypeId);
                        sqLiteCommand.Parameters.AddWithValue("@image", item.Image);
                        int rowsUpdated = sqLiteCommand.ExecuteNonQuery();
                        sqLiteConnection.Close();
                        return rowsUpdated;
                    }
                }
            }
            catch (Exception exception)
            {
                Log.Error(exception.ToString);
                return 0;
            }
        }

        private static byte[] GetBytes(SQLiteDataReader reader)
        {
            byte[] bytes;
            const int chunkSize = 2*1024;
            byte[] buffer = new byte[chunkSize];
            long fieldOffset = 0;
            using (MemoryStream stream = new MemoryStream())
            {
                long bytesRead;
                while ((bytesRead = reader.GetBytes(4, fieldOffset, buffer, 0, buffer.Length)) > 0)
                {
                    byte[] actualRead = new byte[bytesRead];
                    Buffer.BlockCopy(buffer, 0, actualRead, 0, (int) bytesRead);
                    stream.Write(actualRead, 0, actualRead.Length);
                    fieldOffset += bytesRead;
                }
                bytes = stream.ToArray();
            }
            return bytes;
        }

        public PersonInfo PersonInfoGet(int personInfoId)
        {
            string commandText =
                @"SELECT Id, Name, SurName, NickName, Description, Address, PostNumber, City, Email, Telephone, TelephoneMobile, Fax FROM PersonInfo WHERE Id = " +
                personInfoId;
            Log.Debug("PersonInfoGet: {0}", commandText);
            return PersonInfoSelect(commandText);
        }

        public PersonInfo PersonInfoGet(string personInfoName)
        {
            string commandText =
                String.Format(
                    @"SELECT Id, Name, SurName, NickName, Description, Address, PostNumber, City, Email, Telephone, TelephoneMobile, Fax FROM PersonInfo WHERE name = '{0}'",
                    personInfoName);
            Log.Debug("PersonInfoGet: {0}", commandText);
            return PersonInfoSelect(commandText);
        }

        public List<PersonInfo> PersonInfoGetAll()
        {
            const string commandText =
                @"SELECT Id, Name, SurName, NickName, Description, Address, PostNumber, City, Email, Telephone, TelephoneMobile, Fax FROM PersonInfo";
            Log.Debug("PersonInfoGetAll");
            DataTable dataTable = GetDataTable(commandText);
            DataRowCollection dataRowCollection = dataTable.Rows;
            if (dataRowCollection.Count > 0)
            {
                return (from DataRow dataRow in dataRowCollection
                        select dataRow.ItemArray
                        into itemArray
                        select new PersonInfo
                               {
                                   Id = Misc.String2Number(itemArray[0].ToString()),
                                   Name = itemArray[1].ToString(),
                                   SurName = itemArray[2].ToString(),
                                   NickName = itemArray[3].ToString(),
                                   Description = itemArray[4].ToString(),
                                   Address = itemArray[5].ToString(),
                                   PostNumber = Misc.String2Number(itemArray[6].ToString()),
                                   City = itemArray[7].ToString(),
                                   Email = itemArray[8].ToString(),
                                   Telephone = itemArray[9].ToString(),
                                   TelephoneMobile = itemArray[10].ToString(),
                                   Fax = itemArray[11].ToString(),
                               }).ToList();
            }
            return null;
        }

        public int PersonInfoInsert(PersonInfo personInfo)
        {
            string insertCommand =
                String.Format(
                    @"INSERT INTO PersonInfo ( Name, SurName, NickName, Description, Address, PostNumber, City, Email, Telephone, TelephoneMobile, Fax) VALUES('{0}', '{1}', '{2}', '{3}', '{4}', {5}, '{6}', '{7}', '{8}', '{9}', '{10}')",
                    personInfo.Name,
                    personInfo.SurName,
                    personInfo.NickName,
                    personInfo.Description,
                    personInfo.Address,
                    personInfo.PostNumber,
                    personInfo.City,
                    personInfo.Email,
                    personInfo.Telephone,
                    personInfo.TelephoneMobile,
                    personInfo.Fax);
            return ExecuteNonQuery(insertCommand);
        }

        private PersonInfo PersonInfoSelect(string commandText)
        {
            DataTable dataTable = GetDataTable(commandText);
            DataRowCollection dataRowCollection = dataTable.Rows;
            if (dataRowCollection.Count > 0)
            {
                object[] itemArray = dataRowCollection[0].ItemArray;
                PersonInfo personInfo = new PersonInfo
                                        {
                                            Id = Misc.String2Number(itemArray[0].ToString()),
                                            Name = itemArray[1].ToString(),
                                            SurName = itemArray[2].ToString(),
                                            NickName = itemArray[3].ToString(),
                                            Description = itemArray[4].ToString(),
                                            Address = itemArray[5].ToString(),
                                            PostNumber = Misc.String2Number(itemArray[6].ToString()),
                                            City = itemArray[7].ToString(),
                                            Email = itemArray[8].ToString(),
                                            Telephone = itemArray[9].ToString(),
                                            TelephoneMobile = itemArray[10].ToString(),
                                            Fax = itemArray[11].ToString(),
                                        };
                Log.Debug("have PersonInfo: {0}", personInfo.Format());
                return personInfo;
            }
            return null;
        }

        public int StoreInsert()
        {
            throw new NotImplementedException();
        }
    }
}