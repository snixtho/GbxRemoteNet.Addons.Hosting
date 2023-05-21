using BasicExample;
using GbxRemoteNet.Addons.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

await Host.CreateDefaultBuilder(args)
    .ConfigureHostConfiguration(builder =>
    {
        builder.SetBasePath(Directory.GetCurrentDirectory());
        builder.AddJsonFile("config.json");
    })
    .UseGbxRemote((context, config) =>
    {
        config.Host = context.Configuration["Host"];
        config.Port = context.Configuration.GetValue<int>("Port");
        config.Login = context.Configuration["Login"];
        config.Password = context.Configuration["Password"];

        config.ConnectionRetries = 3;
    })
    .ConfigureServices((context, services) =>
    {
        services.AddHostedService<PingCommandHandler>();
    })
    .Build()
    .RunAsync();
