using Sanura.Core.DTOs;
using Sanura.Core.Model;

namespace Sanura.Core.Interfaces.Services
{
    public interface IModuleService
    {
        Task<ResponseOptions<IEnumerable<ModuleDto>>> GetAsync(RequestOptions options);

        Task SetAsync(ModuleDto model);
    }
}