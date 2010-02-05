#region
using System;
using System.Collections;
using System.Collections.Generic;

#endregion

namespace jeza.ioFTPD.Framework
{
    public class RaceStatsUsers : RaceStatsEnumerator<RaceStatsUsers>
    {
        public string UserName { get; set; }
        public string GroupName { get; set; }
        public int Speed { get; set; }
        public int FilesUplaoded { get; set; }
        public UInt64 BytesUplaoded { get; set; }
        
        public override string ToString ()
        {
            return string.Format ("UserName: {0}, GroupName: {1}, Speed: {2}, FilesUplaoded: {3}, BytesUplaoded: {4}",
                                  UserName,
                                  GroupName,
                                  Speed,
                                  FilesUplaoded,
                                  BytesUplaoded);
        }
    }
}