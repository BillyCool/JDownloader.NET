using System.Threading.Tasks;

namespace JDownloader.Namespace
{
    public interface ILinkCrawler
    {
        Task<bool> IsCrawling();
    }
}
