﻿using Sanura.Core.Entities;
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

            var query = $"SELECT f.CVE_CLPV, f.TIP_DOC, f.CVE_DOC, f.FECHA_DOC, f.FECHA_VEN, f.Importe, f.Importe AS Saldo FROM FACTF01 f INNER JOIN CLIE01 c ON f.CVE_CLPV= c.CLAVE WHERE c.CVE_VEND = {idSeller}";
            invoiceCollection = await this.dbContext.QueryAsync<Invoice>(query, System.Data.CommandType.Text);

            return invoiceCollection;
        }
    }
}