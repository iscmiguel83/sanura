using Sanura.Core.Entities;
using Sanura.Core.Interfaces;
using Sanura.Core.Interfaces.Repositories;

namespace Sanura.Infrastructure.Repositories
{
    public class InvoiceRepository : IInvoiceRepository
    {
        private readonly IDbContext dbContext;

        public InvoiceRepository(IDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public async Task<IEnumerable<Invoice>> GetAsync(string idSeller)
        {
            IEnumerable<Invoice> invoiceCollection;

            invoiceCollection = await this.dbContext.QueryAsync<Invoice>("[Security].[ModuleGet]");

            return invoiceCollection;
        }
    }
}