# AnyStatus API

A library that contains the classes, interfaces and utilities needed for developing AnyStatus plugins.

[![Build status](https://ci.appveyor.com/api/projects/status/74kcwc63k0r2ajdj?svg=true)](https://ci.appveyor.com/project/AnyStatus/api)

## How it works

AnyStatus communicates with plugins using the API library. During startup, AnyStatus scans assemblies in the installation directory and registers all plugins.

A plugin is a set of classes that instruct AnyStatus how to display it in the dashboard and which features the plugin supports.

![AnyStatus Plugins](https://github.com/AnyStatus/anystatus.github.io/blob/master//assets/posts/2017-06-22-all-plugins-are-now-open-source/plugins-flow-chart.png)

## Plugins Library

Check out the complete plugins library at https://github.com/AnyStatus/Plugins

## Plugin Example

A class that defines the plugin.

```csharp
[DisplayName("Ping")]
[DisplayColumn("Network")]
[Description("Test the reachability of a host")]
public class Ping : Plugin, IMonitored
{
    [Required]
    [Category("Ping")]
    [Description("Host Name or IP Address")]
    public string Host { get; set; }
}
```

A class that handles a monitor health check.

```csharp
public class Pong : IMonitor<Ping>
{
    public void Handle(Ping myPing)
    {
        using (var ping = new System.Net.NetworkInformation.Ping())
        {
            var pong = ping.Send(myPing.Host);
                
            if (pong.Status == IPStatus.Success)
                ping.State = State.Ok;
            else
                ping.State = State.Failed;
        }
    }
}
```
