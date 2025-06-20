﻿using Sanura.Core.Entities;
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

            var query = $"SELECT CVE_VEND, STATUS, NOMBRE FROM VEND01 v WHERE CVE_VEND = {idSeller}";
            sellerrCollection = await this.dbContext.QuerySingleAsync<Seller>(query, System.Data.CommandType.Text);

            return sellerrCollection;
        }
    }
}