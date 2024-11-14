using System.Threading.Tasks;

namespace JDownloader.Namespace
{
    public class CaptchaForward : BaseNamespace, ICaptchaForward
    {
        public override string Endpoint => "captchaforward";

        public CaptchaForward(JDownloaderClient jDownloaderClient) : base(jDownloaderClient) { }

        public Task<long> CreateJobRecaptchaV2(string siteKey, string siteToken, string siteDomain, string reason) =>
            PostRequestAsync<long>(ApiConstants.CaptchaForward.CreateJobRecaptchaV2, new object[] { siteKey, siteToken, siteDomain, reason });

        public Task<string> GetResult(long captchaJobId) =>
            PostRequestAsync<string>(ApiConstants.CaptchaForward.GetResult, new object[] { captchaJobId });
    }
}