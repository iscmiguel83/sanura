using Dapper;
using Sanura.Core.Entities;
using Sanura.Core.Interfaces;
using Sanura.Core.Interfaces.Repositories;
using Sanura.Infrastructure.Model;

namespace Sanura.Infrastructure.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly IDbContext dbContext;

        public UserRepository(IDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public async Task<dynamic> GetAsync(object parameters)
        {
            IEnumerable<User> userCollection;
            IEnumerable<UserRole> userRoleCollection;
            IEnumerable<Role> roleCollection;

            int totalCount;

            using (var multiple = this.dbContext.QueryMultiple("[Security].[UserGet]", parameters: parameters))
            {
                userCollection = await multiple.ReadAsync<User>();
                userRoleCollection = await multiple.ReadAsync<UserRole>();
                roleCollection = await multiple.ReadAsync<Role>();
                totalCount = await multiple.ReadSingleAsync<int>();
            }

            foreach (var user in userCollection)
            {
                user.CreatedByUserObject = userCollection.FirstOrDefault(r => r.IdUser == user.CreatedByIdUser);

                var userRole = userRoleCollection.Where(ur => ur.IdUser == user.IdUser);
                foreach (var ur in userRole)
                {
                    ur.RoleObject = roleCollection.FirstOrDefault(r => r.IdRole == ur.IdRole);
                }
                user.Roles = userRole.Select(ur => ur.RoleObject);

                if (user.UpdatedByIdUser != null)
                {
                    user.UpdatedByUserObject = userCollection.FirstOrDefault(r => r.UpdatedByIdUser == user.UpdatedByIdUser);
                }
            }


            return new
            {
                records = userCollection,
                count = userCollection.Count()
            };
        }

        public async Task<int> SetAsync(User model, int inputByIdUser)
        {
            var rolesId = new TId();

            rolesId.AddRange(model.Roles.Select(r => (int)r.IdRole));

            var parameters = new
            {
                idUser = model.IdUser,
                email = model.Email,
                firstName = model.FirstName,
                lastName = model.LastName,
                active = model.Active,
                BirthDay = model.Birthday,
                roles = rolesId.AsTableValuedParameter("[Common].[TId]"),
                inputByIdUser = inputByIdUser
            };

            var returnValue = await this.dbContext.ExecuteScalarAsync<int>("[Security].[UserSet]", parameters: parameters);

            rolesId.Dispose();
            return returnValue;
        }
    }
}