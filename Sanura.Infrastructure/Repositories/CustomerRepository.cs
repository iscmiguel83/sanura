using Sanura.Core.Entities;
using Sanura.Core.Interfaces;
using Sanura.Core.Interfaces.Repositories;

namespace Sanura.Infrastructure.Repositories
{
    public class CustomerRepository : ICustomerRepository
    {
        private readonly IDbContext dbContext;

        public CustomerRepository(IDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public async Task<IEnumerable<Customer>> GetAsync(string idSeller)
        {
            IEnumerable<Customer> customerCollection;

            var query = $"SELECT CLAVE, STATUS, NOMBRE, RFC, NOMBRECOMERCIAL, TELEFONO, EMAILPRED MAIL FROM CLIE01 WHERE CVE_VEND = {idSeller}";
            customerCollection = await this.dbContext.QueryAsync<Customer>(query, System.Data.CommandType.Text);

            return customerCollection;
        }
    }
}