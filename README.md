# JDownloader.NET
[![GitHub License](https://img.shields.io/github/license/BillyCool/JDownloader.NET)](LICENSE)
[![NuGet Version](https://img.shields.io/nuget/v/JDownloader.NET)](https://nuget.org/packages/JDownloader.NET)
[![NuGet Downloads](https://img.shields.io/nuget/dt/JDownloader.NET)](https://nuget.org/packages/JDownloader.NET)

## About

JDownloader.NET is a library that provides an interface to interact with the official JDownloader API. It has been written entirely from scratch, following the official JDownloader API documentation and Java source code.

The library targets .NET Standard 2.0 and .NET 10.

## Features

The vast majority of JDownloader namespaces and APIs are implemented:
- AccountsV2
- Captcha
- CaptchaForward
- Config
- Device
- Dialogs
- DownloadController
- DownloadEvents
- DownloadsV2
- Events
- Extensions
- Extraction
- Flash
- JD
- LinkCrawler
- LinkGrabberV2
- Log
- Plugins
- Polling
- Reconnect
- Session
- System
- Toolbar
- UI
- Update

## Installation

📦 [NuGet](https://nuget.org/packages/JDownloader.NET) or `dotnet add package JDownloader.NET`

## Usage

#### JDownloader Setup

Before using the library, you will need to register for a [MyJDownloader](https://my.jdownloader.org/) account and to setup JDownloader for remote API access.

1. Register for a [MyJDownloader](https://my.jdownloader.org/) account if you don't already have one.
1. In JDownloader, navigate to `Settings > MyJDownloader > Setup & Login`.
1. Enter you email, password, set a device name and click `Connect`.
1. Verify that the `Connection established. Great!` message appears.

#### Library Setup

All JDownloader.NET functionality is exposed through the `JDownloaderClient` class.

Start by create an instance of this class by passing a `JDownloaderClientOptions` instance and a unique application key:

```csharp
using JDownloader;
using JDownloader.Model;

// Setup the client
JDownloaderClient jDownloaderClient = new(new JDownloaderClientOptions
{
    AppKey = "MyAppKey"
});
```

Next you need to connect to your MyJDownloader account:

```csharp
await jDownloaderClient.Connect("Email", "Password");
```

You can verify that the connection was successful using the `IsConnected` property of `JDownloaderClient`. Once connected to your MyJDownloader account, you will need to set the working device, the device that the API will connect and work with. You can query for all connected devices and find the one with the device name you configured earlier:

```csharp
// Get a list of connected devices
DeviceList deviceList = await jDownloaderClient.ListDevices();

// Get the target device
DeviceData? targetDevice = deviceList.Devices.Find(d => d.Name == "MyDeviceName");

// If the device exists, set it as working device
if (targetDevice != null)
{
    jDownloaderClient.SetWorkingDevice(targetDevice);
}
```

You are now connected to your JDownloader running on your computer. Before you start using the available APIs, you may optionally setup a direct connection to the device, instead of going through the MyJDownloader servers:

```csharp
// Get a list of direct connections
DirectConnectionInfos directConnectionInfo = await jDownloaderClient.Device.GetDirectConnectionInfos();

// If any direction connections exist, connect to the first one
if (directConnectionInfo.Infos.Count > 0)
{
    jDownloaderClient.SetDirectConnectionInfo(directConnectionInfo.Infos[0]);
}
```

If the direct connection fails, the `JDownloaderClient` automatically falls back to using MyJDownloader's servers. You are now ready to start using the available namespaces and APIs. For example, you may use the `Device` namespace and the `Ping` API to ping your JDownloader:

```csharp
await jDownloaderClient.Device.Ping();
```

Once you're done, you may disconnect the session:

```csharp
await jDownloaderClient.Disconnect();
```