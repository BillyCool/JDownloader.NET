using System.Threading.Tasks;

namespace JDownloader.Namespace
{
    public interface ICaptchaForward
    {
        /// <summary>
        /// Creates a job for solving reCAPTCHA v2.
        /// </summary>
        /// <param name="siteKey">The site key of the reCAPTCHA.</param>
        /// <param name="siteToken">The site token of the reCAPTCHA.</param>
        /// <param name="siteDomain">The domain of the site where the reCAPTCHA is located.</param>
        /// <param name="reason">The reason for creating the job.</param>
        /// <returns>The ID of the created captcha job.</returns>
        Task<long> CreateJobRecaptchaV2(string siteKey, string siteToken, string siteDomain, string reason);

        /// <summary>
        /// Gets the result of a captcha job.
        /// </summary>
        /// <param name="captchaJobId">The ID of the captcha job.</param>
        /// <returns>The result of the captcha job.</returns>
        Task<string> GetResult(long captchaJobId);
    }
}
