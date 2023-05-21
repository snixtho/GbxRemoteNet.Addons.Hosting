using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace GbxRemoteNet.Addons.Hosting;

public static class GbxRemoteHostBuilderExtensions
{
    public static IHostBuilder UseGbxRemote(this IHostBuilder builder, Action<HostBuilderContext, GbxRemoteHostConfiguration>? config=null)
    {
        return builder.ConfigureServices((context, services) =>
        {
            services.AddOptions<GbxRemoteHostConfiguration>();

            if (config != null)
            {
                services.Configure<GbxRemoteHostConfiguration>(x => config(context, x));
            }
            
            services.AddHostedService<GbxRemoteHostedService>();
            services.AddSingleton<GbxRemoteClient, InjectableGbxRemoteClient>();
        });
    }
}
