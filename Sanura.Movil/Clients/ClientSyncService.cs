using Sanura.Core.Client;
using Sanura.Movil.Interfaces.Clients;
using Sanura.Movil.Models;

namespace Sanura.Movil.Clients;

public class ClientSyncService : ClientBase, IClientSyncService
{
    public async Task<string> DownloadAsync(string idSeller)
    {
        var url = Preferences.Get(Constants.Url, string.Empty);
        var request = new Core.Client.Request(HttpMethod.Get, $"{url}/api/sync/download");
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
