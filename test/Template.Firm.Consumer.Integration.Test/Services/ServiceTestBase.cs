using Template.Firm.Consumer.Configuration;
using Template.Firm.Consumer.Repositories;
using Template.Firm.Consumer.Services;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Options;
using Moq;
using System;
using Serilog;
namespace Template.Firm.Consumer.Integration.Test.Services
{
    public abstract class ServiceTestBase
    {
        public IConfigurationRoot Configuration { get; set; }
        public IFirmService FirmService;
        public Mock<ITemplateRepository> TemplateRepository { get; set; }
        public Mock<Serilog.ILogger> serilog { get; set; }

        public void StartService()
        {
            TemplateRepository = new Mock<ITemplateRepository>();
            serilog = new Mock<ILogger>();
            var firmServiceConfig = Options.Create(new FirmServiceConfig() { RootUrl = "http://localhost:5001", Resource = "/firm" });
            FirmService = new FirmService(serilog.Object, TemplateRepository.Object, null, firmServiceConfig);

        }
    }
}
