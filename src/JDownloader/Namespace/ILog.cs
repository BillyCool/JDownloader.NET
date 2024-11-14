using JDownloader.Model;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace JDownloader.Namespace
{
    public interface ILog
    {
        /// <summary>
        /// Retrieves the list of available log folders.
        /// </summary>
        /// <returns>A list of LogFolder objects.</returns>
        Task<List<LogFolder>> GetAvailableLogs();

        /// <summary>
        /// Sends the specified log folders.
        /// </summary>
        /// <param name="logFolders">The log folders to send.</param>
        /// <returns>The ID of the log file that was uploaded.</returns>
        Task<string> SendLogFile(LogFolder[] logFolders);
    }
}
