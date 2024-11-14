using JDownloader.Model;
using System.Threading.Tasks;

namespace JDownloader.Namespace
{
    public interface IDownloadEvents
    {
        /// <summary>
        /// Sets the status event interval for a specific channel.
        /// </summary>
        /// <param name="channelId">The ID of the channel.</param>
        /// <param name="interval">The interval in milliseconds.</param>
        /// <returns>True if the status event interval was set successfully, false otherwise.</returns>
        Task<bool> SetStatusEventInterval(long channelId, long interval);

        /// <summary>
        /// Queries the links based on the specified query parameters and diff ID.
        /// </summary>
        /// <param name="query">The query parameters.</param>
        /// <param name="diffId">The diff ID.</param>
        /// <returns>The download list difference.</returns>
        Task<DownloadListDiff> QueryLinks(LinkQuery query, int diffId);
    }
}
