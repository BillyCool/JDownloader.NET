using JDownloader.Model;
using System.Threading.Tasks;

namespace JDownloader.Namespace
{
    public interface IPolling
    {
        /// <summary>
        /// Polls the API with the specified query.
        /// </summary>
        /// <param name="query">The API query.</param>
        /// <returns>The polling result.</returns>
        Task<PollingResult> Poll(APIQuery<object> query);
    }
}