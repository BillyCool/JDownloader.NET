using JDownloader.Model;

namespace JDownloader.Example;

public static class Program
{
    private const string AppKey = "MySampleApp123";
    private const string DeviceName = "JDownloader@BillyCool";
    private const string Email = "myjd@email.com";
    private const string Password = "myjdpassword";

    public static async Task Main(string[] _)
    {
        // Create the client
        JDownloaderClient jDownloaderClient = new(new JDownloaderClientOptions
        {
            AppKey = AppKey
        });

        // Connect
        Console.WriteLine("Logging in to MyJDownloader...");
        await jDownloaderClient.Connect(Email, Password);

        if (!jDownloaderClient.IsConnected)
        {
            Console.WriteLine("Failed to connect!");
            Environment.Exit(1);
        }

        Console.WriteLine($"Logged in to {Email}'s account");

        // Find and connect to target device
        DeviceList deviceList = await jDownloaderClient.ListDevices();
        DeviceData? targetDevice = deviceList.Devices.Find(d => d.Name == DeviceName);

        if (targetDevice != null)
        {
            jDownloaderClient.SetWorkingDevice(targetDevice);
            Console.WriteLine($"Connected to {DeviceName}");
        }
        else
        {
            Console.WriteLine($"Device {DeviceName} was not found");
        }

        // Setup a direct connection
        DirectConnectionInfos directConnectionInfo = await jDownloaderClient.Device.GetDirectConnectionInfos();
        if (directConnectionInfo.Infos.Count > 0)
        {
            Console.WriteLine("Settting up direct connection");
            jDownloaderClient.SetDirectConnectionInfo(directConnectionInfo.Infos[0]);
        }

        // Ping the device
        for (int i = 0; i < 5; i++)
        {
            Console.WriteLine($"Ping {i + 1}: {await jDownloaderClient.Device.Ping()}");
            await Task.Delay(1000);
        }

        // Disconnect
        Console.WriteLine("Press any key to disconnect");
        Console.ReadKey();

        Console.WriteLine("Disconnecting from JDownloader...");
        await jDownloaderClient.Disconnect();
    }
}
