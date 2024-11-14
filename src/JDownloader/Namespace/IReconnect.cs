using System.Threading.Tasks;

namespace JDownloader.Namespace
{
    public interface IReconnect
    {
        /// <summary>
        /// Performs a reconnect operation.
        /// </summary>
        Task DoReconnect();
    }
}