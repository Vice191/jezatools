#region
using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;

#endregion

namespace jeza.ioFTPD.Framework
{
    public class Rescan : IoEnvironment
    {
        public Rescan(string[] args)
        {
            this.args = args;
            SourceFolder = GetRealPath();
        }

        public void Parse()
        {
            directoryInfo = new DirectoryInfo(SourceFolder);
            System.IO.FileInfo[] sfvFiles = directoryInfo.GetFiles("*.sfv");
            if (sfvFiles.Length >= 1)
            {
                string sfvFile = sfvFiles [0].FullName;
                dataParserSfv = new DataParserSfv(sfvFile);
                dataParserSfv.Parse();
            }
        }

        public void Process()
        {
            if (dataParserSfv.SfvData.Count > 0)
            {
                Output outputHead = new Output(new Race(null));
                outputHead.Client(Config.ClientCrc32Head);
                rescanStats.TotalFiles = dataParserSfv.SfvData.Count;
                foreach (KeyValuePair<string, string> keyValuePair in dataParserSfv.SfvData)
                {
                    RescanStatsData rescanStatsData = new RescanStatsData();
                    rescanStatsData.FileName = keyValuePair.Key;
                    rescanStatsData.ExpectedCrc32Value = keyValuePair.Value;
                    string fileName = Path.Combine(SourceFolder, keyValuePair.Key);
                    FileInfo fileInfo = new FileInfo();
                    if (File.Exists(fileName))
                    {
                        uint crc32 = Crc32.GetFileCrc32(fileName);
                        string actualCrc32Value = String.Format(CultureInfo.InvariantCulture, "{0:X8}", crc32);
                        rescanStatsData.ActualCrc32Value = actualCrc32Value;
                        if (actualCrc32Value.ToLower().Equals(keyValuePair.Value.ToLower()))
                        {
                            rescanStats.OkFiles++;
                            rescanStatsData.Status = "OK";
                            fileInfo.DeleteFile(SourceFolder, fileName + Config.FileExtensionMissing);
                        }
                        else
                        {
                            rescanStats.FailedFiles++;
                            rescanStatsData.Status = "FAILED";
// ReSharper disable ConditionIsAlwaysTrueOrFalse
                            if (Config.DeleteCrc32FailedFiles) // ReSharper restore ConditionIsAlwaysTrueOrFalse
                            {
                                fileInfo.DeleteFile(SourceFolder, keyValuePair.Key);
                            }
                            else
                            {
                                FileInfo.Create0ByteFile(fileName + Config.Crc32FailedFilesExtension);
                            }
                        }
                    }
                    else
                    {
                        rescanStats.MissingFiles++;
                        rescanStatsData.ActualCrc32Value = "00000000";
                        rescanStatsData.Status = "MISSING";
                        FileInfo.Create0ByteFile(fileName + Config.FileExtensionMissing);
                    }
                    rescanStats.RescanStatsData.Add(rescanStatsData);
                    Output output = new Output(rescanStatsData);
                    output.ClientRescan(Config.ClientCrc32Body);
                }
            }
        }

        public string SourceFolder { get; set; }

        public RescanStats RescanStats
        {
            get { return rescanStats; }
        }

        public DataParserSfv DataParserSfv
        {
            get { return dataParserSfv; }
        }

        private string[] args;
        private DirectoryInfo directoryInfo;
        private readonly RescanStats rescanStats = new RescanStats();
        private DataParserSfv dataParserSfv;
    }
}