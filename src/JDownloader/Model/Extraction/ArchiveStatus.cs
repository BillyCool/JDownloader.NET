using System.Collections.Generic;

namespace JDownloader.Model
{
    public class ArchiveStatus
    {
        public string ArchiveId { get; set; }

        public string ArchiveName { get; set; }

        public long ControllerId { get; set; }

        public ControllerStatus ControllerStatus { get; set; }

        public Dictionary<string, ArchiveFileStatus> States { get; set; }

        public string Type { get; set; }
    }
}