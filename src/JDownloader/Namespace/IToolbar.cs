using JDownloader.Model;
using System.Threading.Tasks;

namespace JDownloader.Namespace
{
    public interface IToolbar
    {
        /// <summary>
        /// Adds links from the Document Object Model (DOM) to the download queue.
        /// </summary>
        /// <returns>The result of adding the links.</returns>
        Task<object> AddLinksFromDOM();

        /// <summary>
        /// Checks the availability of links from the Document Object Model (DOM).
        /// </summary>
        /// <returns>The result of checking the links.</returns>
        Task<object> CheckLinksFromDOM();

        /// <summary>
        /// Gets the status of the toolbar.
        /// </summary>
        /// <returns>The status of the toolbar.</returns>
        Task<object> GetStatus();

        /// <summary>
        /// Checks if the toolbar is available.
        /// </summary>
        /// <returns>True if the toolbar is available, otherwise, false.</returns>
        Task<bool> IsAvailable();

        /// <summary>
        /// Polls the checked links from the Document Object Model (DOM) using the specified check ID.
        /// </summary>
        /// <param name="checkId">The ID of the link check.</param>
        /// <returns>The result of polling the checked links.</returns>
        Task<LinkCheckResult> PollCheckedLinksFromDOM(string checkId);

        /// <summary>
        /// Handles a special URL.
        /// </summary>
        /// <param name="url">The URL to handle.</param>
        /// <returns>The result of handling the URL.</returns>
        Task<string> SpecialURLHandling(string url);

        /// <summary>
        /// Starts the downloads.
        /// </summary>
        /// <returns>True if the downloads started successfully, otherwise, false.</returns>
        Task<bool> StartDownloads();

        /// <summary>
        /// Stops the downloads.
        /// </summary>
        /// <returns>True if the downloads stopped successfully, otherwise, false.</returns>
        Task<bool> StopDownloads();

        /// <summary>
        /// Toggles the automatic reconnect feature.
        /// </summary>
        /// <returns>True if the automatic reconnect feature is enabled, otherwise, false.</returns>
        Task<bool> ToggleAutomaticReconnect();

        /// <summary>
        /// Toggles the clipboard monitoring feature.
        /// </summary>
        /// <returns>True if the clipboard monitoring feature is enabled, otherwise, false.</returns>
        Task<bool> ToggleClipboardMonitoring();

        /// <summary>
        /// Toggles the download speed limit feature.
        /// </summary>
        /// <returns>True if the download speed limit feature is enabled, otherwise, false.</returns>
        Task<bool> ToggleDownloadSpeedLimit();

        /// <summary>
        /// Toggles the pause downloads feature.
        /// </summary>
        /// <returns>True if the pause downloads feature is enabled, otherwise, false.</returns>
        Task<bool> TogglePauseDownloads();

        /// <summary>
        /// Toggles the premium feature.
        /// </summary>
        /// <returns>True if the premium feature is enabled, otherwise, false.</returns>
        Task<bool> TogglePremium();

        /// <summary>
        /// Toggles the stop after current download feature.
        /// </summary>
        /// <returns>True if the stop after current download feature is enabled, otherwise, false.</returns>
        Task<bool> ToggleStopAfterCurrentDownload();

        /// <summary>
        /// Triggers an update.
        /// </summary>
        /// <returns>True if the update was triggered successfully, otherwise, false.</returns>
        Task<bool> TriggerUpdate();
    }
}