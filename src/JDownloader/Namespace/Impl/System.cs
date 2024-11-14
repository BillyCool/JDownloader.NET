using JDownloader.Model;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace JDownloader.Namespace
{
    public class System : BaseNamespace, ISystem
    {
        public override string Endpoint => "system";

        public System(JDownloaderClient jDownloaderClient) : base(jDownloaderClient) { }

        public Task<bool> ExitJD() =>
            PostRequestAsync<bool>(ApiConstants.System.ExitJD);

        public Task<List<StorageInformation>> GetStorageInfos(string path) =>
            PostRequestAsync<List<StorageInformation>>(ApiConstants.System.GetStorageInfos, new object[] { path });

        public Task<SystemInformation> GetSystemInfos() =>
            PostRequestAsync<SystemInformation>(ApiConstants.System.GetSystemInfos);

        public Task<bool> HibernateOS() =>
            PostRequestAsync<bool>(ApiConstants.System.HibernateOS);

        public Task<bool> RestartJD() =>
            PostRequestAsync<bool>(ApiConstants.System.RestartJD);

        public Task<bool> ShutdownOS(bool forceShutdown) =>
            PostRequestAsync<bool>(ApiConstants.System.ShutdownOS, new object[] { forceShutdown });

        public Task<bool> StandbyOS() =>
            PostRequestAsync<bool>(ApiConstants.System.StandbyOS);
    }
}