using System;
using System.Data.SqlClient;
using System.Threading.Tasks;
using Dapper;
using Template.Firm.Consumer.Configuration;
using Template.Services.Domain.CrmContext.Request;
using Microsoft.Extensions.Options;


namespace Template.Firm.Consumer.Repositories
{
    public class TemplateRepository : ITemplateRepository, IDisposable
    {
        private readonly IOptions<TemplateDbConfig> _templateDbOptions;
        private SqlConnection _sqlConnection;


        public TemplateRepository(IOptions<TemplateDbConfig> templateDbOptions)
        {
            _templateDbOptions = templateDbOptions;
        }

        public void Dispose()
        {
            if (_sqlConnection == null) return;
            _sqlConnection.Dispose();
            _sqlConnection = null;
        }

        public async Task<UpsertCrmFirmRequest> GetFirmAsync(int firmId)
        {
            var query = $@"select  * from testtable";

            using (_sqlConnection = new SqlConnection(_templateDbOptions.Value.ConnectionString))
            {
                    _sqlConnection.Open();
                    return await _sqlConnection.QueryFirstOrDefaultAsync<UpsertCrmFirmRequest>(query);
            }

        }
    }
}
