namespace JDownloader.Model
{
    public class JobLinkCrawler
    {
        public int Broken { get; set; }

        public bool Checking { get; set; }

        public int Crawled { get; set; }

        public long CrawlerId { get; set; }

        public bool Crawling { get; set; }

        public int Filtered { get; set; }

        public long JobId { get; set; }

        public int Unhandled { get; set; }
    }
}