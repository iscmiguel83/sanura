using Sanura.Core.Entities;
using Sanura.Core.Interfaces;
using Sanura.Core.Interfaces.Repositories;

namespace Sanura.Infrastructure.Repositories
{
    public class ModuleRepository : IModuleRepository
    {
        private readonly IDbContext dbContext;

        public ModuleRepository(IDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public async Task<dynamic> GetAsync(object parameters)
        {
            IEnumerable<Module> moduleCollection;
            IEnumerable<User> userCollection;
            int totalCount;

            using (var multiple = this.dbContext.QueryMultiple("[Security].[ModuleGet]", parameters: parameters))
            {
                moduleCollection = await multiple.ReadAsync<Module>();
                userCollection = await multiple.ReadAsync<User>();
                totalCount = await multiple.ReadSingleAsync<int>();
            }

            foreach (var module in moduleCollection)
            {
                module.CreatedByUserObject = userCollection.FirstOrDefault(r => r.IdUser == module.CreatedByIdUser);

                if (module.IdModuleParent != null)
                {
                    module.ModuleParentObject = moduleCollection.FirstOrDefault(m => m.IdModule == module.IdModuleParent);
                }

                if (module.UpdatedByIdUser != null)
                {
                    module.UpdatedByUserObject = userCollection.FirstOrDefault(r => r.UpdatedByIdUser == module.UpdatedByIdUser);
                }
            }

            return new
            {
                records = moduleCollection,
                count = totalCount,
            };
        }

        public async Task<int> SetAsync(Module model, int inputByIdUser)
        {
            var parameters = new
            {
                idModule = model.IdModule,
                idModuleParent = model.IdModuleParent,
                code = model.Code,
                description = model.Description,
                sortOrder = model.SortOrder,
                icon = model.Icon,
                active = model.Active,
                inputByIdUser = inputByIdUser
            };

            return await this.dbContext.ExecuteScalarAsync<int>("[Security].[ModuleSet]", parameters: parameters);
        }
    }
}