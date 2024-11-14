using JDownloader.Model;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace JDownloader.Namespace
{
    public class Dialogs : BaseNamespace, IDialogs
    {
        public override string Endpoint => "dialogs";

        public Dialogs(JDownloaderClient jDownloaderClient) : base(jDownloaderClient) { }

        public Task Answer(long dialogId, Dictionary<string, object> dialogAnswer) =>
            PostRequestAsync(ApiConstants.Dialogs.Answer, new object[] { dialogId, dialogAnswer });

        public Task<DialogInfo> Get(long dialogId, bool icon, bool properties) =>
            PostRequestAsync<DialogInfo>(ApiConstants.Dialogs.Get, new object[] { dialogId, icon, properties });

        public Task<DialogTypeInfo> GetTypeInfo(string dialogType) =>
            PostRequestAsync<DialogTypeInfo>(ApiConstants.Dialogs.GetTypeInfo, new object[] { dialogType });

        public Task<long[]> List() =>
            PostRequestAsync<long[]>(ApiConstants.Dialogs.List);
    }
}