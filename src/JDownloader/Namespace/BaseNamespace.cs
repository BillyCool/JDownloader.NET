using JDownloader.Model;
using System.Text.Json;
using System.Threading.Tasks;

namespace JDownloader.Namespace
{
    public abstract class BaseNamespace
    {
        protected readonly JDownloaderClient _jDownloaderClient;

        protected JsonSerializerOptions JsonSerializerOptions => _jDownloaderClient.SerializerOptions;

        public virtual string Endpoint { get; }

        protected BaseNamespace(JDownloaderClient jDownloaderClient)
        {
            _jDownloaderClient = jDownloaderClient;
        }

        protected Task PostRequestAsync(string action, object param = null, bool doubleJsonEncode = false, bool skipDeserialization = false)
        {
            return _jDownloaderClient.PostRequestAsync<object>(new PostRequestArg
            {
                Action = $"/{Endpoint}/{action}",
                Param = param,
                DoubleJsonDecode = doubleJsonEncode,
                SkipDeserialization = skipDeserialization
            });
        }

        protected Task<T> PostRequestAsync<T>(string action, object param = null, bool doubleJsonEncode = false, bool skipDeserialization = false)
        {
            return _jDownloaderClient.PostRequestAsync<T>(new PostRequestArg
            {
                Action = $"/{Endpoint}/{action}",
                Param = param,
                DoubleJsonDecode = doubleJsonEncode,
                SkipDeserialization = skipDeserialization
            });
        }
    }
}
