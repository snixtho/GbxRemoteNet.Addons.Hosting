using GbxRemoteNet;
using Microsoft.Extensions.Options;

namespace GbxRemoteNet.Addons.Hosting;

public class InjectableGbxRemoteClient : GbxRemoteClient
{
    public InjectableGbxRemoteClient(IOptions<GbxRemoteHostConfiguration> config)
        : base(config.Value.Host, config.Value.Port, new GbxRemoteClientOptions
        {
            ConnectionRetries = config.Value.ConnectionRetries,
            ConnectionRetryTimeout = config.Value.ConnectionRetryTimeout,
            InvokeEventOnModeScriptMethodResponse = config.Value.InvokeEventOnModeScriptMethodResponse
        })
    { }
}