using Sanura.Core.Interfaces.Repositories;

namespace Sanura.Core.Interfaces
{
    public interface IUnitOfWork : IDisposable
    {
        ICustomerRepository CustomerRepository
        {
            get;
        }

        IInvoiceRepository InvoiceRepository
        {
            get;
        }

        ISellerRepository SellerRepository
        {
            get;
        }

    }
}