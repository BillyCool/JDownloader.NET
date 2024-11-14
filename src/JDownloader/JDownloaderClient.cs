using JDownloader.Model;
using JDownloader.Namespace;
using System;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Web;

namespace JDownloader
{
    public class JDownloaderClient : IJDownloaderClient
    {
        private readonly JDownloaderClientOptions _jDownloaderClientOptions;

        private readonly SessionInfo _sessionInfo;

        private readonly DeviceInfo _deviceInfo;

        private readonly HttpClient _httpClient;

        private readonly JsonSerializerOptions _jsonSerializerOptions;

        public JDownloaderClient(JDownloaderClientOptions jDownloaderClientOptions)
        {
            jDownloaderClientOptions.Validate();
            _jDownloaderClientOptions = jDownloaderClientOptions;

            _sessionInfo = new SessionInfo();
            _deviceInfo = new DeviceInfo();
            _httpClient = new HttpClient()
            {
                BaseAddress = new Uri(ApiConstants.SERVER_ROOT),
                Timeout = TimeSpan.FromSeconds(120)
            };

            _jsonSerializerOptions = new JsonSerializerOptions(JsonSerializerDefaults.Web);
            _jsonSerializerOptions.Converters.Add(new JsonStringEnumConverter());

            #region Namespaces

            AccountsV2 = new AccountsV2(this);
            Captcha = new Captcha(this);
            CaptchaForward = new CaptchaForward(this);
            Config = new Config(this);
            Device = new Device(this);
            Dialogs = new Dialogs(this);
            DownloadController = new DownloadController(this);
            DownloadEvents = new DownloadEvents(this);
            DownloadsV2 = new DownloadsV2(this);
            Events = new Events(this);
            Extensions = new Extensions(this);
            Extraction = new Extraction(this);
            Flash = new Flash(this);
            JD = new JD(this);
            LinkCrawler = new LinkCrawler(this);
            LinkGrabberV2 = new LinkGrabberV2(this);
            Log = new Log(this);
            Plugins = new Plugins(this);
            Polling = new Polling(this);
            Reconnect = new Reconnect(this);
            Session = new Session(this);
            System = new Namespace.System(this);
            Toolbar = new Toolbar(this);
            UI = new UI(this);
            Update = new Update(this);

            #endregion Namespaces
        }

        #region Namespaces

        public IAccountsV2 AccountsV2 { get; set; }

        public ICaptcha Captcha { get; set; }

        public ICaptchaForward CaptchaForward { get; set; }

        public IConfig Config { get; set; }

        public IDevice Device { get; set; }

        public IDialogs Dialogs { get; set; }

        public IDownloadController DownloadController { get; set; }

        public IDownloadEvents DownloadEvents { get; set; }

        public IDownloadsV2 DownloadsV2 { get; set; }

        public IEvents Events { get; set; }

        public IExtensions Extensions { get; set; }

        public IExtraction Extraction { get; set; }

        public IFlash Flash { get; set; }

        public IJD JD { get; set; }

        public ILinkCrawler LinkCrawler { get; set; }

        public ILinkGrabberV2 LinkGrabberV2 { get; set; }

        public ILog Log { get; set; }

        public IPlugins Plugins { get; set; }

        public IPolling Polling { get; set; }

        public IReconnect Reconnect { get; set; }

        public ISession Session { get; set; }

        public ISystem System { get; set; }

        public IToolbar Toolbar { get; set; }

        public IUI UI { get; set; }

        public IUpdate Update { get; set; }

        #endregion Namespaces

        public bool IsConnected => !string.IsNullOrEmpty(_sessionInfo.SessionToken);

        public bool IsDeviceSelected => !string.IsNullOrEmpty(_deviceInfo.DeviceId);

