using Sanura.Core.Interfaces;
using Sanura.Core.Interfaces.Repositories;
using Sanura.Infrastructure.Repositories;

namespace Sanura.Infrastructure
{
    public class UnitOfWork : IUnitOfWork
    {
        private ICustomerRepository? customerRepository;
        private IInvoiceRepository? invoiceRepository;
        private ISellerRepository? sellerRepository;
        private readonly IDbContext context;

        public UnitOfWork(IDbContext context)
        {
            this.context = context;
        }

        public ICustomerRepository CustomerRepository
        {
            get
            {
                if (this.customerRepository == null)
                {
                    this.customerRepository = new CustomerRepository(this.context);
                }
                return this.customerRepository;
            }
        }

        public IInvoiceRepository InvoiceRepository
        {
            get
            {
                if (this.invoiceRepository == null)
                {
                    this.invoiceRepository = new InvoiceRepository(this.context);
                }
                return this.invoiceRepository;
            }
        }

        public ISellerRepository SellerRepository
        {
            get
            {
                if (this.sellerRepository == null)
                {
                    this.sellerRepository = new SellerRepository(this.context);
                }
                return this.sellerRepository;
            }
        }

        public void Dispose()
        {
            if (this.context != null)
            {
                this.context.Dispose();
            }

        }
    }
}