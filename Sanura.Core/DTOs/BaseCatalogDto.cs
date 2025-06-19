namespace Sanura.Core.DTOs
{
    public class BaseCatalogDto : BaseEntityDto
    {
        required public string Code
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