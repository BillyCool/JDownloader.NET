using JDownloader.Model;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace JDownloader.Namespace
{
    public interface ICaptcha
    {
        /// <summary>
        /// Gets a captcha image by its ID in Base64 format
        /// </summary>
        /// <param name="captchaId">The captcha job ID</param>
        /// <returns></returns>
        Task<string> Get(long captchaId);

        /// <summary>
        /// Gets a captcha job by its ID
        /// </summary>
        /// <param name="captchaJobId">The captcha job ID</param>
        /// <returns></returns>
        Task<CaptchaJob> GetCaptchaJob(long captchaJobId);

        /// <summary>
        /// Gets a list of all captcha jobs
        /// </summary>
        /// <returns></returns>
        Task<IEnumerable<CaptchaJob>> List();

        /// <summary>
        /// Skips a captcha job by its ID
        /// </summary>
        /// <param name="captchaJobId">The captcha job ID</param>
        /// <param name="skipType">The skip type</param>
        /// <returns></returns>
        Task<bool> Skip(long captchaJobId, CaptchaSkipRequest skipType);

        /// <summary>
        /// Solves a captcha by its ID
        /// </summary>
        /// <param name="captchaId">The captcha job ID</param>
        /// <param name="captchaAnswer">The captcha answer. Based on the captcha type, either a <see cref="string"/>,
        /// or a JSON serialized <see cref="ClickedPoint"/> or <see cref="MultiClickedPoint"/>.</param>
        /// <returns></returns>
        Task<bool> Solve(long captchaId, string captchaAnswer);
    }
}
