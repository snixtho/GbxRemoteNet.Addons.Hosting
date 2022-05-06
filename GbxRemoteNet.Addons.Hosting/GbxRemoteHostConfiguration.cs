using GbxRemoteNet.Enums;

namespace GbxRemoteNet.Addons.Hosting;

public class GbxRemoteHostConfiguration
{
    public string Host { get; set; } = "127.0.0.1";
    public int Port { get; set; } = 5000;
    public string Login { get; set; } = "SuperAdmin";
    public string Password { get; set; } = "SuperAdmin";

    public int ConnectionRetries { get; set; } = 0;
    public int ConnectionRetryTimeout { get; set; } = 1000;
    public bool InvokeEventOnModeScriptMethodResponse { get; set; } = false;

    public CallbackType CallbacksEnabled { get; set; } = CallbackType.ModeScript | CallbackType.Checkpoints;
}