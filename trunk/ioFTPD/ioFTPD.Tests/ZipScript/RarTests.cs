﻿#region
using System;
using System.IO;
using ioFTPD.Framework;
using MbUnit.Framework;
using FileInfo=System.IO.FileInfo;

#endregion

namespace ioFTPD.Tests.ZipScript
{
    [TestFixture]
    public class RarTests : ZipScriptBase
    {
        /// <summary>
        /// Uploads the first file. Delete file with missing extension, update RACE file.
        /// </summary>
        [Test]
        public void RaceRar ()
        {
            PrepareCleanRarRace ();
            UploadSfvFile ();

            Race race = new Race (ArgsRarPart1);
            race.Parse ();
            race.Process ();
            FileInfo fileInfo = new FileInfo (Path.Combine (race.DirectoryPath, Config.FileNameRace));
            using (FileStream stream = new FileStream (fileInfo.FullName,
                                                       FileMode.Open,
                                                       FileAccess.Read,
                                                       FileShare.None))
            {
                using (BinaryReader reader = new BinaryReader (stream))
                {
                    stream.Seek (0, SeekOrigin.Begin);
                    Assert.AreEqual (4, reader.ReadInt32 (), "Total files count");
                    stream.Seek (256 * 1, SeekOrigin.Begin);
                    Assert.AreEqual ("infected.part1.rar", reader.ReadString (), "FileName");
                    Assert.AreEqual ("2e04944c", reader.ReadString (), "CRC32");
                    Assert.AreEqual (true, reader.ReadBoolean (), "File was uploaded");
                    Assert.AreEqual ((UInt64) 5000, reader.ReadUInt64 (), "FileSize");
                }
            }
            Assert.AreEqual ((UInt64) 5000, race.TotalBytesUploaded, "TotalBytesUploaded");
            Assert.AreEqual (4, race.TotalFilesExpected, "TotalFilesExpected");
            Assert.AreEqual (1, race.TotalFilesUploaded, "TotalFilesUploaded");

            race = new Race(ArgsRarPart2);
            race.Parse();
            race.Process();
            fileInfo = new FileInfo(Path.Combine(race.DirectoryPath, Config.FileNameRace));
            using (FileStream stream = new FileStream(fileInfo.FullName,
                                                       FileMode.Open,
                                                       FileAccess.Read,
                                                       FileShare.None))
            {
                using (BinaryReader reader = new BinaryReader(stream))
                {
                    stream.Seek(0, SeekOrigin.Begin);
                    Assert.AreEqual(4, reader.ReadInt32(), "Total files count");
                    stream.Seek(256 * 2, SeekOrigin.Begin);
                    Assert.AreEqual("infected.part2.rar", reader.ReadString(), "FileName");
                    Assert.AreEqual("1c7c24a5", reader.ReadString(), "CRC32");
                    Assert.AreEqual(true, reader.ReadBoolean(), "File was uploaded");
                    Assert.AreEqual((UInt64)5000, reader.ReadUInt64(), "FileSize");
                }
            }
            Assert.AreEqual((UInt64)5000*2, race.TotalBytesUploaded, "TotalBytesUploaded");
            Assert.AreEqual(4, race.TotalFilesExpected, "TotalFilesExpected");
            Assert.AreEqual(2, race.TotalFilesUploaded, "TotalFilesUploaded");

            race = new Race(ArgsRarPart3);
            race.Parse();
            race.Process();
            fileInfo = new FileInfo(Path.Combine(race.DirectoryPath, Config.FileNameRace));
            using (FileStream stream = new FileStream(fileInfo.FullName,
                                                       FileMode.Open,
                                                       FileAccess.Read,
                                                       FileShare.None))
            {
                using (BinaryReader reader = new BinaryReader(stream))
                {
                    stream.Seek(0, SeekOrigin.Begin);
                    Assert.AreEqual(4, reader.ReadInt32(), "Total files count");
                    stream.Seek(256 * 3, SeekOrigin.Begin);
                    Assert.AreEqual("infected.part3.rar", reader.ReadString(), "FileName");
                    Assert.AreEqual("d5d617e3", reader.ReadString(), "CRC32");
                    Assert.AreEqual(true, reader.ReadBoolean(), "File was uploaded");
                    Assert.AreEqual((UInt64)5000, reader.ReadUInt64(), "FileSize");
                }
            }
            Assert.AreEqual((UInt64)5000 * 3, race.TotalBytesUploaded, "TotalBytesUploaded");
            Assert.AreEqual(4, race.TotalFilesExpected, "TotalFilesExpected");
            Assert.AreEqual(3, race.TotalFilesUploaded, "TotalFilesUploaded");

            race = new Race(ArgsRarPart4);
            race.Parse();
            race.Process();
            fileInfo = new FileInfo(Path.Combine(race.DirectoryPath, Config.FileNameRace));
            using (FileStream stream = new FileStream(fileInfo.FullName,
                                                       FileMode.Open,
                                                       FileAccess.Read,
                                                       FileShare.None))
            {
                using (BinaryReader reader = new BinaryReader(stream))
                {
                    stream.Seek(0, SeekOrigin.Begin);
                    Assert.AreEqual(4, reader.ReadInt32(), "Total files count");
                    stream.Seek(256 * 4, SeekOrigin.Begin);
                    Assert.AreEqual("infected.part4.rar", reader.ReadString(), "FileName");
                    Assert.AreEqual("0edb20ea", reader.ReadString(), "CRC32");
                    Assert.AreEqual(true, reader.ReadBoolean(), "File was uploaded");
                    Assert.AreEqual((UInt64)2916, reader.ReadUInt64(), "FileSize");
                }
            }
            Assert.AreEqual((UInt64)5000 * 3 + 2916, race.TotalBytesUploaded, "TotalBytesUploaded");
            Assert.AreEqual(4, race.TotalFilesExpected, "TotalFilesExpected");
            Assert.AreEqual(4, race.TotalFilesUploaded, "TotalFilesUploaded");
        }

    }
}