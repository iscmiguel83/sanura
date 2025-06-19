using Sanura.Core.Interfaces;
using Sanura.Core.Interfaces.Repositories;
using Sanura.Infrastructure.Repositories;

namespace Sanura.Infrastructure
{
    public class UnitOfWork : IUnitOfWork
    {
        private IModuleRepository? moduleRepository;
        private IRoleRepository? roleRepository;
        private IUserRepository? userRepository;
        private readonly IDbContext context;

        public UnitOfWork(IDbContext context)
        {
            this.context = context;
        }

        public IModuleRepository ModuleRepository
        {
            get
            {
                if (this.moduleRepository == null)
                {
                    this.moduleRepository = new ModuleRepository(this.context);
                }
                return this.moduleRepository;
            }
        }

        public IRoleRepository RoleRepository
        {
            get
            {
                if (this.roleRepository == null)
                {
                    this.roleRepository = new RoleRepository(this.context);
                }
                return this.roleRepository;
            }
        }

        public IUserRepository UserRepository
        {
            get
            {
                if (this.userRepository == null)
                {
                    this.userRepository = new UserRepository(this.context);
                }
                return this.userRepository;
            }
        }

        public void Dispose()
        {
            if (this.context != null)
            {
                this.context.Dispose();
            }

        }
    }
}