namespace JDownloader.Model
{
    public enum CaptchaSkipRequest
    {
        SINGLE,
        BLOCK_HOSTER,
        BLOCK_ALL_CAPTCHAS,
        BLOCK_PACKAGE,
        REFRESH,
        STOP_CURRENT_ACTION,
        TIMEOUT
    }
}