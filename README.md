# GbxRemoteNet.Addons.Hosting

This library adds hosting extensions for [GbxRemote.NET](https://github.com/EvoTM/GbxRemote.Net), making it easy to work with it using .NET Generic Host.

## Installation

You can use nuget:
```
Install-Package GbxRemoteNet.Addons.Hosting
```

## Usage
In the host builder call the `UseGbxRemote` extension method to configure GbxRemote.NET

```csharp
.UseGbxRemote((context, config) =>
{
    // most of these options have optional values set
    config.Host = "127.0.0.1";
    config.Port = 5000;
    config.Login = "SuperAdmin";
    config.Password = "SuperAdmin";

    config.ConnectionRetries = 3;
})
```

## Examples
Look in the [Samples](Samples/) directory for examples on the usage.