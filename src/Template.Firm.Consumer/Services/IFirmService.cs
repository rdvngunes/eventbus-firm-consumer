using Template.Services.Domain.CrmContext.Request;
using System.Threading.Tasks;

namespace Template.Firm.Consumer.Services
{
    public interface IFirmService
    {
        Task<bool> UpsertFirmAsync(int firmId);
        Task<bool> UpsertFirmOnCrmAsync(UpsertCrmFirmRequest firm);
    }
}