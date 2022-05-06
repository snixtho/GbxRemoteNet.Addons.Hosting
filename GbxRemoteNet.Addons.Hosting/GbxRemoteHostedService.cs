using GbxRemoteNet;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;

namespace GbxRemoteNet.Addons.Hosting;

public class GbxRemoteHostedService : IHostedService
{
    private ILogger<GbxRemoteHostedService> _logger;
    private IOptions<GbxRemoteHostConfiguration> _config;
    private GbxRemoteClient _client;

    public GbxRemoteHostedService(ILogger<GbxRemoteHostedService> logger, IOptions<GbxRemoteHostConfiguration> config, GbxRemoteClient client)
    {
        _logger = logger;
        _config = config;
        _client = client;
    }
    
    public async Task StartAsync(CancellationToken cancellationToken)
    {
        _logger.LogInformation("GbxRemote.NET hosted service starting");

        try
        {
            await _client.LoginAsync(_config.Value.Login, _config.Value.Password).WaitAsync(cancellationToken);
            await _client.EnableCallbackTypeAsync(_config.Value.CallbacksEnabled).WaitAsync(cancellationToken);
        }
        catch (OperationCanceledException)
        {
            _logger.LogWarning("GbxRemote.NET startup aborted");
        }
    }

    public async Task StopAsync(CancellationToken cancellationToken)
    {
        _logger.LogInformation("GbxRemote.NET hosted service stopping");
        try
        {
            await _client.DisconnectAsync().WaitAsync(cancellationToken);
        }
        catch (OperationCanceledException)
        {
            _logger.LogCritical("Failed to stop GbxRemote.NET hosted service, probably deadlocked");
        }
    }
}