using Sanura.Core.Entities;

namespace Sanura.Core.Interfaces.Repositories
{
    public interface ISellerRepository
    {
        Task<Seller> GetAsync(string idSeller);
    }
}