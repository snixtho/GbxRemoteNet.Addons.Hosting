using GbxRemoteNet;
using GbxRemoteNet.Addons.Hosting;
using GbxRemoteNet.Events;
using Microsoft.Extensions.Logging;

namespace BasicExample;

public class PingCommandHandler : GbxRemoteServiceBase
{
    public PingCommandHandler(GbxRemoteClient client, ILogger<PingCommandHandler> logger) : base(client, logger)
    {
    }

    protected override Task ExecuteAsync(CancellationToken stoppingToken)
    {
        Client.OnPlayerChat += ClientOnOnPlayerChat;
        return Task.CompletedTask;
    }

    private async Task ClientOnOnPlayerChat(object sender, PlayerChatEventArgs e)
    {
        if (e.Text.Equals("/ping", StringComparison.InvariantCultureIgnoreCase))
        {
            await Client.ChatSendServerMessageAsync("Pong!");
        }
    }
}