﻿namespace JDownloader.Model
{
    public class DownloadLink
    {
        public long AddedDate { get; set; }

        public long BytesLoaded { get; set; }

        public long BytesTotal { get; set; }

        public string Comment { get; set; }

        public string DownloadPassword { get; set; }

        public bool Enabled { get; set; }

        public long Eta { get; set; }

        public string ExtractionStatus { get; set; }

        public bool Finished { get; set; }

        public long FinishedDate { get; set; }

        public string Host { get; set; }

        public string Name { get; set; }

        public long PackageUUID { get; set; }

        public Priority Priority { get; set; }

        public bool Running { get; set; }

        public bool Skipped { get; set; }

        public long Speed { get; set; }

        public string Status { get; set; }

        public string StatusIconKey { get; set; }

        public string Url { get; set; }

        public long UUID { get; set; }
    }
}