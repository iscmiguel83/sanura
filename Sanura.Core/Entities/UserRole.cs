namespace Sanura.Core.Entities
{
    public class UserRole : BaseEntity
    {
        public int IdUserRole
        {
            get;
            set;
        }

        public int IdUser
        {
            get;
            set;
        }

        public int IdRole
        {
            get;
            set;
        }

        public Role RoleObject
        {
            get;
            set;
        }
    }
}