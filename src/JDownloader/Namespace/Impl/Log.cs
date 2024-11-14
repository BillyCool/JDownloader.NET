using JDownloader.Model;
using System.Collections.Generic;
using System.Text.Json;
using System.Threading.Tasks;

namespace JDownloader.Namespace
{
    public class Log : BaseNamespace, ILog
    {
        public override string Endpoint => "log";

        public Log(JDownloaderClient jDownloaderClient) : base(jDownloaderClient) { }

        public Task<List<LogFolder>> GetAvailableLogs() =>
            PostRequestAsync<List<LogFolder>>(ApiConstants.Log.GetAvailableLogs);

        public Task<string> SendLogFile(LogFolder[] logFolders) =>
            PostRequestAsync<string>(ApiConstants.Log.SendLogFile, new object[] { JsonSerializer.Serialize(logFolders, JsonSerializerOptions) });
    }
}