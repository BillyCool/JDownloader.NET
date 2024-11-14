using JDownloader.Model;
using System.Collections.Generic;
using System.Text.Json;
using System.Threading.Tasks;

namespace JDownloader.Namespace
{
    public class Config : BaseNamespace, IConfig
    {
        public override string Endpoint => "config";

        public Config(JDownloaderClient jDownloaderClient) : base(jDownloaderClient) { }

        public Task<object> Get(string interfaceName, string storageName, string key) =>
            PostRequestAsync<object>(ApiConstants.Config.Get, new object[] { interfaceName, storageName, key });

        public Task<object> GetDefault(string interfaceName, string storageName, string key) =>
            PostRequestAsync<object>(ApiConstants.Config.GetDefault, new object[] { interfaceName, storageName, key });

        public Task<IEnumerable<AdvancedConfigAPIEntry>> List(string pattern = null, bool returnDescription = false, bool returnValues = false, bool returnDefaultValues = false, bool returnEnumInfo = false) =>
            PostRequestAsync<IEnumerable<AdvancedConfigAPIEntry>>(ApiConstants.Config.List, new object[] { pattern, returnDescription, returnValues, returnDefaultValues, returnEnumInfo });

        public Task<IEnumerable<EnumOption>> ListEnum(string enumType) =>
            PostRequestAsync<IEnumerable<EnumOption>>(ApiConstants.Config.ListEnum, new object[] { enumType });

        public Task<IEnumerable<AdvancedConfigAPIEntry>> Query(AdvancedConfigQuery query) =>
            PostRequestAsync<IEnumerable<AdvancedConfigAPIEntry>>(ApiConstants.Config.Query, new object[] { JsonSerializer.Serialize(query, JsonSerializerOptions) });

        public Task<bool> Reset(string interfaceName, string storageName, string key) =>
            PostRequestAsync<bool>(ApiConstants.Config.Reset, new object[] { interfaceName, storageName, key });

        public Task<bool> Set(string interfaceName, string storageName, string key, object value) =>
            PostRequestAsync<bool>(ApiConstants.Config.Set, new object[] { interfaceName, storageName, key, value });
    }
}