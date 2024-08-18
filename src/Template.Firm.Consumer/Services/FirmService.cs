using Template.Core.Service;
using Microsoft.Extensions.Options;
using Newtonsoft.Json;
using RestSharp;
using System;
using System.Linq;
using System.Threading.Tasks;
using Template.Firm.Consumer.Configuration;
using Template.Firm.Consumer.Helper;
using Template.Firm.Consumer.Repositories;
using Serilog;
using Template.Services.Domain.CrmContext.Request;

namespace Template.Firm.Consumer.Services
{
    public class FirmService : IFirmService
    {
        private readonly ILogger _logger;
        private readonly ITemplateRepository _templateRepository;
        private readonly IRestClient _restClient;
        private readonly IOptions<FirmServiceConfig> _firmServiceConfig;
        private FirmConverter _converter = new FirmConverter();

        public FirmService(ILogger logger, ITemplateRepository templateRepository, IRestClient restClient, IOptions<FirmServiceConfig> firmServiceConfig)
        {
            _logger = logger;
            _templateRepository = templateRepository;
            _restClient = restClient;
            _firmServiceConfig = firmServiceConfig;
        }
        public async Task<bool> UpsertFirmAsync(int firmId)
        {
            _logger.Information("{Message} {Id}", "Fetching information", firmId);

            var firm = await _templateRepository.GetFirmAsync(firmId);

            if (firm == null)
            {
                _logger.Error("{Message} {Id}", "Firm is not found", firmId);
                return true;
            }
            _logger.Information("{Message} {Id}", Newtonsoft.Json.JsonConvert.SerializeObject(firm), firmId);

            firm = _converter.Convert(firm);

            return await UpsertFirmOnCrmAsync(firm);
        }

        public async Task<bool> UpsertFirmOnCrmAsync(UpsertCrmFirmRequest firm)
        {
            var client = new RestClient(_firmServiceConfig.Value.RootUrl);
            var request = new RestRequest(_firmServiceConfig.Value.Resource, Method.POST);
            request.RequestFormat = DataFormat.Json;
            request.AddBody(firm);

            var response = client.Post(request);
            var responseContent = JsonConvert.DeserializeObject<ServiceResponse<bool>>(response.Content);

            _logger.Information("{Message} {Id}", response.Content, firm.Id);

            if (!responseContent.Succeeded)
            {
                _logger.Error("{Message} {Id}", "Firm is not upserted.", firm.Id);

                return false;
            }
            _logger.Information("{Message} {Id}", "Firm is upserted successfully.", firm.Id);

            return true;
        }
    }
}