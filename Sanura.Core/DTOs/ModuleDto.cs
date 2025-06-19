namespace Sanura.Core.DTOs
{
    public class ModuleDto : BaseCatalogDto
    {
        public int? IdModule
        {
            get;
            set;
        }

        public int? IdModuleParent
        {
            get;
            set;
        }

        public float SortOrder
        {
            get;
            set;
        }

        public string? Icon
        {
            get;
            set;
        }

        public string? ModuleParent
        {
            get;
            set;
        }
    }
}