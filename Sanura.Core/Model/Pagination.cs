namespace Sanura.Core.Model
{
    public class Pagination
    {
        public Pagination()
        {
            this.PageNumber = 1;
            this.PageSize = 1000;
        }


        public int PageNumber
        {
            get;
            set;
        }

        public int PageSize
        {
            get;
            set;
        }
    }
}
