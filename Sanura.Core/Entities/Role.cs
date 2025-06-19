namespace Sanura.Core.Entities
{
    public class Role : BaseCatalog
    {
        public int? IdRole
        {
            get;
            set;
        }

        public IEnumerable<Module> Modules
        {
            get;
            set;
        }
    }
}