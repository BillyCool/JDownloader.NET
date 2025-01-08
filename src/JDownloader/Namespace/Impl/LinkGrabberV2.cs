using JDownloader.Model;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json;
using System.Threading.Tasks;

namespace JDownloader.Namespace
{
    public class LinkGrabberV2 : BaseNamespace, ILinkGrabberV2
    {
        public override string Endpoint => "linkgrabberv2";

        public LinkGrabberV2(JDownloaderClient jDownloaderClient) : base(jDownloaderClient) { }

        public Task<bool> Abort() =>
            PostRequestAsync<bool>(ApiConstants.LinkGrabberV2.Abort);

        public Task<bool> Abort(long jobId) =>
            PostRequestAsync<bool>(ApiConstants.LinkGrabberV2.Abort, new object[] { jobId });

        public Task<LinkCollectingJob> AddContainer(string type, string content) =>
            PostRequestAsync<LinkCollectingJob>(ApiConstants.LinkGrabberV2.AddContainer, new object[] { type, content });

        public Task<LinkCollectingJob> AddLinks(AddLinksQuery query) =>
            PostRequestAsync<LinkCollectingJob>(ApiConstants.LinkGrabberV2.AddLinks, new object[] { JsonSerializer.Serialize(query, JsonSerializerOptions) });

        public Task AddVariantCopy(long linkId, long targetLinkId, long targetPackageId, string variantId) =>
            PostRequestAsync(ApiConstants.LinkGrabberV2.AddVariantCopy, new object[] { linkId, targetLinkId, targetPackageId, variantId });

        public Task Cleanup(long[] linkIds, long[] packageIds, CleanupAction cleanupAction, CleanupMode cleanbupMode, SelectionType selectionType) =>
            PostRequestAsync(ApiConstants.LinkGrabberV2.Cleanup,
                new object[] { linkIds, packageIds, cleanupAction.ToString(), cleanbupMode.ToString(), selectionType.ToString() });

        public Task<bool> ClearList() => PostRequestAsync<bool>(ApiConstants.LinkGrabberV2.ClearList);

        public Task<bool> GetChildrenChanged(long structureWatermark) =>
            PostRequestAsync<bool>(ApiConstants.LinkGrabberV2.GetChildrenChanged, new object[] { structureWatermark });

        public Task<List<string>> GetDownloadFolderHistorySelectionBase() =>
            PostRequestAsync<List<string>>(ApiConstants.LinkGrabberV2.GetDownloadFolderHistorySelectionBase);

        public Task<Dictionary<string, List<long>>> GetDownloadUrls(long[] linkIds, long[] packageIds, UrlDisplayType[] urlDisplayTypes) =>
            PostRequestAsync<Dictionary<string, List<long>>>(ApiConstants.LinkGrabberV2.GetDownloadUrls,
                new object[] { linkIds, packageIds, urlDisplayTypes.Select(x => x.ToString()).ToArray() });

        public Task<int> GetPackageCount() =>
            PostRequestAsync<int>(ApiConstants.LinkGrabberV2.GetPackageCount);

        public Task<List<LinkVariant>> GetVariants(long linkId) =>
            PostRequestAsync<List<LinkVariant>>(ApiConstants.LinkGrabberV2.GetVariants, new object[] { linkId }, doubleJsonEncode: true);

        public Task<bool> IsCollecting() =>
            PostRequestAsync<bool>(ApiConstants.LinkGrabberV2.IsCollecting);

        public Task MoveLinks(long[] linkIds, long targetLinkId, long targetPackageId) =>
            PostRequestAsync(ApiConstants.LinkGrabberV2.MoveLinks, new object[] { linkIds, targetLinkId, targetPackageId });

        public Task MovePackages(long[] packageIds, long targetPackageId) =>
            PostRequestAsync(ApiConstants.LinkGrabberV2.MovePackages, new object[] { packageIds, targetPackageId });

        public Task MoveToDownloadList(long[] linkIds, long[] packageIds) =>
            PostRequestAsync(ApiConstants.LinkGrabberV2.MoveToDownloadList, new object[] { linkIds, packageIds });

        public Task MoveToNewPackage(long[] linkIds, long[] packageIds, string newPackageName, string downloadPath) =>
            PostRequestAsync(ApiConstants.LinkGrabberV2.MoveToNewPackage, new object[] { linkIds, packageIds, newPackageName, downloadPath });

        public Task<List<JobLinkCrawler>> QueryLinkCrawlerJobs(LinkCrawlerJobsQuery query) =>
            PostRequestAsync<List<JobLinkCrawler>>(ApiConstants.LinkGrabberV2.QueryLinkCrawlerJobs, new object[] { JsonSerializer.Serialize(query, JsonSerializerOptions) });

        public Task<List<CrawledLink>> QueryLinks(CrawledLinkQuery query) =>
            PostRequestAsync<List<CrawledLink>>(ApiConstants.LinkGrabberV2.QueryLinks, new object[] { JsonSerializer.Serialize(query, JsonSerializerOptions) }, doubleJsonEncode: true);

        public Task<List<CrawledPackage>> QueryPackages(CrawledPackageQuery query) =>
            PostRequestAsync<List<CrawledPackage>>(ApiConstants.LinkGrabberV2.QueryPackages, new object[] { JsonSerializer.Serialize(query, JsonSerializerOptions) });

        public Task RemoveLinks(long[] linkIds, long[] packageIds) =>
            PostRequestAsync(ApiConstants.LinkGrabberV2.RemoveLinks, new object[] { linkIds, packageIds });

        public Task RenameLink(long linkId, string newName) =>
            PostRequestAsync(ApiConstants.LinkGrabberV2.RenameLink, new object[] { linkId, newName });

        public Task RenamePackage(long packageId, string newName) =>
            PostRequestAsync(ApiConstants.LinkGrabberV2.RenamePackage, new object[] { packageId, newName });

        public Task SetComment(long[] linkIds, long[] packageIds, bool setPackageChildren, string comment) =>
            PostRequestAsync(ApiConstants.DownloadsV2.SetComment, new object[] { linkIds, packageIds, setPackageChildren, comment });

        public Task SetDownloadDirectory(long[] packageIds, string downloadPath) =>
            PostRequestAsync(ApiConstants.LinkGrabberV2.SetDownloadDirectory, new object[] { downloadPath, packageIds });

        public Task<bool> SetDownloadPassword(long[] linkIds, long[] packageIds, string password) =>
            PostRequestAsync<bool>(ApiConstants.LinkGrabberV2.SetDownloadPassword, new object[] { linkIds, packageIds, password });

        public Task SetEnabled(long[] linkIds, long[] packageIds, bool enabled) =>
            PostRequestAsync(ApiConstants.LinkGrabberV2.SetEnabled, new object[] { enabled, linkIds, packageIds });

        public Task SetPriority(long[] linkIds, long[] packageIds, Priority priority) =>
            PostRequestAsync(ApiConstants.LinkGrabberV2.SetPriority, new object[] { priority, linkIds, packageIds });

        public Task SetVariant(long linkId, string variantId) =>
            PostRequestAsync(ApiConstants.LinkGrabberV2.SetVariant, new object[] { linkId, variantId });

        public Task SplitPackageByHoster(long[] linkIds, long[] packageIds) =>
            PostRequestAsync(ApiConstants.LinkGrabberV2.SplitPackageByHoster, new object[] { linkIds, packageIds });

        public Task StartOnlineStatusCheck(long[] linkIds, long[] packageIds) =>
            PostRequestAsync(ApiConstants.LinkGrabberV2.StartOnlineStatusCheck, new object[] { linkIds, packageIds });
    }
}