namespace Sanura.Core.DTOs
{
    public class RoleDto : BaseCatalogDto
    {
        public int? IdRole
        {
            get;
            set;
        }

        public IEnumerable<ModuleDto>? Modules
        {
            get;
            set;
        }
    }
}