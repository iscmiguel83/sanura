using Sanura.Core.Entities;

namespace Sanura.Core.Interfaces.Repositories
{
    public interface IUserRepository
    {
        Task<dynamic> GetAsync(object parameters);

        Task<int> SetAsync(User model, int inputByIdUser);
    }
}