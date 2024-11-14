using JDownloader.Model;
using System.Text.Json;
using System.Threading.Tasks;

namespace JDownloader.Namespace
{
    public class Extensions : BaseNamespace, IExtensions
    {
        public override string Endpoint => "extensions";

        public Extensions(JDownloaderClient jDownloaderClient) : base(jDownloaderClient) { }

        public Task<bool> Install(string extensionId) =>
            PostRequestAsync<bool>(ApiConstants.Extensions.Install, new object[] { extensionId });

        public Task<bool> IsEnabled(string className) =>
            PostRequestAsync<bool>(ApiConstants.Extensions.IsEnabled, new object[] { className });

        public Task<bool> IsInstalled(string extensionId) =>
            PostRequestAsync<bool>(ApiConstants.Extensions.IsInstalled, new object[] { extensionId });

        public Task<bool> List(ExtensionQuery query) =>
            PostRequestAsync<bool>(ApiConstants.Extensions.List, new object[] { JsonSerializer.Serialize(query, JsonSerializerOptions) });

        public Task<bool> SetEnabled(string className, bool enabled) =>
            PostRequestAsync<bool>(ApiConstants.Extensions.SetEnabled, new object[] { className, enabled });
    }
}