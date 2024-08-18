using Template.Services.Domain.CrmContext.Request;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Template.Firm.Consumer.Repositories
{
    public interface ITemplateRepository
    {
        Task<UpsertCrmFirmRequest> GetFirmAsync(int firmId);
    }
}