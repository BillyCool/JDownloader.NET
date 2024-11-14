using JDownloader.Model;
using System.Threading.Tasks;

namespace JDownloader.Namespace
{
    public class Device : BaseNamespace, IDevice
    {
        public override string Endpoint => "device";

        public Device(JDownloaderClient jDownloaderClient) : base(jDownloaderClient) { }

        public Task<DirectConnectionInfos> GetDirectConnectionInfos() =>
            PostRequestAsync<DirectConnectionInfos>(ApiConstants.Device.GetDirectConnectionInfos);

        public Task<string> GetSessionPublicKey() =>
            PostRequestAsync<string>(ApiConstants.Device.GetSessionPublicKey);

        public Task<bool> Ping() =>
            PostRequestAsync<bool>(ApiConstants.Device.Ping);
    }
}