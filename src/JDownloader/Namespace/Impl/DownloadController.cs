using JDownloader.Model;
using System.Threading.Tasks;

namespace JDownloader.Namespace
{
    public class DownloadController : BaseNamespace, IDownloadController
    {
        public override string Endpoint => "downloadcontroller";

        public DownloadController(JDownloaderClient jDownloaderClient) : base(jDownloaderClient) { }

        public Task ForceDownload(long[] linkIds, long[] packageIds) =>
            PostRequestAsync(ApiConstants.DownloadController.ForceDownload, new object[] { linkIds, packageIds });

        public Task<DownloaderState> GetCurrentState() =>
            PostRequestAsync<DownloaderState>(ApiConstants.DownloadController.GetCurrentState);

        public Task<long> GetSpeedInBps() =>
            PostRequestAsync<long>(ApiConstants.DownloadController.GetSpeedInBps);

        public Task<bool> Start() =>
            PostRequestAsync<bool>(ApiConstants.DownloadController.Start);

        public Task<bool> Stop() =>
            PostRequestAsync<bool>(ApiConstants.DownloadController.Stop);

        public Task<bool> Pause(bool pause) =>
            PostRequestAsync<bool>(ApiConstants.DownloadController.Pause, new object[] { pause });
    }
}