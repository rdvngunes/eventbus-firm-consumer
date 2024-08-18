using System.Threading;
using System.Threading.Tasks;
using Template.Firm.Consumer.IntegrationEvents.Events;
using Hurriyet.Emlak.EventBus;
using Microsoft.Extensions.Hosting;
using Serilog;

namespace Template.Firm.Consumer
{
    public class HostedService : IHostedService
    {
        private readonly IEventBus _eventBus;
        private readonly IIntegrationEventHandler<FirmIntegrationEvent> _integrationEventHandler;
        private readonly ILogger _logger;

        public HostedService(ILogger logger,
            IIntegrationEventHandler<FirmIntegrationEvent> integrationEventHandler, IEventBus eventBus)
        {
            _logger = logger;
            _integrationEventHandler = integrationEventHandler;
            _eventBus = eventBus;
        }

        public Task StartAsync(CancellationToken cancellationToken)
        {
            _eventBus.Subscribe(_integrationEventHandler);
            _logger.Information("Consumer is started.");

            return Task.CompletedTask;
        }

        public Task StopAsync(CancellationToken cancellationToken)
        {
            _logger.Information("Consumer is ended.");
            return Task.CompletedTask;
        }
    }
}