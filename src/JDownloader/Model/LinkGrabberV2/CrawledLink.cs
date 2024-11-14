namespace JDownloader.Model
{
    public class CrawledLink
    {
        public AvailableLinkState AvailableLinkState { get; set; }

        public long BytesTotal { get; set; }

        public string Comment { get; set; }

        public string DownloadPassword { get; set; }

        public bool Enabled { get; set; }

        public string Host { get; set; }

        public string Name { get; set; }

        public long PackageUUID { get; set; }

        public Priority Priority { get; set; }

        public string Url { get; set; }

        public long Uuid { get; set; }

        public LinkVariant Variant { get; set; }

        public bool Variants { get; set; }
    }
}