namespace Sanura.Core.DTOs
{
    public class BaseEntityDto
    {
        public bool Active
        {
            get;
            set;
        }

        public DateTime CreationDateTime
        {
            get;
            set;
        }

        public int CreatedByIdUser
        {
            get;
            set;
        }

        public DateTime? UpdateDateTime
        {
            get;
            set;
        }

        public int? UpdatedByIdUser
        {
            get;
            set;
        }

        public string? CreatedByUser
        {
            get;
            set;
        }

        public string? UpdatedByUser
        {
            get;
            set;
        }
    }
}