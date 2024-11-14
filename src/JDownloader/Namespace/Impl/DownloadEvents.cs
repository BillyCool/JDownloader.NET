using JDownloader.Model;
using System.Text.Json;
using System.Threading.Tasks;

namespace JDownloader.Namespace
{
    public class DownloadEvents : BaseNamespace, IDownloadEvents
    {
        public override string Endpoint => "downloadevents";

        public DownloadEvents(JDownloaderClient jDownloaderClient) : base(jDownloaderClient) { }

        public Task<DownloadListDiff> QueryLinks(LinkQuery query, int diffId) =>
            PostRequestAsync<DownloadListDiff>(ApiConstants.DownloadEvents.QueryLinks,
                new object[] { JsonSerializer.Serialize(query, JsonSerializerOptions), diffId });

        public Task<bool> SetStatusEventInterval(long channelId, long interval) =>
            PostRequestAsync<bool>(ApiConstants.DownloadEvents.SetStatusEventInterval, new object[] { channelId, interval });
    }
}