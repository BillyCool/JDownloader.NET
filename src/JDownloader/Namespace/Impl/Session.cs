using System.Threading.Tasks;

namespace JDownloader.Namespace
{
    public class Session : BaseNamespace, ISession
    {
        public override string Endpoint => "session";

        public Session(JDownloaderClient jDownloaderClient) : base(jDownloaderClient) { }

        public Task<bool> Disconnect() =>
            PostRequestAsync<bool>(ApiConstants.Session.Disconnect);

        public Task<string> Handshake(string username, string password) =>
            PostRequestAsync<string>(ApiConstants.Session.Handshake, new object[] { username, password });
    }
}