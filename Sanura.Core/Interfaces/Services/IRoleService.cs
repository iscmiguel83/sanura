using Sanura.Core.DTOs;
using Sanura.Core.Model;

namespace Sanura.Core.Interfaces.Services
{
    public interface IRoleService
    {
        Task<ResponseOptions<IEnumerable<RoleDto>>> GetAsync(RequestOptions options);

        Task SetAsync(RoleDto model);
    }
}