        public async Task Connect(string email, string password)
        {
            // Already connected
            if (IsConnected) return;

            // Validate credentials
            if (email is null) throw new ArgumentNullException(nameof(email));
            if (password is null) throw new ArgumentNullException(nameof(password));

            // Calculate the Login and Device secret
            //email = email.ToLowerInvariant();
            byte[] loginSecret = _jDownloaderClientOptions.GetLoginSecret(email, password);
            _sessionInfo.DeviceSecret = _jDownloaderClientOptions.GetDeviceSecret(email, password);

            // Connect
            string action = string.Format(ApiConstants.Server.Connect, HttpUtility.UrlEncode(email), HttpUtility.UrlEncode(_jDownloaderClientOptions.AppKey));

            ConnectResponse response = await GetRequestAsync<ConnectResponse>(new GetRequestArg(action, loginSecret));

            _sessionInfo.SessionToken = response.SessionToken;
            _sessionInfo.RegainToken = response.RegainToken;
            _sessionInfo.ServerEncryptionToken = IsConnected ? JDownloaderCrypto.GetEncryptionToken(loginSecret, response.SessionToken) : default;
            _sessionInfo.DeviceEncryptionToken = IsConnected ? JDownloaderCrypto.GetEncryptionToken(_sessionInfo.DeviceSecret, response.SessionToken) : default;
        }
        public async Task ReConnect()
        {
            if (!IsConnected) throw new NotConnectedException();

            string action = string.Format(ApiConstants.Server.Reconnect, HttpUtility.UrlEncode(_sessionInfo.SessionToken), HttpUtility.UrlEncode(_sessionInfo.RegainToken));

            ConnectResponse response = await GetRequestAsync<ConnectResponse>(new GetRequestArg(action, _sessionInfo.ServerEncryptionToken));

            _sessionInfo.SessionToken = response.SessionToken;
            _sessionInfo.RegainToken = response.RegainToken;
            _sessionInfo.ServerEncryptionToken = IsConnected ? JDownloaderCrypto.GetEncryptionToken(_sessionInfo.ServerEncryptionToken, response.SessionToken) : default;
            _sessionInfo.DeviceEncryptionToken = IsConnected ? JDownloaderCrypto.GetEncryptionToken(_sessionInfo.DeviceSecret, response.SessionToken) : default;
        }
        public async Task Disconnect()
        {
            if (!IsConnected) return;

            string action = string.Format(ApiConstants.Server.Disconnect, HttpUtility.UrlEncode(_sessionInfo.SessionToken));

            await GetRequestAsync<DisconnectResponse>(new GetRequestArg(action, _sessionInfo.ServerEncryptionToken));

            _sessionInfo.Clear();
        }
        public async Task<DeviceList> ListDevices()
        {
            if (!IsConnected) throw new NotConnectedException();

            string action = string.Format(ApiConstants.Server.ListDevices, HttpUtility.UrlEncode(_sessionInfo.SessionToken));

            return await GetRequestAsync<DeviceList>(new GetRequestArg(action, _sessionInfo.ServerEncryptionToken));
        }

        public void SetWorkingDevice(DeviceData device)
        {
            _deviceInfo.DeviceId = device.Id;
            ClearDirectConnectionInfo();
        }

        public void SetWorkingDevice(string deviceId)
        {
            _deviceInfo.DeviceId = deviceId;
            ClearDirectConnectionInfo();
        }

        public void SetDirectConnectionInfo(DirectConnectionInfo directConnectionInfo, bool autoFallback = true)
        {
            _deviceInfo.IP = directConnectionInfo.IP;
            _deviceInfo.Port = directConnectionInfo.Port;
            _deviceInfo.AutoFallback = autoFallback;
        }

        public void ClearDirectConnectionInfo()
        {
            _deviceInfo.IP = null;
            _deviceInfo.Port = null;
            _deviceInfo.AutoFallback = false;
        }

        #region Request helpers

        private async Task<T> GetRequestAsync<T>(GetRequestArg arg) where T : BaseApiModel
        {
            // Attach request ID
            long requestId = GetUniqueRequestId();
            string action = arg.Action + $"&rid={requestId}";

            // Append signature
            string signature = JDownloaderCrypto.GetSignature(action, arg.Key);
            action += $"&signature={signature}";

            // Send request
            try
            {
                using (HttpResponseMessage response = await _httpClient.GetAsync(action))
                {
                    string result = await response.Content.ReadAsStringAsync();

                    if (response?.StatusCode == HttpStatusCode.OK)
                    {
                        string decryptedResult = await JDownloaderCrypto.Decrypt(result, arg.Key);

                        T decryptedData = JsonSerializer.Deserialize<T>(decryptedResult, _jsonSerializerOptions);

                        // Validate request ID
                        return decryptedData?.RequestId != requestId ? throw new InvalidRequestIdException() : decryptedData;
                    }
                    else
                    {
                        GenericApiError decryptedError = JsonSerializer.Deserialize<GenericApiError>(result, _jsonSerializerOptions);
                        throw new MyJDownloaderException(decryptedError.ToString());
                    }
                }
            }
            catch (Exception ex)
            {
                throw new MyJDownloaderException(ex.Message);
            }
        }

