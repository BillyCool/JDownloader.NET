using System;
using System.Threading.Tasks;

namespace JDownloader.Namespace
{
    [Obsolete("This namespace has been marked as deprecated in JD source.")]
    public class JD : BaseNamespace, IJD
    {
        public override string Endpoint => "jd";

        public JD(JDownloaderClient jDownloaderClient) : base(jDownloaderClient) { }

        public Task<int> GetCoreRevision() =>
            PostRequestAsync<int>(ApiConstants.Jd.GetCoreRevision);

        public Task<bool> RefreshPlugins() =>
            PostRequestAsync<bool>(ApiConstants.Jd.RefreshPlugins);

        public Task<long> Uptime() =>
            PostRequestAsync<long>(ApiConstants.Jd.Uptime);

        public Task<long> Version() =>
            PostRequestAsync<long>(ApiConstants.Jd.Version);
    }
}