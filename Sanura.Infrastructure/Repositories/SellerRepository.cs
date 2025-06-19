using Sanura.Core.Entities;
using Sanura.Core.Interfaces;
using Sanura.Core.Interfaces.Repositories;

namespace Sanura.Infrastructure.Repositories
{
    public class SellerRepository : ISellerRepository
    {
        private readonly IDbContext dbContext;

        public SellerRepository(IDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public async Task<Seller> GetAsync(string idSeller)
        {
            Seller sellerrCollection;

            sellerrCollection = await this.dbContext.QuerySingleAsync<Seller>("[Security].[ModuleGet]");

            return sellerrCollection;
        }
    }
}