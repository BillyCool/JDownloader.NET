using System.Threading.Tasks;

namespace JDownloader.Namespace
{
    public class LinkCrawler : BaseNamespace, ILinkCrawler
    {
        public override string Endpoint => "linkcrawler";

        public LinkCrawler(JDownloaderClient jDownloaderClient) : base(jDownloaderClient) { }

        public Task<bool> IsCrawling() =>
            PostRequestAsync<bool>(ApiConstants.LinkCrawler.IsCrawling);
    }
}