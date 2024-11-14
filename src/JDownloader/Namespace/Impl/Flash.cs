using JDownloader.Model;
using System.Text.Json;
using System.Threading.Tasks;

namespace JDownloader.Namespace
{
    public class Flash : BaseNamespace, IFlash
    {
        public override string Endpoint => "flash";

        public Flash(JDownloaderClient jDownloaderClient) : base(jDownloaderClient) { }

        public Task Add(string password, string source, string url) =>
            PostRequestAsync(ApiConstants.Flash.Add, new object[] { password, source, url });

        public Task AddCnl(CnlQuery query) =>
            PostRequestAsync(ApiConstants.Flash.AddCnl, new object[] { JsonSerializer.Serialize(query, JsonSerializerOptions) });

        public Task AddCrypted2Remote(string crypted, string jk, string k) =>
            PostRequestAsync(ApiConstants.Flash.AddCrypted2Remote, new object[] { crypted, jk, k });
    }
}