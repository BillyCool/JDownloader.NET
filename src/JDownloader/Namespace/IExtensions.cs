using JDownloader.Model;
using System.Threading.Tasks;

namespace JDownloader.Namespace
{
    public interface IExtensions
    {
        /// <summary>
        /// Installs the extension with the specified extension ID.
        /// </summary>
        /// <param name="extensionId">The ID of the extension to install.</param>
        /// <returns>True if the extension is installed successfully, otherwise false.</returns>
        Task<bool> Install(string extensionId);

        /// <summary>
        /// Checks if the extension with the specified class name is enabled.
        /// </summary>
        /// <param name="className">The class name of the extension to check.</param>
        /// <returns>True if the extension is enabled, otherwise false.</returns>
        Task<bool> IsEnabled(string className);

        /// <summary>
        /// Checks if the extension with the specified extension ID is installed.
        /// </summary>
        /// <param name="extensionId">The ID of the extension to check.</param>
        /// <returns>True if the extension is installed, otherwise false.</returns>
        Task<bool> IsInstalled(string extensionId);

        /// <summary>
        /// Lists the extensions based on the specified query.
        /// </summary>
        /// <param name="query">The query to filter the extensions.</param>
        /// <returns>True if the extensions are listed successfully, otherwise false.</returns>
        Task<bool> List(ExtensionQuery query);

        /// <summary>
        /// Sets the enabled status of the extension with the specified class name.
        /// </summary>
        /// <param name="className">The class name of the extension to set the enabled status.</param>
        /// <param name="enabled">The enabled status to set.</param>
        /// <returns>True if the enabled status is set successfully, otherwise false.</returns>
        Task<bool> SetEnabled(string className, bool enabled);
    }
}
