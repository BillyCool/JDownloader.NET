using JDownloader.Model;
using System.Collections.Generic;
using System.Text.Json;
using System.Threading.Tasks;

namespace JDownloader.Namespace
{
    public class Extraction : BaseNamespace, IExtraction
    {
        public override string Endpoint => "extraction";

        public Extraction(JDownloaderClient jDownloaderClient) : base(jDownloaderClient) { }

        public Task AddArchivePassword(string password) =>
            PostRequestAsync(ApiConstants.Extraction.AddArchivePassword, new object[] { password });

        public Task<bool> CancelExtraction(long controllerId) =>
            PostRequestAsync<bool>(ApiConstants.Extraction.CancelExtraction, new object[] { controllerId });

        public Task<ArchiveStatus> GetArchiveInfo(long[] linkIds, long[] packageIds) =>
            PostRequestAsync<ArchiveStatus>(ApiConstants.Extraction.GetArchiveInfo, new object[] { linkIds, packageIds });

        public Task<ArchiveSettings> GetArchiveSettings(long[] archiveIds) =>
            PostRequestAsync<ArchiveSettings>(ApiConstants.Extraction.GetArchiveSettings, new object[] { archiveIds });

        public Task<ArchiveStatus> GetQueue() =>
            PostRequestAsync<ArchiveStatus>(ApiConstants.Extraction.GetQueue);

        public Task<bool> SetArchiveSettings(string archiveId, ArchiveSettings archiveSettings) =>
            PostRequestAsync<bool>(ApiConstants.Extraction.SetArchiveSettings, new object[] { archiveId, JsonSerializer.Serialize(archiveSettings, JsonSerializerOptions) });

        public Task<Dictionary<string, bool?>> StartExtractionNow(long[] linkIds, long[] packageIds) =>
            PostRequestAsync<Dictionary<string, bool?>>(ApiConstants.Extraction.StartExtractionNow, new object[] { linkIds, packageIds });
    }
}