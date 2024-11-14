namespace JDownloader.Model
{
    public class LinkCrawlerJobsQuery : GenericApiQuery
    {
        public LinkCrawlerJobsQuery(bool includeDetails = true) => IncludeDetails(includeDetails);

        public LinkCrawlerJobsQuery(long[] jobIds, bool includeDetails = true) : this(includeDetails) => JobIds = jobIds;

        public bool CollectorInfo { get; set; } = true;

        public long[] JobIds { get; set; }
    }
}