using Newtonsoft.Json;
using Sanura.Core.Interfaces;
using Sanura.Core.Interfaces.Services;
using Sanura.Core.Model;

namespace Sanura.Core.Services
{
    public class SyncService : ISyncService
    {
        private readonly IUnitOfWork unitOfWork;

        public SyncService(IUnitOfWork unitOfWork)
        {
            this.unitOfWork = unitOfWork;
        }

        public async Task<string> DownloadAsync(string idSeller)
        {
            var seller = await this.unitOfWork.SellerRepository.GetAsync(idSeller);

            if (seller != null)
            {
                seller.Customers = await this.unitOfWork.CustomerRepository.GetAsync(idSeller);

                var invoices = await this.unitOfWork.InvoiceRepository.GetAsync(idSeller);

                foreach (var customer in seller.Customers)
                {
                    customer.Invoices = invoices.Where(i=> i.Cve_clpv == customer.Clave);
                }
            }

            return JsonConvert.SerializeObject(seller);
        }

        public Task UploadAsync(string fileBase64)
        {
            throw new NotImplementedException();
        }
    }
}