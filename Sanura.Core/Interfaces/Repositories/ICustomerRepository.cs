using Sanura.Core.Entities;

namespace Sanura.Core.Interfaces.Repositories
{
    public interface ICustomerRepository
    {
        Task<IEnumerable<Customer>> GetAsync(string idSeller);
    }
}