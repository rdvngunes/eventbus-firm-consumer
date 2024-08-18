using Template.Firm.Consumer.Repositories;
using Template.Firm.Consumer.Services;
using Moq;
using Serilog;
using NUnit.Framework;
using System.Threading.Tasks;
using Template.Services.Domain.CrmContext.Request;

namespace Template.Firm.Consumer.Unit.Test
{
    public class FirmServiceTest
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public async Task It_Should_Return_True_When_Firm_Is_Not_Exist()
        {
            //Given
            UpsertCrmFirmRequest firmRequest = null;
            var seriLog = new Mock<ILogger>();
            var templateRepository = new Mock<ITemplateRepository>();

            var firmService = new FirmService(seriLog.Object, templateRepository.Object, null, null);
            templateRepository.Setup(client => client.GetFirmAsync(33417000)).Returns(() => Task.FromResult(firmRequest));

            //when
            var result = await firmService.UpsertFirmAsync(33417000);

            //Then
            Assert.True(result);
        }
    }
}