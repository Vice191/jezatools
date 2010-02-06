namespace jeza.ioFTPD.Framework
{
    public static class Config
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
        public const string ClientFileNameSfvFirst = "| Deleting.: {0,-80:B79}|�Upload SFV first!";

        public const string ClientMp3InfoHead =
            "|----------=[ Mp3 Info          ]=-----------------------------------------------------------|";

        public const string ClientMp3Info =
            "| Track....: {0,-80:B79}|\r\n| Title....: {1,-80:B79}|\r\n| Artist...: {2,-80:B79}|\r\n| Album....: {3,-80:B79}|\r\n| Year.....: {4,-80:B79}|\r\n| Genre....: {5,-80:B79}|�TrackNumber Title Artist Album Year Genre";

        public const string ClientStatsUsersHead =
            "|----------=[ User Stats        ]=-----------------------------------------------------------|";

        public const string ClientStatsUsers =
            "| {0,2:B2}. {1,15:B15}/{2,-15:B15} {3,4:B4}MB {4,5:B5}kBit/s {5,3:B3}F                                |�Possition UserName GroupName MegaBytesUploaded AverageSpeed FilesUploaded";

        public const string ClientStatsGroupsHead =
            "|----------=[ Group Stats       ]=-----------------------------------------------------------|";

        public const string ClientStatsGroups =
            "| {0,2:B2}. {1,-31:B31} {2,4:B4}MB {3,5:B5}kBit/s {4,3:B3}F                                |�Possition GroupName MegaBytesUploaded AverageSpeed FilesUploaded";

        public const string ClientFoot =
            "'---------------------------------------------------------------------=[ {0,3:B3}/{1,-3:B3} ]=----------'�TotalFilesUploaded TotalFilesExpected";

        /*
         * Th tag cannot contain the following characters : \ / : * ? " < > |
         */
        public const bool TagAsFile = true;
        public const string TagCleanUpString = "]-["; //deete all files that start with this string in race folder

        public const string TagIncompleteRar =
            "]-[iNCOMPLETE]-[ {0}% ]-[{1}FiLE(s) of {2}FiLE(s)]-[iNCOMPLETE]-[�PercentComplete TotalFilesUploaded TotalFilesExpected";

        public const string TagCompleteRar = "]-[Complete {0}MB - {1}F]-[�TotalMegaBytesUploaded TotalFilesUploaded";
    }
}