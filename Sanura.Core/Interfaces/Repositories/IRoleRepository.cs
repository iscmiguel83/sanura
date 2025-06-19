using Sanura.Core.Entities;

namespace Sanura.Core.Interfaces.Repositories
{
    public interface IRoleRepository
    {
        Task<dynamic> GetAsync(object parameters);

        Task<int> SetAsync(Role model, int inputByIdUser);
    }
}