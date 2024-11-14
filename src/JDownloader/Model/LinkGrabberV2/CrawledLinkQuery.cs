namespace JDownloader.Model
{
    public class CrawledLinkQuery : GenericApiQuery
    {
        public CrawledLinkQuery(bool includeDetails = true) => IncludeDetails(includeDetails);

        public CrawledLinkQuery(long[] packageUUIDs, bool includeDetails = true) : this(includeDetails) => PackageUUIDs = packageUUIDs;

        public bool Availability { get; set; }

        public bool BytesTotal { get; set; }

        public bool Comment { get; set; }

        public bool Enabled { get; set; }

        public bool Host { get; set; }

        public long[] JobUUIDs { get; set; }

        public long[] PackageUUIDs { get; set; }

        public bool Password { get; set; }

        public bool Priority { get; set; }

        public bool Status { get; set; }

        public bool Url { get; set; }

        public bool VariantID { get; set; }

        public bool VariantIcon { get; set; }

        public bool VariantName { get; set; }

        public bool Variants { get; set; }
    }
}