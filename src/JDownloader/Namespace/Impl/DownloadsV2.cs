using JDownloader.Model;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json;
using System.Threading.Tasks;

namespace JDownloader.Namespace
{
    public class DownloadsV2 : BaseNamespace, IDownloadsV2
    {
        public override string Endpoint => "downloadsV2";

        public DownloadsV2(JDownloaderClient jDownloaderClient) : base(jDownloaderClient) { }

        public Task<bool> Cleanup(long[] linkIds, long[] packageIds, CleanupAction cleanupAction, CleanupMode cleanupMode, SelectionType selectionType) =>
            PostRequestAsync<bool>(ApiConstants.DownloadsV2.Cleanup, new object[] { linkIds, packageIds, cleanupAction.ToString(), cleanupMode.ToString(), selectionType.ToString() });

        public Task<bool> ForceDownload(long[] linkIds, long[] packageIds) =>
            PostRequestAsync<bool>(ApiConstants.DownloadsV2.ForceDownload, new object[] { linkIds, packageIds });

        public Task<Dictionary<string, List<long>>> GetDownloadUrls(long[] linkIds, long[] packageIds, UrlDisplayType[] urlDisplayTypes) =>
            PostRequestAsync<Dictionary<string, List<long>>>(ApiConstants.DownloadsV2.GetDownloadUrls, new object[] { linkIds, packageIds, urlDisplayTypes.Select(x => x.ToString()).ToArray() });

        public Task<long> GetStopMark() =>
            PostRequestAsync<long>(ApiConstants.DownloadsV2.GetStopMark);

        public Task<DownloadLink> GetStopMarkedLink() =>
            PostRequestAsync<DownloadLink>(ApiConstants.DownloadsV2.GetStopMarkedLink);

        public Task<long> GetStructureChangeCounter(long oldCounterValue) =>
            PostRequestAsync<long>(ApiConstants.DownloadsV2.GetStructureChangeCounter, new object[] { oldCounterValue });

        public Task MoveLinks(long[] linkIds, long afterLinkId, long targetPackageId) =>
            PostRequestAsync(ApiConstants.DownloadsV2.MoveLinks, new object[] { linkIds, afterLinkId, targetPackageId });

        public Task MovePackages(long[] packageIds, long targetPackageId) =>
            PostRequestAsync(ApiConstants.DownloadsV2.MovePackages, new object[] { packageIds, targetPackageId });

        public Task MoveToNewPackage(long[] linkIds, long[] packageIds, string newPackageName, string downloadPath) =>
            PostRequestAsync(ApiConstants.DownloadsV2.MoveToNewPackage, new object[] { linkIds, packageIds, newPackageName, downloadPath });

        public Task<int> PackageCount() =>
            PostRequestAsync<int>(ApiConstants.DownloadsV2.PackageCount);

        public Task<List<DownloadLink>> QueryLinks(LinkQuery query) =>
            PostRequestAsync<List<DownloadLink>>(ApiConstants.DownloadsV2.QueryLinks, new object[] { JsonSerializer.Serialize(query, JsonSerializerOptions) });

        public Task<List<FilePackage>> QueryPackages(PackageQuery query) =>
            PostRequestAsync<List<FilePackage>>(ApiConstants.DownloadsV2.QueryPackages, new object[] { JsonSerializer.Serialize(query, JsonSerializerOptions) });

        public Task RemoveLinks(long[] linkIds, long[] packageIds) =>
            PostRequestAsync(ApiConstants.DownloadsV2.RemoveLinks, new object[] { linkIds, packageIds });

        public Task RemoveStopMark() =>
            PostRequestAsync(ApiConstants.DownloadsV2.RemoveStopMark);

        public Task RenameLink(long linkId, string newName) =>
            PostRequestAsync(ApiConstants.DownloadsV2.RenameLink, new object[] { linkId, newName });

        public Task RenamePackage(long packageId, string newName) =>
            PostRequestAsync(ApiConstants.DownloadsV2.RenamePackage, new object[] { packageId, newName });

        public Task ResetLinks(long[] linkIds, long[] packageIds) =>
            PostRequestAsync(ApiConstants.DownloadsV2.ResetLinks, new object[] { linkIds, packageIds });

        public Task ResumeLinks(long[] linkIds, long[] packageIds) =>
            PostRequestAsync(ApiConstants.DownloadsV2.ResumeLinks, new object[] { linkIds, packageIds });

        public Task SetComment (long[] linkIds, long[] packageIds, bool setPackageChildren, string comment) =>
            PostRequestAsync(ApiConstants.DownloadsV2.SetComment, new object[] { linkIds, packageIds, setPackageChildren, comment });

        public Task SetDownloadDirectory(string directory, long[] packageIds) =>
            PostRequestAsync(ApiConstants.DownloadsV2.SetDownloadDirectory, new object[] { directory, packageIds });

        public Task<bool> SetDownloadPassword(long[] linkIds, long[] packageIds, string pass) =>
            PostRequestAsync<bool>(ApiConstants.DownloadsV2.SetDownloadPassword, new object[] { linkIds, packageIds, pass });

        public Task SetEnabled(bool enabled, long[] linkIds, long[] packageIds) =>
            PostRequestAsync(ApiConstants.DownloadsV2.SetEnabled, new object[] { enabled, linkIds, packageIds });

        public Task SetPriority(Priority priority, long[] linkIds, long[] packageIds) =>
            PostRequestAsync(ApiConstants.DownloadsV2.SetPriority, new object[] { priority.ToString(), linkIds, packageIds });

        public Task SetStopMark(long linkId, long packageId) =>
            PostRequestAsync(ApiConstants.DownloadsV2.SetStopMark, new object[] { linkId, packageId });

        public Task SplitPackageByHoster(long[] linkIds, long[] packageIds) =>
            PostRequestAsync(ApiConstants.DownloadsV2.SplitPackageByHoster, new object[] { linkIds, packageIds });

        public Task StartOnlineStatusCheck(long[] linkIds, long[] packageIds) =>
            PostRequestAsync(ApiConstants.DownloadsV2.StartOnlineStatusCheck, new object[] { linkIds, packageIds });

        public Task Unskip(long[] packageIds, long[] linkIds, Reason filterByReason) =>
            PostRequestAsync(ApiConstants.DownloadsV2.Unskip, new object[] { linkIds, packageIds, filterByReason.ToString() });
    }
}