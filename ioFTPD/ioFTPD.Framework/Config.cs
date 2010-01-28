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
            "'---------------------------------------------------------------------=[ {0,3:B3}/{1,-3:B3} ]=----------'�TotalFilesUploaded TotalFilesExpected";

        public const string TagCleanUpString = "]-[iNCOMPLETE]-[";  //deete all files that start with this string in race folder
        public const string TagInCompleteRar = "]-[iNCOMPLETE]-[ {0}% ]-[{1}FiLE(s) of {2}FiLE(s)]-[iNCOMPLETE]-[�PercentComplete TotalFilesUploaded TotalFilesExpected";
        public const string TagCompleteRar = "]-[Complete {0}MB - {1}/{2}F]-[�TotalMBytesUploaded TotalFilesUploaded TotalFilesExpected";
    }
}