using JDownloader.Model;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace JDownloader.Namespace
{
    public interface IPlugins
    {
        /// <summary>
        /// Retrieves a plugin by its interface name, display name, and key.
        /// </summary>
        /// <param name="interfaceName">The interface name of the plugin.</param>
        /// <param name="displayName">The display name of the plugin.</param>
        /// <param name="key">The key of the plugin.</param>
        /// <returns>The retrieved plugin as an object.</returns>
        Task<object> Get(string interfaceName, string displayName, string key);

        /// <summary>
        /// Retrieves all plugin regexes.
        /// </summary>
        /// <returns>A dictionary containing plugin names as keys and a list of regexes as values.</returns>
        Task<Dictionary<string, List<string>>> GetAllPluginRegex();

        /// <summary>
        /// Retrieves plugin regexes for a given URL.
        /// </summary>
        /// <param name="url">The URL for which to retrieve plugin regexes.</param>
        /// <returns>A list of plugin regexes.</returns>
        Task<List<string>> GetPluginRegex(string url);

        /// <summary>
        /// Lists plugins based on the provided query.
        /// </summary>
        /// <param name="query">The query to filter the plugins.</param>
        /// <returns>A list of plugins.</returns>
        Task<List<string>> List(PluginsQuery query);

        /// <summary>
        /// Queries a plugin's advanced configuration based on the provided query.
        /// </summary>
        /// <param name="query">The query to retrieve the advanced configuration.</param>
        /// <returns>The advanced configuration of the plugin.</returns>
        Task<PluginConfigEntry> Query(AdvancedConfigQuery query);

        /// <summary>
        /// Resets a plugin by its interface name, display name, and key.
        /// </summary>
        /// <param name="interfaceName">The interface name of the plugin.</param>
        /// <param name="displayName">The display name of the plugin.</param>
        /// <param name="key">The key of the plugin.</param>
        /// <returns>True if the plugin was successfully reset, otherwise, false.</returns>
        Task<bool> Reset(string interfaceName, string displayName, string key);

        /// <summary>
        /// Sets a plugin's value by its interface name, display name, key, and new value.
        /// </summary>
        /// <param name="interfaceName">The interface name of the plugin.</param>
        /// <param name="displayName">The display name of the plugin.</param>
        /// <param name="key">The key of the plugin.</param>
        /// <param name="newValue">The new value to set for the plugin.</param>
        /// <returns>True if the plugin value was successfully set, otherwise, false.</returns>
        Task<bool> Set(string interfaceName, string displayName, string key, object newValue);
    }
}