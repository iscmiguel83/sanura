namespace Sanura.Core.Entities
{
    public class RoleModule : BaseEntity
    {
        public int IdRoleModule
        {
            get;
            set;
        }

        public int IdRole
        {
            get;
            set;
        }

        public int IdModule
        {
            get;
            set;
        }

        public Module ModuleObject
        {
            get;
            set;
        }
    }
}