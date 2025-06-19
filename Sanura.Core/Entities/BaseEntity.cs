namespace Sanura.Core.Entities
{
    public class BaseEntity
    {
        public bool Active
        {
            get;
            set;
        }

        public DateTimeOffset CreationDateTime
        {
            get;
            set;
        }

        public int CreatedByIdUser
        {
            get;
            set;
        }

        public DateTimeOffset? UpdateDateTime
        {
            get;
            set;
        }

        public int? UpdatedByIdUser
        {
            get;
            set;
        }

        public User CreatedByUserObject
        {
            get;
            set;
        }

        public User? UpdatedByUserObject
        {
            get;
            set;
        }
    }
}