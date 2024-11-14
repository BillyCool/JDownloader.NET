using JDownloader.Model;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace JDownloader.Namespace
{
    public interface IConfig
    {
        /// <summary>
        /// Retrieves the value associated with the specified key from the specified storage.
        /// </summary>
        /// <param name="interfaceName">The name of the interface.</param>
        /// <param name="storageName">The name of the storage.</param>
        /// <param name="key">The key of the value to retrieve.</param>
        /// <returns>The retrieved value.</returns>
        Task<object> Get(string interfaceName, string storageName, string key);

        /// <summary>
        /// Retrieves the default value associated with the specified key from the specified storage.
        /// </summary>
        /// <param name="interfaceName">The name of the interface.</param>
        /// <param name="storageName">The name of the storage.</param>
        /// <param name="key">The key of the default value to retrieve.</param>
        /// <returns>The retrieved default value.</returns>
        Task<object> GetDefault(string interfaceName, string storageName, string key);

        /// <summary>
        /// Lists the advanced configuration API entries that match the specified pattern.
        /// </summary>
        /// <param name="pattern">The pattern to match.</param>
        /// <param name="returnDescription">Specifies whether to return the description of the entries.</param>
        /// <param name="returnValues">Specifies whether to return the values of the entries.</param>
        /// <param name="returnDefaultValues">Specifies whether to return the default values of the entries.</param>
        /// <param name="returnEnumInfo">Specifies whether to return the enum information of the entries.</param>
        /// <returns>The list of advanced configuration API entries.</returns>
        Task<IEnumerable<AdvancedConfigAPIEntry>> List(string pattern = null, bool returnDescription = false, bool returnValues = false, bool returnDefaultValues = false, bool returnEnumInfo = false);

        /// <summary>
        /// Lists the options of the specified enum type.
        /// </summary>
        /// <param name="enumType">The type of the enum.</param>
        /// <returns>The list of enum options.</returns>
        Task<IEnumerable<EnumOption>> ListEnum(string enumType);

        /// <summary>
        /// Queries the advanced configuration API entries based on the specified query.
        /// </summary>
        /// <param name="query">The query to filter the entries.</param>
        /// <returns>The list of advanced configuration API entries that match the query.</returns>
        Task<IEnumerable<AdvancedConfigAPIEntry>> Query(AdvancedConfigQuery query);

        /// <summary>
        /// Resets the value associated with the specified key in the specified storage.
        /// </summary>
        /// <param name="interfaceName">The name of the interface.</param>
        /// <param name="storageName">The name of the storage.</param>
        /// <param name="key">The key of the value to reset.</param>
        /// <returns>True if the value was reset successfully, otherwise false.</returns>
        Task<bool> Reset(string interfaceName, string storageName, string key);

        /// <summary>
        /// Sets the value associated with the specified key in the specified storage.
        /// </summary>
        /// <param name="interfaceName">The name of the interface.</param>
        /// <param name="storageName">The name of the storage.</param>
        /// <param name="key">The key of the value to set.</param>
        /// <param name="value">The value to set.</param>
        /// <returns>True if the value was set successfully, otherwise false.</returns>
        Task<bool> Set(string interfaceName, string storageName, string key, object value);
    }
}
