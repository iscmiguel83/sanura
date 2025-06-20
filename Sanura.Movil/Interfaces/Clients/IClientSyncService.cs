namespace Sanura.Movil.Interfaces.Clients;

public interface IClientSyncService
{
    Task<string> DownloadAsync(string idSeller);

    Task UploadAsync(string fileBase64);
}
