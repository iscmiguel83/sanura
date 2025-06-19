using Sanura.Core.Entities;

namespace Sanura.Core.Interfaces.Repositories
{
    public interface IModuleRepository
    {
        Task<dynamic> GetAsync(object parameters);

        Task<int> SetAsync(Module model, int inputByIdUser);
    }
}