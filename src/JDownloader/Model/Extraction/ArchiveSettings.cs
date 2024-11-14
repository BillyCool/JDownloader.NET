using System.Collections.Generic;

namespace JDownloader.Model
{
    public class ArchiveSettings
    {
        public string ArchiveId { get; set; }

        public bool? AutoExtract { get; set; }

        public string ExtractPath { get; set; }

        public string FinalPassword { get; set; }

        public List<string> Passwords { get; set; }

        public bool? RemoveDownloadLinksAfterExtraction { get; set; }

        public bool? RemoveFilesAfterExtraction { get; set; }
    }
}