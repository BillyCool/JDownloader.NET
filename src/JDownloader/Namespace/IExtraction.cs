using JDownloader.Model;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace JDownloader.Namespace
{
    public interface IExtraction
    {
        /// <summary>
        /// Adds an archive password.
        /// </summary>
        /// <param name="password">The password to add.</param>
        Task AddArchivePassword(string password);

        /// <summary>
        /// Cancels the extraction process for a specific controller.
        /// </summary>
        /// <param name="controllerId">The ID of the controller.</param>
        /// <returns>True if the extraction was successfully canceled, otherwise, false.</returns>
        Task<bool> CancelExtraction(long controllerId);

        /// <summary>
        /// Retrieves the archive information for the specified link and package IDs.
        /// </summary>
        /// <param name="linkIds">The IDs of the links.</param>
        /// <param name="packageIds">The IDs of the packages.</param>
        /// <returns>The archive status.</returns>
        Task<ArchiveStatus> GetArchiveInfo(long[] linkIds, long[] packageIds);

        /// <summary>
        /// Retrieves the archive settings for the specified archive IDs.
        /// </summary>
        /// <param name="archiveIds">The IDs of the archives.</param>
        /// <returns>The archive settings.</returns>
        Task<ArchiveSettings> GetArchiveSettings(long[] archiveIds);

        /// <summary>
        /// Retrieves the current extraction queue.
        /// </summary>
        /// <returns>The archive status of the extraction queue.</returns>
        Task<ArchiveStatus> GetQueue();

        /// <summary>
        /// Sets the archive settings for a specific archive.
        /// </summary>
        /// <param name="archiveId">The ID of the archive.</param>
        /// <param name="archiveSettings">The archive settings to set.</param>
        /// <returns>True if the archive settings were successfully set, otherwise, false.</returns>
        Task<bool> SetArchiveSettings(string archiveId, ArchiveSettings archiveSettings);

        /// <summary>
        /// Starts the extraction process for the specified link and package IDs.
        /// </summary>
        /// <param name="linkIds">The IDs of the links.</param>
        /// <param name="packageIds">The IDs of the packages.</param>
        /// <returns>A dictionary containing the extraction status for each link and package ID.</returns>
        Task<Dictionary<string, bool?>> StartExtractionNow(long[] linkIds, long[] packageIds);
    }
}
