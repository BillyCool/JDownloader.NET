namespace JDownloader.Model
{
    public class PackageQuery : GenericApiQuery
    {
        public PackageQuery(bool includeDetails = true) => IncludeDetails(includeDetails);

        public PackageQuery(long[] packageUUIDs, bool includeDetails = true)
        {
            IncludeDetails(includeDetails);
            PackageUUIDs = packageUUIDs;
        }

        public bool BytesLoaded { get; set; }

        public bool BytesTotal { get; set; }

        public bool ChildCount { get; set; }

        public bool Comment { get; set; }

        public bool Enabled { get; set; }

        public bool Eta { get; set; }

        public bool Finished { get; set; }

        public bool Host { get; set; }

        public long[] PackageUUIDs { get; set; }

        public bool Priority { get; set; }

        public bool Running { get; set; }

        public bool SaveTo { get; set; }

        public bool Speed { get; set; }

        public bool Status { get; set; }
    }
}