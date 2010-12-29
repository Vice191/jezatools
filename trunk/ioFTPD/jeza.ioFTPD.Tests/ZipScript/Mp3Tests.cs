#region
using System;
using System.IO;
using jeza.ioFTPD.Framework;
using MbUnit.Framework;
using TagLib;
using File=System.IO.File;
using FileInfo=System.IO.FileInfo;

#endregion

namespace jeza.ioFTPD.Tests.ZipScript
{
    [TestFixture]
    public class Mp3Tests : ZipScriptBase
    {
        /// <summary>
        /// Races one mp3 file.
        /// </summary>
        [Test]
        public void Race()
        {
            CleanTestFilesOutput();
            UploadSfvFileMp3();
            Race race = new Race(ArgsMp3File1);
            race.Parse();
            race.Process();
            Output output = new Output(race);
            FileInfo fileInfo = new FileInfo(Path.Combine(race.CurrentUploadData.DirectoryPath, Config.FileNameRace));
            using (FileStream stream = new FileStream(fileInfo.FullName,
                                                      FileMode.Open,
                                                      FileAccess.Read,
                                                      FileShare.None))
            {
                using (BinaryReader reader = new BinaryReader(stream))
                {
                    stream.Seek(0, SeekOrigin.Begin);
                    Assert.AreEqual(4, reader.ReadInt32(), "Total files count");
                    stream.Seek(256 * 1, SeekOrigin.Begin);
                    Assert.AreEqual("01-jozek.Pepek-2009-asd-Ind.mp3", reader.ReadString(), "FileName");
                    Assert.AreEqual("2e04944c", reader.ReadString(), "CRC32");
                    Assert.AreEqual(true, reader.ReadBoolean(), "File was uploaded");
                    Assert.AreEqual((UInt64) 5000, reader.ReadUInt64(), "FileSize");
                }
            }
            Assert.AreEqual((UInt64) 5000, race.TotalBytesUploaded, "TotalBytesUploaded");
            Assert.AreEqual(4, race.TotalFilesExpected, "TotalFilesExpected");
            Assert.AreEqual(1, race.TotalFilesUploaded, "TotalFilesUploaded");
            Assert.IsFalse(
                File.Exists(@"..\..\TestFiles\Mp3\01-jozek.Pepek-2009-asd-Ind.mp3" + Config.FileExtensionMissing),
                "01-jozek.Pepek-2009-asd-Ind.mp3" + Config.FileExtensionMissing);
            Assert.IsTrue(
                Directory.Exists(Path.Combine(race.CurrentUploadData.DirectoryParent, output.Format(Config.TagIncompleteLink))),
                "Symlink does not exist!");
            race = new Race(ArgsMp3File2);
            race.Parse();
            race.Process();
            output = new Output(race);
            Assert.IsFalse(
                File.Exists(@"..\..\TestFiles\Mp3\02-jozek.Pepek-2009-asd-Ind.mp3" + Config.FileExtensionMissing),
                "02-jozek.Pepek-2009-asd-Ind.mp3" + Config.FileExtensionMissing);
            Assert.IsTrue(
                Directory.Exists(Path.Combine(race.CurrentUploadData.DirectoryParent, output.Format(Config.TagIncompleteLink))),
                "Symlink does not exist!");
            race = new Race(ArgsMp3File3);
            race.Parse();
            race.Process();
            output = new Output(race);
            Assert.IsFalse(
                File.Exists(@"..\..\TestFiles\Mp3\03-jozek.Pepek-2009-asd-Ind(2).mp3" + Config.FileExtensionMissing),
                "03-jozek.Pepek-2009-asd-Ind(2).mp3" + Config.FileExtensionMissing);
            Assert.IsTrue(
                Directory.Exists(Path.Combine(race.CurrentUploadData.DirectoryParent, output.Format(Config.TagIncompleteLink))),
                "Symlink does not exist!");
            race = new Race(ArgsMp3File4);
            race.Parse();
            race.Process();
            output = new Output(race);
            Assert.AreEqual(4, race.TotalFilesExpected, "TotalFilesExpected");
            Assert.AreEqual(4, race.TotalFilesUploaded, "TotalFilesUploaded");
            Assert.IsFalse(
                File.Exists(@"..\..\TestFiles\Mp3\04-jozek.Pepek-2009-asd-Ind(3).mp3" + Config.FileExtensionMissing),
                "04-jozek.Pepek-2009-asd-Ind(3).mp3" + Config.FileExtensionMissing);
            Assert.IsFalse(
                Directory.Exists(Path.Combine(race.CurrentUploadData.DirectoryParent, output.Format(Config.TagIncompleteLink))),
                "Symlink not deleted!");
        }

        /// <summary>
        /// Get id3 info from mp3 file.
        /// </summary>
        [Test]
        public void Mp3Info()
        {
            TagLib.File file = TagLib.File.Create(@"..\..\TestFiles\Mp3\SwingingSafari.mp3");
            Assert.AreEqual("Collection", file.Tag.Album, "Album");
            Assert.AreEqual("Bert Kaempfert", file.Tag.FirstAlbumArtist, "Artist");
            Assert.AreEqual("1", file.Tag.Track.ToString(), "");
            Assert.AreEqual("2002", file.Tag.Year.ToString(), "Year");
            Assert.AreEqual("Blues", file.Tag.FirstGenre, "Genre");
            Assert.AreEqual("A Swinging Safari", file.Tag.Title, "Title");
            Properties properties = file.Properties;
            Assert.AreEqual(128, properties.AudioBitrate, "properties.AudioBitrate");
            Assert.AreEqual(2, properties.AudioChannels, "properties.AudioChannels");
            Assert.AreEqual(44100, properties.AudioSampleRate, "properties.AudioSampleRate");
            Assert.AreEqual("MPEG Version 1 Audio, Layer 3", properties.Description, "properties.Description");
            Assert.AreEqual(new TimeSpan(0, 0, 3, 9, 323), properties.Duration, "properties.Duration");
            Assert.AreEqual(189, (int) properties.Duration.TotalSeconds, "properties.Duration.TotalSeconds");
        }
    }
}