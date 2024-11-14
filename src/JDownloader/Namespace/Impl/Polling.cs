using JDownloader.Model;
using System.Text.Json;
using System.Threading.Tasks;

namespace JDownloader.Namespace
{
    public class Polling : BaseNamespace, IPolling
    {
        public override string Endpoint => "polling";

        public Polling(JDownloaderClient jDownloaderClient) : base(jDownloaderClient) { }

        public Task<PollingResult> Poll(APIQuery<object> query) =>
            PostRequestAsync<PollingResult>(ApiConstants.Polling.Poll, new object[] { JsonSerializer.Serialize(query, JsonSerializerOptions) });
    }
}