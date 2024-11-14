using JDownloader.Model;
using System.Collections.Generic;
using System.Text.Json;
using System.Threading.Tasks;

namespace JDownloader.Namespace
{
    public class Plugins : BaseNamespace, IPlugins
    {
        public override string Endpoint => "plugins";

        public Plugins(JDownloaderClient jDownloaderClient) : base(jDownloaderClient) { }

        public Task<object> Get(string interfaceName, string displayName, string key) =>
            PostRequestAsync<object>(ApiConstants.Plugins.Get, new object[] { interfaceName, displayName, key });

        public Task<Dictionary<string, List<string>>> GetAllPluginRegex() =>
            PostRequestAsync<Dictionary<string, List<string>>>(ApiConstants.Plugins.GetAllPluginRegex);

        public Task<List<string>> GetPluginRegex(string url) =>
            PostRequestAsync<List<string>>(ApiConstants.Plugins.GetPluginRegex, new object[] { url });

        public Task<List<string>> List(PluginsQuery query) =>
            PostRequestAsync<List<string>>(ApiConstants.Plugins.List, new object[] { JsonSerializer.Serialize(query, JsonSerializerOptions) });

        public Task<PluginConfigEntry> Query(AdvancedConfigQuery query) =>
            PostRequestAsync<PluginConfigEntry>(ApiConstants.Plugins.Query, new object[] { JsonSerializer.Serialize(query, JsonSerializerOptions) });

        public Task<bool> Reset(string interfaceName, string displayName, string key) =>
            PostRequestAsync<bool>(ApiConstants.Plugins.Reset, new object[] { interfaceName, displayName, key });

        public Task<bool> Set(string interfaceName, string displayName, string key, object newValue) =>
            PostRequestAsync<bool>(ApiConstants.Plugins.Set, new object[] { interfaceName, displayName, key, newValue });
    }
}