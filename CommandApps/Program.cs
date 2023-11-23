
using CommandApps;
using CommandApps.Services;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

using IHost host = CreateHostBuilder(args).Build();
using var scope = host.Services.CreateScope();

var services = scope.ServiceProvider;

try
{
    services.GetRequiredService<Application>().Run(args); 
}
catch (Exception ex)
{
    Console.WriteLine(ex.Message);
}

//Registered all services with lifetime
static IHostBuilder CreateHostBuilder(string[] args)
{
    return Host.CreateDefaultBuilder(args)
        .ConfigureServices((_, services) =>
        {
            services.AddScoped<ITransaction, Transaction>();
            services.AddSingleton<Application>();
        });
}