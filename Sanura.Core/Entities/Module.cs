namespace Sanura.Core.Entities
{
    public class Module : BaseCatalog
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

        public string Icon
        {
            get;
            set;
        }

        public Module ModuleParentObject
        {
            get;
            set;
        }
    }
}
