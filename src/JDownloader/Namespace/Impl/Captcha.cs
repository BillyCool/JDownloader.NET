using JDownloader.Model;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace JDownloader.Namespace
{
    public class Captcha : BaseNamespace, ICaptcha
    {
        public override string Endpoint => "captcha";

        public Captcha(JDownloaderClient jDownloaderClient) : base(jDownloaderClient) { }

        public Task<string> Get(long captchaId) =>
            PostRequestAsync<string>(ApiConstants.Captcha.Get, new object[] { captchaId });

        public Task<CaptchaJob> GetCaptchaJob(long captchaJobId) =>
            PostRequestAsync<CaptchaJob>(ApiConstants.Captcha.GetCaptchaJob, new object[] { captchaJobId });

        public Task<IEnumerable<CaptchaJob>> List() =>
            PostRequestAsync<IEnumerable<CaptchaJob>>(ApiConstants.Captcha.List);

        public Task<bool> Skip(long captchaJobId, CaptchaSkipRequest skipType) =>
            PostRequestAsync<bool>(ApiConstants.Captcha.Skip, new object[] { captchaJobId, skipType.ToString() });

        public Task<bool> Solve(long captchaId, string captchaAnswer) =>
            PostRequestAsync<bool>(ApiConstants.Captcha.Solve, new object[] { captchaId, captchaAnswer });
    }
}