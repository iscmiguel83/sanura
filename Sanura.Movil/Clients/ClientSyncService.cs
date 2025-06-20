using Sanura.Core.Client;
using Sanura.Movil.Interfaces.Clients;

namespace Sanura.Movil.Clients;

public class ClientSyncService : ClientBase, IClientSyncService
{
    public async Task<string> DownloadAsync(string idSeller)
    {
        var request = new Core.Client.Request(HttpMethod.Get, "https://192.168.100.215:7142/api/sync/download");
        request.AddQueryParam("idSeller", idSeller);
        var response = await base.MakeRequestAsync(request);
        if (response?.Content == null)
        {
            return string.Empty;
        }

        return response.Content;
    }

    public Task UploadAsync(string fileBase64)
    {
        throw new NotImplementedException();
    }
}
