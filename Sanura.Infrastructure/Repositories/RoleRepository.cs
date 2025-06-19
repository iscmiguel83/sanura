using Dapper;
using Sanura.Core.Entities;
using Sanura.Core.Interfaces;
using Sanura.Core.Interfaces.Repositories;
using Sanura.Infrastructure.Model;

namespace Sanura.Infrastructure.Repositories
{
    public class RoleRepository : IRoleRepository
    {
        private readonly IDbContext dbContext;

        public RoleRepository(IDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public async Task<dynamic> GetAsync(object parameters)
        {
            IEnumerable<Role> roleCollection;
            IEnumerable<RoleModule> roleModuleCollection;
            IEnumerable<Module> moduleCollection;
            IEnumerable<User> userCollection;
            int totalCount;

            using (var multiple = this.dbContext.QueryMultiple("[Security].[RoleGet]", parameters: parameters))
            {
                roleCollection = await multiple.ReadAsync<Role>();
                userCollection = await multiple.ReadAsync<User>();
                roleModuleCollection = await multiple.ReadAsync<RoleModule>();
                moduleCollection = await multiple.ReadAsync<Module>();
                totalCount = await multiple.ReadSingleAsync<int>();
            }

            foreach (var role in roleCollection)
            {
                role.CreatedByUserObject = userCollection.FirstOrDefault(r => r.IdUser == role.CreatedByIdUser);

                var roleModule = roleModuleCollection.Where(rm => rm.IdRole == role.IdRole);
                foreach (var rm in roleModule)
                {
                    rm.ModuleObject = moduleCollection.FirstOrDefault(m => m.IdModule == rm.IdModule);
                }
                role.Modules = roleModule.Select(rm => rm.ModuleObject);

                if (role.UpdatedByIdUser != null)
                {
                    role.UpdatedByUserObject = userCollection.FirstOrDefault(r => r.UpdatedByIdUser == role.UpdatedByIdUser);
                }
            }

            return new
            {
                records = roleCollection,
                count = totalCount,
            };
        }

        public async Task<int> SetAsync(Role model, int inputByIdUser)
        {
            var modulesId = new TId();
            modulesId.AddRange(model.Modules.Select(r => (int)r.IdModule));

            var parameters = new
            {
                idRole = model.IdRole,
                code = model.Code,
                description = model.Description,
                active = model.Active,
                modules = modulesId.AsTableValuedParameter("[Common].[TId]"),
                inputByIdUser = inputByIdUser
            };

            return await this.dbContext.ExecuteScalarAsync<int>("[Security].[RoleSet]", parameters: parameters);
        }
    }
}