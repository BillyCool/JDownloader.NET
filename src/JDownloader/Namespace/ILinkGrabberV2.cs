using JDownloader.Model;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace JDownloader.Namespace
{
    public interface ILinkGrabberV2
    {
        /// <summary>
        /// Aborts the current link grabbing process.
        /// </summary>
        /// <returns>True if the abort operation was successful, otherwise false.</returns>
        Task<bool> Abort();

        /// <summary>
        /// Aborts a specific link grabbing job.
        /// </summary>
        /// <param name="jobId">The ID of the job to abort.</param>
        /// <returns>True if the abort operation was successful, otherwise false.</returns>
        Task<bool> Abort(long jobId);

        /// <summary>
        /// Adds a container to the link grabber.
        /// </summary>
        /// <param name="type">The type of the container.</param>
        /// <param name="content">The content of the container.</param>
        /// <returns>The link collecting job representing the added container.</returns>
        Task<LinkCollectingJob> AddContainer(string type, string content);

        /// <summary>
        /// Adds links to the link grabber.
        /// </summary>
        /// <param name="query">The query containing the links to add.</param>
        /// <returns>The link collecting job representing the added links.</returns>
        Task<LinkCollectingJob> AddLinks(AddLinksQuery query);

        /// <summary>
        /// Adds a variant copy of a link to a target link and package.
        /// </summary>
        /// <param name="linkId">The ID of the link to copy.</param>
        /// <param name="targetLinkId">The ID of the target link.</param>
        /// <param name="targetPackageId">The ID of the target package.</param>
        /// <param name="variantId">The ID of the variant.</param>
        Task AddVariantCopy(long linkId, long targetLinkId, long targetPackageId, string variantId);

        /// <summary>
        /// Performs cleanup operations on specified links and packages.
        /// </summary>
        /// <param name="linkIds">The IDs of the links to clean up.</param>
        /// <param name="packageIds">The IDs of the packages to clean up.</param>
        /// <param name="cleanupAction">The cleanup action to perform.</param>
        /// <param name="cleanupMode">The cleanup mode to use.</param>
        /// <param name="selectionType">The selection type for cleanup.</param>
        Task Cleanup(long[] linkIds, long[] packageIds, CleanupAction cleanupAction, CleanupMode cleanupMode, SelectionType selectionType);

        /// <summary>
        /// Clears the link grabber list.
        /// </summary>
        /// <returns>True if the clear operation was successful, otherwise false.</returns>
        Task<bool> ClearList();

        /// <summary>
        /// Checks if the children of a structure have changed.
        /// </summary>
        /// <param name="structureWatermark">The watermark of the structure.</param>
        /// <returns>True if the children have changed, otherwise false.</returns>
        Task<bool> GetChildrenChanged(long structureWatermark);

        /// <summary>
        /// Gets the selection base for the download folder history.
        /// </summary>
        /// <returns>A list of strings representing the selection base.</returns>
        Task<List<string>> GetDownloadFolderHistorySelectionBase();

        /// <summary>
        /// Gets the download URLs for specified links and packages.
        /// </summary>
        /// <param name="linkIds">The IDs of the links to get download URLs for.</param>
        /// <param name="packageIds">The IDs of the packages to get download URLs for.</param>
        /// <param name="urlDisplayTypes">The display types for the URLs.</param>
        /// <returns>A dictionary containing the download URLs.</returns>
        Task<Dictionary<string, List<long>>> GetDownloadUrls(long[] linkIds, long[] packageIds, UrlDisplayType[] urlDisplayTypes);

        /// <summary>
        /// Gets the count of packages in the link grabber.
        /// </summary>
        /// <returns>The count of packages.</returns>
        Task<int> GetPackageCount();

        /// <summary>
        /// Gets the variants of a link.
        /// </summary>
        /// <param name="linkId">The ID of the link.</param>
        /// <returns>A list of link variants.</returns>
        Task<List<LinkVariant>> GetVariants(long linkId);

        /// <summary>
        /// Checks if the link grabber is currently collecting links.
        /// </summary>
        /// <returns>True if the link grabber is collecting, otherwise false.</returns>
        Task<bool> IsCollecting();

        /// <summary>
        /// Moves specified links to a target link and package.
        /// </summary>
        /// <param name="linkIds">The IDs of the links to move.</param>
        /// <param name="targetLinkId">The ID of the target link.</param>
        /// <param name="targetPackageId">The ID of the target package.</param>
        Task MoveLinks(long[] linkIds, long targetLinkId, long targetPackageId);

        /// <summary>
        /// Moves specified packages to a target package.
        /// </summary>
        /// <param name="packageIds">The IDs of the packages to move.</param>
        /// <param name="targetPackageId">The ID of the target package.</param>
        Task MovePackages(long[] packageIds, long targetPackageId);

        /// <summary>
        /// Moves specified links and packages to the download list.
        /// </summary>
        /// <param name="linkIds">The IDs of the links to move.</param>
        /// <param name="packageIds">The IDs of the packages to move.</param>
        Task MoveToDownloadList(long[] linkIds, long[] packageIds);

        /// <summary>
        /// Moves specified links and packages to a new package.
        /// </summary>
        /// <param name="linkIds">The IDs of the links to move.</param>
        /// <param name="packageIds">The IDs of the packages to move.</param>
        /// <param name="newPackageName">The name of the new package.</param>
        /// <param name="downloadPath">The download path for the new package.</param>
        Task MoveToNewPackage(long[] linkIds, long[] packageIds, string newPackageName, string downloadPath);

        /// <summary>
        /// Queries link crawler jobs based on the specified query.
        /// </summary>
        /// <param name="query">The query to filter the link crawler jobs.</param>
        /// <returns>A list of job link crawlers.</returns>
        Task<List<JobLinkCrawler>> QueryLinkCrawlerJobs(LinkCrawlerJobsQuery query);

        /// <summary>
        /// Queries links based on the specified query.
        /// </summary>
        /// <param name="query">The query to filter the links.</param>
        /// <returns>A list of crawled links.</returns>
        Task<List<CrawledLink>> QueryLinks(CrawledLinkQuery query);

        /// <summary>
        /// Queries packages based on the specified query.
        /// </summary>
        /// <param name="query">The query to filter the packages.</param>
        /// <returns>A list of crawled packages.</returns>
        Task<List<CrawledPackage>> QueryPackages(CrawledPackageQuery query);

        /// <summary>
        /// Removes specified links and packages from the link grabber.
        /// </summary>
        /// <param name="linkIds">The IDs of the links to remove.</param>
        /// <param name="packageIds">The IDs of the packages to remove.</param>
        Task RemoveLinks(long[] linkIds, long[] packageIds);

        /// <summary>
        /// Renames a link.
        /// </summary>
        /// <param name="linkId">The ID of the link to rename.</param>
        /// <param name="newName">The new name for the link.</param>
        Task RenameLink(long linkId, string newName);

        /// <summary>
        /// Renames a package.
        /// </summary>
        /// <param name="packageId">The ID of the package to rename.</param>
        /// <param name="newName">The new name for the package.</param>
        Task RenamePackage(long packageId, string newName);

        /// <summary>
        /// Sets the download directory for specified packages.
        /// </summary>
        /// <param name="packageIds">The IDs of the packages to set the download directory for.</param>
        /// <param name="downloadPath">The download path to set.</param>
        Task SetDownloadDirectory(long[] packageIds, string downloadPath);

        /// <summary>
        /// Sets the download password for specified links and packages.
        /// </summary>
        /// <param name="linkIds">The IDs of the links to set the download password for.</param>
        /// <param name="packageIds">The IDs of the packages to set the download password for.</param>
        /// <param name="password">The password to set.</param>
        /// <returns>True if the password was set successfully, otherwise false.</returns>
        Task<bool> SetDownloadPassword(long[] linkIds, long[] packageIds, string password);

        /// <summary>
        /// Sets the enabled status for specified links and packages.
        /// </summary>
        /// <param name="linkIds">The IDs of the links to set the enabled status for.</param>
        /// <param name="packageIds">The IDs of the packages to set the enabled status for.</param>
        /// <param name="enabled">The enabled status to set.</param>
        Task SetEnabled(long[] linkIds, long[] packageIds, bool enabled);

        /// <summary>
        /// Sets the priority for specified links and packages.
        /// </summary>
        /// <param name="linkIds">The IDs of the links to set the priority for.</param>
        /// <param name="packageIds">The IDs of the packages to set the priority for.</param>
        /// <param name="priority">The priority to set.</param>
        Task SetPriority(long[] linkIds, long[] packageIds, Priority priority);

        /// <summary>
        /// Sets the variant for a link.
        /// </summary>
        /// <param name="linkId">The ID of the link to set the variant for.</param>
        /// <param name="variantId">The ID of the variant to set.</param>
        Task SetVariant(long linkId, string variantId);

        /// <summary>
        /// Splits specified packages by hoster.
        /// </summary>
        /// <param name="linkIds">The IDs of the links to split.</param>
        /// <param name="packageIds">The IDs of the packages to split.</param>
        Task SplitPackageByHoster(long[] linkIds, long[] packageIds);

        /// <summary>
        /// Starts the online status check for specified links and packages.
        /// </summary>
        /// <param name="linkIds">The IDs of the links to start the online status check for.</param>
        /// <param name="packageIds">The IDs of the packages to start the online status check for.</param>
        Task StartOnlineStatusCheck(long[] linkIds, long[] packageIds);
    }
}
