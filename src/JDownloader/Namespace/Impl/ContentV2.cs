using JDownloader.Model;
using System.Threading.Tasks;

namespace JDownloader.Namespace
{
    public class ContentV2 : BaseNamespace, IContentV2
    {
        public override string Endpoint => "contentV2";

        public ContentV2(JDownloaderClient jDownloaderClient) : base(jDownloaderClient) { }

        public Task<byte[]> GetFavIcon(string hosterName) =>
            PostRequestAsync<byte[]>(ApiConstants.ContentV2.GetFavIcon, new object[] { hosterName });

        public Task<byte[]> GetFileIcon(string fileName) =>
            PostRequestAsync<byte[]>(ApiConstants.ContentV2.GetFileIcon, new object[] { fileName });

        public Task<byte[]> GetIcon(string key, int size) =>
            PostRequestAsync<byte[]>(ApiConstants.ContentV2.GetIcon, new object[] { key, size });

        public Task<IconDescriptor> GetIconDescription(string key) =>
            PostRequestAsync<IconDescriptor>(ApiConstants.ContentV2.GetIconDescription, new object[] { key });
    }
}
