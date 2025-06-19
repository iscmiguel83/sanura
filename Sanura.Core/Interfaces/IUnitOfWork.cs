using Sanura.Core.Interfaces.Repositories;

namespace Sanura.Core.Interfaces
{
    public interface IUnitOfWork : IDisposable
    {
        IModuleRepository ModuleRepository
        {
            get;
        }

        IRoleRepository RoleRepository
        {
            get;
        }

        IUserRepository UserRepository
        {
            get;
        }

    }
}