using JDownloader.Model;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace JDownloader.Namespace
{
    public interface IDownloadsV2
    {
        /// <summary>
        /// Cleans up the specified links and packages based on the cleanup action and cleanup mode.
        /// </summary>
        /// <param name="linkIds">The IDs of the links to be cleaned up.</param>
        /// <param name="packageIds">The IDs of the packages to be cleaned up.</param>
        /// <param name="cleanupAction">The cleanup action to be performed.</param>
        /// <param name="cleanupMode">The cleanup mode to be used.</param>
        /// <param name="selectionType">The selection type to be used.</param>
        /// <returns>True if the cleanup operation is successful, otherwise, false.</returns>
        Task<bool> Cleanup(long[] linkIds, long[] packageIds, CleanupAction cleanupAction, CleanupMode cleanupMode, SelectionType selectionType);

        /// <summary>
        /// Forces the download of the specified links and packages.
        /// </summary>
        /// <param name="linkIds">The IDs of the links to be force downloaded.</param>
        /// <param name="packageIds">The IDs of the packages to be force downloaded.</param>
        /// <returns>True if the force download operation is successful, otherwise, false.</returns>
        Task<bool> ForceDownload(long[] linkIds, long[] packageIds);

        /// <summary>
        /// Gets the download URLs for the specified links and packages with the specified URL display types.
        /// </summary>
        /// <param name="linkIds">The IDs of the links to get the download URLs for.</param>
        /// <param name="packageIds">The IDs of the packages to get the download URLs for.</param>
        /// <param name="urlDisplayTypes">The URL display types to be used.</param>
        /// <returns>A dictionary containing the download URLs for each link and package.</returns>
        Task<Dictionary<string, List<long>>> GetDownloadUrls(long[] linkIds, long[] packageIds, UrlDisplayType[] urlDisplayTypes);

        /// <summary>
        /// Gets the stop mark value.
        /// </summary>
        /// <returns>The stop mark value.</returns>
        Task<long> GetStopMark();

        /// <summary>
        /// Gets the stop marked link.
        /// </summary>
        /// <returns>The stop marked link.</returns>
        Task<DownloadLink> GetStopMarkedLink();

        /// <summary>
        /// Gets the structure change counter for the specified old counter value.
        /// </summary>
        /// <param name="oldCounterValue">The old counter value.</param>
        /// <returns>The structure change counter.</returns>
        Task<long> GetStructureChangeCounter(long oldCounterValue);

        /// <summary>
        /// Moves the specified links to the target link and package.
        /// </summary>
        /// <param name="linkIds">The IDs of the links to be moved.</param>
        /// <param name="afterLinkId">The ID of the link to insert after.</param>
        /// <param name="targetPackageId">The ID of the target package.</param>
        Task MoveLinks(long[] linkIds, long afterLinkId, long targetPackageId);

        /// <summary>
        /// Moves the specified packages to the target package.
        /// </summary>
        /// <param name="packageIds">The IDs of the packages to be moved.</param>
        /// <param name="targetPackageId">The ID of the target package.</param>
        Task MovePackages(long[] packageIds, long targetPackageId);

        /// <summary>
        /// Moves the specified links and packages to a new package with the specified name and download path.
        /// </summary>
        /// <param name="linkIds">The IDs of the links to be moved.</param>
        /// <param name="packageIds">The IDs of the packages to be moved.</param>
        /// <param name="newPackageName">The name of the new package.</param>
        /// <param name="downloadPath">The download path of the new package.</param>
        Task MoveToNewPackage(long[] linkIds, long[] packageIds, string newPackageName, string downloadPath);

        /// <summary>
        /// Gets the count of packages.
        /// </summary>
        /// <returns>The count of packages.</returns>
        Task<int> PackageCount();

        /// <summary>
        /// Queries the links based on the specified query.
        /// </summary>
        /// <param name="query">The query to be used.</param>
        /// <returns>A list of download links that match the query.</returns>
        Task<List<DownloadLink>> QueryLinks(LinkQuery query);

        /// <summary>
        /// Queries the packages based on the specified query.
        /// </summary>
        /// <param name="query">The query to be used.</param>
        /// <returns>A list of file packages that match the query.</returns>
        Task<List<FilePackage>> QueryPackages(PackageQuery query);

        /// <summary>
        /// Removes the specified links and packages.
        /// </summary>
        /// <param name="linkIds">The IDs of the links to be removed.</param>
        /// <param name="packageIds">The IDs of the packages to be removed.</param>
        Task RemoveLinks(long[] linkIds, long[] packageIds);

        /// <summary>
        /// Removes the stop mark.
        /// </summary>
        Task RemoveStopMark();

        /// <summary>
        /// Renames the specified link.
        /// </summary>
        /// <param name="linkId">The ID of the link to be renamed.</param>
        /// <param name="newName">The new name of the link.</param>
        Task RenameLink(long linkId, string newName);

        /// <summary>
        /// Renames the specified package.
        /// </summary>
        /// <param name="packageId">The ID of the package to be renamed.</param>
        /// <param name="newName">The new name of the package.</param>
        Task RenamePackage(long packageId, string newName);

        /// <summary>
        /// Resets the specified links and packages.
        /// </summary>
        /// <param name="linkIds">The IDs of the links to be reset.</param>
        /// <param name="packageIds">The IDs of the packages to be reset.</param>
        Task ResetLinks(long[] linkIds, long[] packageIds);

        /// <summary>
        /// Resumes the specified links and packages.
        /// </summary>
        /// <param name="linkIds">The IDs of the links to be resumed.</param>
        /// <param name="packageIds">The IDs of the packages to be resumed.</param>
        Task ResumeLinks(long[] linkIds, long[] packageIds);

        /// <summary>
        /// Sets the comment for the specified links and packages.
        /// </summary>
        /// <param name="linkIds">The IDs of the links to set comment for.</param>
        /// <param name="packageIds">The IDs of the packages to set comment for.</param>
        /// <param name="setPackageChildren">Set comment for all children in package.</param>
        /// <param name="comment">String to use for comment.</param>
        Task SetComment(long[] linkIds, long[] packageIds, bool setPackageChildren, string comment);

        /// <summary>
        /// Sets the download directory for the specified packages.
        /// </summary>
        /// <param name="directory">The download directory.</param>
        /// <param name="packageIds">The IDs of the packages to set the download directory for.</param>
        Task SetDownloadDirectory(string directory, long[] packageIds);

        /// <summary>
        /// Sets the download password for the specified links and packages.
        /// </summary>
        /// <param name="linkIds">The IDs of the links to set the download password for.</param>
        /// <param name="packageIds">The IDs of the packages to set the download password for.</param>
        /// <param name="pass">The download password.</param>
        /// <returns>True if the download password is set successfully, otherwise, false.</returns>
        Task<bool> SetDownloadPassword(long[] linkIds, long[] packageIds, string pass);

        /// <summary>
        /// Sets the enabled status for the specified links and packages.
        /// </summary>
        /// <param name="enabled">The enabled status to be set.</param>
        /// <param name="linkIds">The IDs of the links to set the enabled status for.</param>
        /// <param name="packageIds">The IDs of the packages to set the enabled status for.</param>
        /// <returns>True if the enabled status is set successfully, otherwise, false.</returns>
        Task SetEnabled(bool enabled, long[] linkIds, long[] packageIds);

        /// <summary>
        /// Sets the priority for the specified links and packages with the specified priority.
        /// </summary>
        /// <param name="priority">The priority to be set.</param>
        /// <param name="linkIds">The IDs of the links to set the priority for.</param>
        /// <param name="packageIds">The IDs of the packages to set the priority for.</param>
        Task SetPriority(Priority priority, long[] linkIds, long[] packageIds);

        /// <summary>
        /// Sets the stop mark for the specified link and package.
        /// </summary>
        /// <param name="linkId">The ID of the link to set the stop mark for.</param>
        /// <param name="packageId">The ID of the package to set the stop mark for.</param>
        Task SetStopMark(long linkId, long packageId);

        /// <summary>
        /// Splits the specified packages by hoster.
        /// </summary>
        /// <param name="linkIds">The IDs of the links to be split.</param>
        /// <param name="packageIds">The IDs of the packages to be split.</param>
        Task SplitPackageByHoster(long[] linkIds, long[] packageIds);

        /// <summary>
        /// Starts the online status check for the specified links and packages.
        /// </summary>
        /// <param name="linkIds">The IDs of the links to start the online status check for.</param>
        /// <param name="packageIds">The IDs of the packages to start the online status check for.</param>
        Task StartOnlineStatusCheck(long[] linkIds, long[] packageIds);

        /// <summary>
        /// Unskips the specified packages and links based on the provided package IDs, link IDs, and reason filter.
        /// </summary>
        /// <param name="packageIds">The IDs of the packages to be unskipped.</param>
        /// <param name="linkIds">The IDs of the links to be unskipped.</param>
        /// <param name="filterByReason">The reason filter to be applied.</param>
        Task Unskip(long[] packageIds, long[] linkIds, Reason filterByReason);
    }
}
