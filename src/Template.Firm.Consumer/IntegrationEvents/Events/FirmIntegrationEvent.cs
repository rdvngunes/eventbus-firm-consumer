using System;
using Hurriyet.Emlak.EventBus;

namespace Template.Firm.Consumer.IntegrationEvents.Events
{
    public class FirmIntegrationEvent : IntegrationEvent
    {
        public FirmIntegrationEvent() : base("v1")
        {

        }

        public FirmIntegrationEvent(string version) : base(version)
        {
        }

        public FirmIntegrationEvent(Guid id, DateTime createDate, string version) : base(id, createDate, version)
        {
        }

        public FirmIntegrationEvent(string version, Guid id, DateTime creationDate) : base(version, id, creationDate)
        {
        }
        public int FirmId { get; set; }

    }
}
