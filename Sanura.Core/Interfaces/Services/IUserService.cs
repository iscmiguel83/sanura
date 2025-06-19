using Sanura.Core.DTOs;
using Sanura.Core.Model;

namespace Sanura.Core.Interfaces.Services
{
    public interface IUserService
    {
        Task<ResponseOptions<IEnumerable<UserDto>>> GetAsync(RequestOptions options);

        Task SetAsync(UserDto model);
    }
}