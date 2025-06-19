namespace Sanura.Core.Model
{
    public class RequestOptions
    {
        public RequestOptions()
        {
            this.Filters = new List<KeyValuePair<string, string>>();
        }

        public OrderBy? OrderBy
        {
            get;
            set;
        }

        public Pagination? Pagination
        {
            get;
            set;
        }

        public List<KeyValuePair<string, string>>? Filters
        {
            get;
            set;
        }

        public List<KeyValuePair<string, string>>? Columns
        {
            get;
            set;
        }

        public string? SheetName
        {
            get;
            set;
        }
    }
}
