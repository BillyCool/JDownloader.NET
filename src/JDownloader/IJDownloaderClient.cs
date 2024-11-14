using JDownloader.Model;
using JDownloader.Namespace;
using System.Threading.Tasks;

namespace JDownloader
{
    public interface IJDownloaderClient
    {
        /// <summary>
        /// Connect to the JDownloader API
        /// </summary>
        /// <param name="email">The JDownloader account email address</param>
        /// <param name="password">The JDownloader account password</param>
        /// <returns>True if successful, otherwise false</returns>
        Task Connect(string email, string password);

        /// <summary>
        /// Reconnect to the JDownloader API. Call if the session becomes invalid (for example due to an IP change).
        /// </summary>
        /// <returns>True if successful, otherwise false</returns>
        Task ReConnect();

        /// <summary>
        /// Disconnect from the JDownloader API. This will invalidate your session. You have to call <see cref="Connect"/> to get a new session afterwards.
        /// </summary>
        /// <returns></returns>
        Task Disconnect();

        /// <summary>
        /// Get a list of online devices
        /// </summary>
        /// <returns></returns>
        Task<DeviceList> ListDevices();

        /// <summary>
        /// Sets the device to interact with.
        /// </summary>
        /// <param name="device">The device. See <see cref="ListDevices"/>.</param>
        void SetWorkingDevice(DeviceData device);

        /// <summary>
        /// Sets the device ID to interact with.
        /// </summary>
        /// <param name="deviceId">The device ID. See <see cref="ListDevices"/>.</param>
        void SetWorkingDevice(string deviceId);

        /// <summary>
        /// Set the direct connection info for the currently selected device
        /// </summary>
        /// <param name="directConnectionInfo">The direct connection info. See <see cref="Device.GetDirectConnectionInfos"/>.</param>
        /// <param name="autoFallback">True if the application should fallback to JD server API in case of errors, otherwise false</param>
        void SetDirectConnectionInfo(DirectConnectionInfo directConnectionInfo, bool autoFallback = true);

        /// <summary>
        /// Clears the direct connection info for the currently selected device and send all requests to the JD server API
        /// </summary>
        void ClearDirectConnectionInfo();

        #region Namespaces

        IAccountsV2 AccountsV2 { get; set; }

        ICaptcha Captcha { get; set; }

        ICaptchaForward CaptchaForward { get; set; }

        IConfig Config { get; set; }

        IDevice Device { get; set; }

        IDialogs Dialogs { get; set; }

        IDownloadController DownloadController { get; set; }

        IDownloadEvents DownloadEvents { get; set; }

        IDownloadsV2 DownloadsV2 { get; set; }

        IEvents Events { get; set; }

        IExtensions Extensions { get; set; }

        IExtraction Extraction { get; set; }

        IFlash Flash { get; set; }

        IJD JD { get; set; }

        ILinkCrawler LinkCrawler { get; set; }

        ILinkGrabberV2 LinkGrabberV2 { get; set; }

        ILog Log { get; set; }

        IPlugins Plugins { get; set; }

        IPolling Polling { get; set; }

        IReconnect Reconnect { get; set; }

        ISession Session { get; set; }

        ISystem System { get; set; }

        IToolbar Toolbar { get; set; }

        IUI UI { get; set; }

        IUpdate Update { get; set; }

        #endregion Namespaces
    }
}
