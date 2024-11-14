using JDownloader.Model.Enum;
using System.Collections.Generic;

namespace JDownloader.Model
{
    public class DirectConnectionInfos
    {
        public List<DirectConnectionInfo> Infos { get; set; }

        public bool RebindProtectionDetected { get; set; }

        public DirectConnectionMode Mode { get; set; }
    }
}