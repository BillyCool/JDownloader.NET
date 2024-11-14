namespace JDownloader.Model
{
    public class CrawledPackageQuery : GenericApiQuery
    {
        public CrawledPackageQuery(bool includeDetails = true) => IncludeDetails(includeDetails);

        public CrawledPackageQuery(long[] packageUUIDs, bool includeDetails = true) : this(includeDetails) => PackageUUIDs = packageUUIDs;

        public bool AvailableOfflineCount { get; set; }

        public bool AvailableOnlineCount { get; set; }

        public bool AvailableTempUnknownCount { get; set; }

        public bool AvailableUnkownCount { get; set; }

        public bool BytesTotal { get; set; }

        public bool ChildCount { get; set; }

        public bool Comment { get; set; }

        public bool Enabled { get; set; }

        public bool Hosts { get; set; }

        public long[] PackageUUIDs { get; set; }

        public bool Priority { get; set; }

        public bool SaveTo { get; set; }

        public bool Status { get; set; }
    }
}