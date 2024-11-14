using JDownloader.Model;
using System.Threading.Tasks;

namespace JDownloader.Namespace
{
    public interface IFlash
    {
        /// <summary>
        /// Adds a download with the specified password, source, and URL.
        /// </summary>
        /// <param name="password">The password for the download.</param>
        /// <param name="source">The source of the download.</param>
        /// <param name="url">The URL of the download.</param>
        Task Add(string password, string source, string url);

        /// <summary>
        /// Adds a CNL download with the specified query.
        /// </summary>
        /// <param name="query">The CNL query for the download.</param>
        Task AddCnl(CnlQuery query);

        /// <summary>
        /// Adds a crypted2 remote download with the specified crypted, jk, and k.
        /// </summary>
        /// <param name="crypted">The crypted value for the download.</param>
        /// <param name="jk">The jk value for the download.</param>
        /// <param name="k">The k value for the download.</param>
        Task AddCrypted2Remote(string crypted, string jk, string k);
    }
}
