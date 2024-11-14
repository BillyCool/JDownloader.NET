namespace JDownloader.Model
{
    public class Subscription
    {
        public string[] Exclusions { get; set; }

        public long MaxKeepalive { get; set; }

        public long MaxPolltimeout { get; set; }

        public bool Subscribed { get; set; }

        public long Subscriptionid { get; set; }

        public string[] Subscriptions { get; set; }
    }
}