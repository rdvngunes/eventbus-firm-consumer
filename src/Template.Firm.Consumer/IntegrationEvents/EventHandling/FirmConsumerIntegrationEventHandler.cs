using System;
using System.Threading.Tasks;
using Template.Firm.Consumer.IntegrationEvents.Events;
using Template.Firm.Consumer.Services;
using Hurriyet.Emlak.EventBus;
using Serilog;

namespace Template.Firm.Consumer.IntegrationEvents.EventHandling
{
    public class FirmConsumerIntegrationEventHandler : IIntegrationEventHandler<FirmIntegrationEvent>
    {
        private readonly ILogger _logger;
        private readonly IFirmService _firmService;

        public FirmConsumerIntegrationEventHandler(ILogger logger, IFirmService firmService)
        {
            _logger = logger;
            _firmService = firmService;
        }

        public async Task<bool> Handle(FirmIntegrationEvent @event)
        {
            try
            {
                return await _firmService.UpsertFirmAsync(@event.FirmId);
            }
            catch (Exception e)
            {
				_logger.Error("{Exception} {Id}", e.Message, @event.FirmId);
                return false;
            }
        }
    }
}