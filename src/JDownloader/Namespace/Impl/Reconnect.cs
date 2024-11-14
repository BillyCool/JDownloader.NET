using System.Threading.Tasks;

namespace JDownloader.Namespace
{
    public class Reconnect : BaseNamespace, IReconnect
    {
        public override string Endpoint => "reconnect";

        public Reconnect(JDownloaderClient jDownloaderClient) : base(jDownloaderClient) { }

        public Task DoReconnect() =>
            PostRequestAsync(ApiConstants.Reconnect.DoReconnect);
    }
}