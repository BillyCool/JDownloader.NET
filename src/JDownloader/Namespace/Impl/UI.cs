using JDownloader.Model;
using System.Text.Json;
using System.Threading.Tasks;

namespace JDownloader.Namespace
{
    public class UI : BaseNamespace, IUI
    {
        public override string Endpoint => "ui";

        public UI(JDownloaderClient jDownloaderClient) : base(jDownloaderClient) { }

        public Task<MyJDMenuItem> GetMenu(Context context) =>
            PostRequestAsync<MyJDMenuItem>(ApiConstants.Ui.GetMenu, new object[] { JsonSerializer.Serialize(context, JsonSerializerOptions) });

        public Task<object> InvokeAction(Context context, string id, long[] linkIds, long[] packageIds) =>
            PostRequestAsync<object>(ApiConstants.Ui.InvokeAction, new object[] { JsonSerializer.Serialize(context, JsonSerializerOptions), id, linkIds, packageIds });
    }
}