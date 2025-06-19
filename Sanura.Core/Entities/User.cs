namespace Sanura.Core.Entities
{
    public class User : BaseEntity
    {
        public int? IdUser
        {
            get;
            set;
        }

        required public string Email
        {
            get;
            set;
        }

        required public string FirstName
        {
            get;
            set;
        }

        required public string LastName
        {
            get;
            set;
        }

        public DateTimeOffset? Birthday
        {
            get;
            set;
        }

        public IEnumerable<Role> Roles
        {
            get;
            set;
        }
    }
}