        internal async Task<T> PostRequestAsync<T>(PostRequestArg arg)
        {
            ValidateConfiguration();

            try
            {
                string baseUrl = _deviceInfo.HasDirectConnectionInfo ? _deviceInfo.DirectConnectionUrl : ApiConstants.SERVER_ROOT;
                return await PostRequestInternalAsync<T>(baseUrl, arg);
            }
            catch (MyJDownloaderException) when (_deviceInfo.HasDirectConnectionInfo)
            {
                // If direct connection was used and fallback is enabled, retry with server root
                return _deviceInfo.AutoFallback
                    ? await PostRequestInternalAsync<T>(ApiConstants.SERVER_ROOT, arg)
                    : throw new DirectConnectionException();
            }
        }

        private async Task<T> PostRequestInternalAsync<T>(string baseUrl, PostRequestArg arg)
        {
            long requestId = GetUniqueRequestId();

            GenericApiRequest request = new GenericApiRequest()
            {
                Params = arg.Param,
                RequestId = requestId,
                Url = arg.Action
            };

            string json = JsonSerializer.Serialize(request, _jsonSerializerOptions);
            string encryptedJson = await JDownloaderCrypto.Encrypt(json, _sessionInfo.DeviceEncryptionToken);

            try
            {
                StringContent content = new StringContent(encryptedJson, Encoding.UTF8, "application/aesjson-jd");
                using (HttpResponseMessage response = await _httpClient.PostAsync(GetFormattedPostUrl(baseUrl, arg.Action), content))
                {
                    string decryptedResult = await GetDecryptedResponseBody(response);

                    if (response.StatusCode == HttpStatusCode.OK)
                    {
                        if (arg.DoubleJsonDecode)
                        {
                            decryptedResult = DoubleJsonDecode(decryptedResult);
                        }

                        if (arg.SkipDeserialization)
                        {
                            return (T)Convert.ChangeType(decryptedResult, typeof(T));
                        }

                        GenericApiResponse<T> decryptedData = JsonSerializer.Deserialize<GenericApiResponse<T>>(decryptedResult, _jsonSerializerOptions);

                        return decryptedData.IsValidRequest(requestId)
                            ? decryptedData.Data
                            : throw new InvalidRequestIdException();
                    }
                    else
                    {
                        GenericApiError decryptedError = JsonSerializer.Deserialize<GenericApiError>(decryptedResult, _jsonSerializerOptions);
                        throw new MyJDownloaderException(decryptedError.ToString());
                    }
                }
            }
            catch (Exception ex)
            {
                throw new MyJDownloaderException(ex.Message);
            }
        }

        private void ValidateConfiguration()
        {
            if (!IsConnected) throw new NotConnectedException();
            if (!IsDeviceSelected) throw new DeviceNotSelectedException();
        }

        private string GetFormattedPostUrl(string baseUrl, string action) => $"{baseUrl}/t_{HttpUtility.UrlEncode(_sessionInfo.SessionToken)}_{HttpUtility.UrlEncode(_deviceInfo.DeviceId)}{action}";

        private static long GetUniqueRequestId() => DateTimeOffset.UtcNow.ToUnixTimeMilliseconds();

        private static string DoubleJsonDecode(string json)
        {
            return json
                .Replace("\\r", string.Empty).Replace("\\n", Environment.NewLine)
                .Replace("\\\"", "\"").Replace("\\", string.Empty)
                .Replace("\"{", "{").Replace("}\"", "}")
                .Replace("\"[", "[").Replace("]\"", "]");
        }

        private async Task<string> GetDecryptedResponseBody(HttpResponseMessage response)
        {
            string result = await response.Content.ReadAsStringAsync();

            try
            {
                return await JDownloaderCrypto.Decrypt(result, _sessionInfo.DeviceEncryptionToken);
            }
            catch (FormatException)
            {
                return result;
            }
        }

        #endregion Request helpers
    }
}
