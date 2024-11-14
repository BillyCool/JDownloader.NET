namespace JDownloader.Model
{
    public class LinkQuery : GenericApiQuery
    {
        public LinkQuery(bool includeDetails = true) => IncludeDetails(includeDetails);

        public LinkQuery(long[] packageUUIDs, bool includeDetails = true)
        {
            IncludeDetails(includeDetails);
            PackageUUIDs = packageUUIDs;
        }

        public bool AdvancedStatus { get; set; }

        public bool AddedDate { get; set; }

        public bool BytesLoaded { get; set; }

        public bool BytesTotal { get; set; }

        public bool Comment { get; set; }

        public bool Enabled { get; set; }

        public bool Eta { get; set; }

        public bool ExtractionStatus { get; set; }

        public bool Finished { get; set; }

        public bool FinishedDate { get; set; }

        public bool Host { get; set; }

        public long[] JobUUIDs { get; set; }

        public long[] PackageUUIDs { get; set; }

        public bool Password { get; set; }

        public bool Priority { get; set; }

        public bool Running { get; set; }

        public bool Skipped { get; set; }

        public bool Speed { get; set; }

        public bool Status { get; set; }

        public bool Url { get; set; }
    }
}