using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;

namespace GbxRemoteNet.Addons.Hosting;

public abstract class GbxRemoteServiceBase : BackgroundService
{
    protected GbxRemoteClient Client { get; }
    protected ILogger Logger { get; }
    
    protected GbxRemoteServiceBase(GbxRemoteClient client, ILogger logger)
    {
        Client = client;
        Logger = logger;
    }
    
    protected abstract override Task ExecuteAsync(CancellationToken stoppingToken);
}