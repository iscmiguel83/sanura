using Sanura.Core.Model;

namespace Sanura.Core.Interfaces.Services
{
    public interface ISyncService
    {
        Task<string> DownloadAsync(string idSeller);

        Task UploadAsync(string fileBase64);
    }
}