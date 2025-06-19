namespace Sanura.Core.Entities
{
    public class BaseCatalog : BaseEntity
    {
        public string Code
        {
            get;
            set;
        }

        public string? Description
        {
            get;
            set;
        }
    }
}