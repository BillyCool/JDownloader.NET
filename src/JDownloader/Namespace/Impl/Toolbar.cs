using JDownloader.Model;
using System.Threading.Tasks;

namespace JDownloader.Namespace
{
    public class Toolbar : BaseNamespace, IToolbar
    {
        public override string Endpoint => "toolbar";

        public Toolbar(JDownloaderClient jDownloaderClient) : base(jDownloaderClient) { }

        public Task<object> AddLinksFromDOM() =>
            PostRequestAsync<object>(ApiConstants.Toolbar.AddLinksFromDOM);

        public Task<object> CheckLinksFromDOM() =>
            PostRequestAsync<object>(ApiConstants.Toolbar.CheckLinksFromDOM);

        public Task<object> GetStatus() =>
            PostRequestAsync<object>(ApiConstants.Toolbar.GetStatus);

        public Task<bool> IsAvailable() =>
            PostRequestAsync<bool>(ApiConstants.Toolbar.IsAvailable);

        public Task<LinkCheckResult> PollCheckedLinksFromDOM(string checkId) =>
            PostRequestAsync<LinkCheckResult>(ApiConstants.Toolbar.PollCheckedLinksFromDOM, new object[] { checkId });

        public Task<string> SpecialURLHandling(string url) =>
            PostRequestAsync<string>(ApiConstants.Toolbar.SpecialURLHandling, new object[] { url });

        public Task<bool> StartDownloads() =>
            PostRequestAsync<bool>(ApiConstants.Toolbar.StartDownloads);

        public Task<bool> StopDownloads() =>
            PostRequestAsync<bool>(ApiConstants.Toolbar.StopDownloads);

        public Task<bool> ToggleAutomaticReconnect() =>
            PostRequestAsync<bool>(ApiConstants.Toolbar.ToggleAutomaticReconnect);

        public Task<bool> ToggleClipboardMonitoring() =>
            PostRequestAsync<bool>(ApiConstants.Toolbar.ToggleClipboardMonitoring);

        public Task<bool> ToggleDownloadSpeedLimit() =>
            PostRequestAsync<bool>(ApiConstants.Toolbar.ToggleDownloadSpeedLimit);

        public Task<bool> TogglePauseDownloads() =>
            PostRequestAsync<bool>(ApiConstants.Toolbar.TogglePauseDownloads);

        public Task<bool> TogglePremium() =>
            PostRequestAsync<bool>(ApiConstants.Toolbar.TogglePremium);

        public Task<bool> ToggleStopAfterCurrentDownload() =>
            PostRequestAsync<bool>(ApiConstants.Toolbar.ToggleStopAfterCurrentDownload);

        public Task<bool> TriggerUpdate() =>
            PostRequestAsync<bool>(ApiConstants.Toolbar.TriggerUpdate);
    }
}