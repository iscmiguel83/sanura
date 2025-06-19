using Sanura.Core.Entities;

namespace Sanura.Core.Interfaces.Repositories
{
    public interface IInvoiceRepository
    {
        Task<IEnumerable<Invoice>> GetAsync(string idSeller);
    }
}