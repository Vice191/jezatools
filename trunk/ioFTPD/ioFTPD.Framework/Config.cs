namespace ioFTPD.Framework
{
    public class Config
    {
        public const string FileNameRace = ".ioFTPD.race";
        public const string FileExtensionMissing = ".missing";

        public const string ClientHead =
            ",----------=[ ZipScript by Jeza ]=-----------------------------------------------------------,";

        public const string ClientFileName = "| File.....: {0,-80:B79}|�FileName";
        public const string ClientFileNameOk = "| File OK..: {0,-80:B79}|�FileName";
        public const string ClientFileNameBadCrc = "| Bad CRC..: {0,-80:B79}|�FileName";
        public const string ClientFileNameSfv = "| SFV......: {0,-80:B79}|�FileName";
        public const string ClientFileNameSfvExists = "| Deleting.: {0,-80:B79}|�SFV allready exists!";

        public const string ClientFoot =
            "'---------------------------------------------------------------------=[ {0,-3:B3}/{1,-3:B3} ]=----------'�TotalFilesUploaded TotalFilesExpected";
    }
}