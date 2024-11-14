using System.Threading.Tasks;

namespace JDownloader.Namespace
{
    public class Update : BaseNamespace, IUpdate
    {
        public override string Endpoint => "update";

        public Update(JDownloaderClient jDownloaderClient) : base(jDownloaderClient) { }

        public Task<bool> IsUpdateAvailable() =>
            PostRequestAsync<bool>(ApiConstants.Update.IsUpdateAvailable);

        public Task RestartAndUpdate() =>
            PostRequestAsync(ApiConstants.Update.RestartAndUpdate);

        public Task RunUpdateCheck() =>
            PostRequestAsync(ApiConstants.Update.RunUpdateCheck);
    }
}