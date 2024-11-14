using System.Threading.Tasks;

namespace JDownloader.Namespace
{
    public interface ISession
    {
        /// <summary>
        /// Disconnects the session.
        /// </summary>
        /// <returns>True if the session was successfully disconnected, otherwise, false.</returns>
        Task<bool> Disconnect();

        /// <summary>
        /// Performs a handshake with the specified username and password.
        /// </summary>
        /// <param name="username">The username to use for the handshake.</param>
        /// <param name="password">The password to use for the handshake.</param>
        /// <returns>The result of the handshake.</returns>
        Task<string> Handshake(string username, string password);
    }
}