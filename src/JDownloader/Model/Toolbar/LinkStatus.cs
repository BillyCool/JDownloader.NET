namespace JDownloader.Model
{
    public class LinkStatus
    {
        public string Host { get; set; }

        public string LinkCheckID { get; set; }

        public string Name { get; set; }

        public long Size { get; set; }

        public AvailableLinkState Status { get; set; }

        public string Url { get; set; }
    }
}