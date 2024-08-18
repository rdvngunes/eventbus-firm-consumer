using System.IO;
using System.Threading.Tasks;
using Template.Firm.Consumer.Configuration;
using Template.Firm.Consumer.Infrastructure;
using Template.Firm.Consumer.IntegrationEvents.EventHandling;
using Template.Firm.Consumer.IntegrationEvents.Events;
using Template.Firm.Consumer.Repositories;
using Template.Firm.Consumer.Services;
using Hurriyet.Emlak.EventBus;
using Hurriyet.Emlak.EventBus.RabbitMq;
using Hurriyet.Emlak.EventBus.RabbitMq.Settings;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using RabbitMQ.Client;
using Serilog;
using RestSharp;

namespace Template.Firm.Consumer
{
    internal class Program
    {
        public static IConfigurationRoot Configuration { get; set; }

        private static async Task Main(string[] args)
        {
            var host = CreateHost(args);
            await host.Build().RunAsync();
        }

        private static IHostBuilder CreateHost(string[] args)
        {
            return new HostBuilder()
                .ConfigureHostConfiguration(configHost =>
                {
                    configHost.SetBasePath(Directory.GetCurrentDirectory());
                    configHost.AddJsonFile("hostsettings.json", true);
                    configHost.AddEnvironmentVariables("PREFIX_");
                    configHost.AddCommandLine(args);
                })
                .ConfigureAppConfiguration((hostContext, configApp) =>
                {
                    configApp.AddJsonFile("appsettings.json", true);
                    configApp.AddJsonFile(
                        $"appsettings.{hostContext.HostingEnvironment.EnvironmentName}.json",
                        true);
                    configApp.AddEnvironmentVariables("PREFIX_");
                    configApp.AddCommandLine(args);
                    Configuration = configApp.Build();
                })
                .ConfigureServices((hostContext, services) =>
                {
                    CreateConfig(hostContext, services);
                    services.AddSingleton<IHostedService, HostedService>();
                    services.AddTransient<IFirmService, FirmService>();
                    services.AddTransient<IRestClient, RestClient>();
                    services.AddSingleton<IEventBus, SimpleConsumerEventBus>();
                    services.AddTransient<ITemplateRepository, TemplateRepository>();
                    services
                        .AddTransient<IIntegrationEventHandler<FirmIntegrationEvent>,
                            FirmConsumerIntegrationEventHandler>();
                    services.AddSingleton<IConnectionFactory, SimpleConsumerRabbitMqConnectionFactory>();
                    services.AddSingleton<IRabbitMQPersistentConnection, SimpleRabbitMQPersistentConnection>();
                    services.AddSingleton((ILogger)new LoggerConfiguration()
                            .ReadFrom.ConfigurationSection(Configuration.GetSection("Serilog"))
                            .CreateLogger());
                });

        }


        private static void CreateConfig(HostBuilderContext hostContext, IServiceCollection services)
        {
            services.AddOptions();
            services.Configure<EventBusConnectionConfig>(opt => Configuration.GetSection("EventBusConnectionConfig").Bind(opt));
            services.Configure<FirmServiceConfig>(opt => Configuration.GetSection("FirmServiceConfig").Bind(opt));
            services.Configure<TemplateDbConfig>(opt => Configuration.GetSection("TemplateDbConfig").Bind(opt));
        }
    }
}