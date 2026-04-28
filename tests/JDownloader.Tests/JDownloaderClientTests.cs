using JDownloader.Model;
using System.Net;
using System.Reflection;
using Xunit;

namespace JDownloader.Tests;

public class JDownloaderClientTests
{
    [Fact]
    public void Validate_ThrowsWhenAppKeyMissing()
    {
        JDownloaderClientOptions options = new();

        ArgumentNullException exception = Assert.Throws<ArgumentNullException>(options.Validate);

        Assert.Equal("AppKey", exception.ParamName);
    }

    [Fact]
    public void Constructor_ThrowsWhenOptionsAreNull()
    {
        ArgumentNullException exception = Assert.Throws<ArgumentNullException>(() => new JDownloaderClient(null!));

        Assert.Equal("jDownloaderClientOptions", exception.ParamName);
    }

    [Fact]
    public void Constructor_ThrowsWhenHttpClientIsNull()
    {
        ArgumentNullException exception = Assert.Throws<ArgumentNullException>(() => new JDownloaderClient(CreateValidOptions(), null!));

        Assert.Equal("httpClient", exception.ParamName);
    }

    [Fact]
    public void Constructor_UsesIndependentSerializerOptionsPerClient()
    {
        using JDownloaderClient first = new(CreateValidOptions());
        using JDownloaderClient second = new(CreateValidOptions());

        Assert.NotSame(first.SerializerOptions, second.SerializerOptions);
    }

    [Fact]
    public void SetWorkingDevice_SetsDeviceSelectionState()
    {
        using JDownloaderClient client = new(CreateValidOptions());

        Assert.False(client.IsDeviceSelected);

        client.SetWorkingDevice("device-id");

        Assert.True(client.IsDeviceSelected);
    }

    [Fact]
    public async Task Dispose_DisposesOwnedHttpClient()
    {
        using JDownloaderClient client = new(CreateValidOptions());
        HttpClient httpClient = GetHttpClient(client);

        client.Dispose();

        await Assert.ThrowsAsync<ObjectDisposedException>(() => httpClient.GetAsync("https://example.test", TestContext.Current.CancellationToken));
    }

    [Fact]
    public async Task Dispose_DoesNotDisposeInjectedHttpClient()
    {
        TrackingHttpMessageHandler handler = new();
        using HttpClient httpClient = new(handler);
        using JDownloaderClient client = new(CreateValidOptions(), httpClient);

        client.Dispose();

        using HttpResponseMessage response = await httpClient.GetAsync("https://example.test/ping", TestContext.Current.CancellationToken);

        Assert.Equal(HttpStatusCode.OK, response.StatusCode);
        Assert.False(handler.Disposed);
    }

    [Fact]
    public void Constructor_UsesInjectedHttpClientInstance()
    {
        using HttpClient httpClient = new(new TrackingHttpMessageHandler());
        using JDownloaderClient client = new(CreateValidOptions(), httpClient);

        Assert.Same(httpClient, GetHttpClient(client));
    }

    [Fact]
    public async Task GetRequestAsync_UsesServerRootWithoutBaseAddress()
    {
        byte[] key = CreateToken();
        RecordingHttpMessageHandler handler = new(async request =>
        {
            string requestUri = request.RequestUri!.ToString();
            string rid = requestUri.Split("rid=")[1].Split('&')[0];
            string payload = await JDownloaderCrypto.Encrypt($"{{\"rid\":{rid}}}", key);

            return new HttpResponseMessage(HttpStatusCode.OK)
            {
                Content = new StringContent(payload)
            };
        });

        using HttpClient httpClient = new(handler);
        using JDownloaderClient client = new(CreateValidOptions(), httpClient);

        MethodInfo method = typeof(JDownloaderClient).GetMethod("GetRequestAsync", BindingFlags.Instance | BindingFlags.NonPublic)!;
        GetRequestArg arg = new("/my/listdevices?sessiontoken=test-session", key);

        Task<TestApiModel> task = (Task<TestApiModel>)method.MakeGenericMethod(typeof(TestApiModel)).Invoke(client, [arg])!;
        TestApiModel result = await task;

        Assert.NotNull(result);
        Assert.StartsWith($"{ApiConstants.SERVER_ROOT}{arg.Action}&rid=", handler.LastRequestUri!.ToString());
    }

    [Fact]
    public async Task PostRequestAsync_UsesServerRootWhenNoDirectConnectionInfo()
    {
        byte[] deviceToken = CreateToken();
        RecordingHttpMessageHandler handler = new(async _ =>
        {
            string payload = await JDownloaderCrypto.Encrypt("{\"rid\":-1,\"data\":\"ok\"}", deviceToken);
            return new HttpResponseMessage(HttpStatusCode.OK)
            {
                Content = new StringContent(payload)
            };
        });

        using HttpClient httpClient = new(handler);
        using JDownloaderClient client = new(CreateValidOptions(), httpClient);
        client.SetWorkingDevice("device-id");
        SetSessionState(client, "session-token", deviceToken);

        string result = await client.PostRequestAsync<string>(new PostRequestArg
        {
            Action = "/test/action",
            Param = Array.Empty<object>()
        });

        Assert.Equal("ok", result);
        Assert.Equal($"{ApiConstants.SERVER_ROOT}/t_session-token_device-id/test/action", handler.LastRequestUri!.ToString());
    }

    private static JDownloaderClientOptions CreateValidOptions() => new()
    {
        AppKey = "app-key"
    };

    private static HttpClient GetHttpClient(JDownloaderClient client)
    {
        FieldInfo field = typeof(JDownloaderClient).GetField("_httpClient", BindingFlags.Instance | BindingFlags.NonPublic)!;
        return (HttpClient)field.GetValue(client)!;
    }

    private static byte[] CreateToken()
    {
        byte[] token = new byte[32];

        for (int i = 0; i < token.Length; i++)
        {
            token[i] = (byte)(i + 1);
        }

        return token;
    }

    private static void SetSessionState(JDownloaderClient client, string sessionToken, byte[] deviceToken)
    {
        FieldInfo field = typeof(JDownloaderClient).GetField("_sessionInfo", BindingFlags.Instance | BindingFlags.NonPublic)!;
        SessionInfo sessionInfo = (SessionInfo)field.GetValue(client)!;
        sessionInfo.SessionToken = sessionToken;
        sessionInfo.DeviceEncryptionToken = deviceToken;
    }

    private sealed class RecordingHttpMessageHandler(Func<HttpRequestMessage, Task<HttpResponseMessage>> responseFactory) : HttpMessageHandler
    {
        private readonly Func<HttpRequestMessage, Task<HttpResponseMessage>> _responseFactory = responseFactory;

        public Uri? LastRequestUri { get; private set; }

        protected override async Task<HttpResponseMessage> SendAsync(HttpRequestMessage request, CancellationToken cancellationToken)
        {
            LastRequestUri = request.RequestUri;
            return await _responseFactory(request);
        }
    }

    private sealed class TestApiModel : BaseApiModel;

    private sealed class TrackingHttpMessageHandler : HttpMessageHandler
    {
        public bool Disposed { get; private set; }

        protected override Task<HttpResponseMessage> SendAsync(HttpRequestMessage request, CancellationToken cancellationToken)
        {
            return Task.FromResult(new HttpResponseMessage(HttpStatusCode.OK)
            {
                Content = new StringContent("ok")
            });
        }

        protected override void Dispose(bool disposing)
        {
            Disposed = true;
            base.Dispose(disposing);
        }
    }
}
