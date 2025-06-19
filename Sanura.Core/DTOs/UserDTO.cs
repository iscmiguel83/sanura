namespace Sanura.Core.DTOs
{
    public class UserDto : BaseEntityDto
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

        public DateTime? Birthday
        {
            get;
            set;
        }

        public IEnumerable<RoleDto>? Roles
        {
            get;
            set;
        }
    }
}