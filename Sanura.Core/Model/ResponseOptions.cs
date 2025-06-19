namespace Sanura.Core.Model
{
    public class ResponseOptions<T>
    {
        public ResponseOptions(T data, int totalCount = 0)
        {
            this.Data = data;
            this.TotalCount = totalCount;
            this.Status = 200;
            this.Message = "OK";
        }

        public T Data
        {
            get;
            set;
        }

        public string Message
        {
            get;
            set;
        }

        public int Status
        {
            get;
            set;
        }

        public int TotalCount
        {
            get;
            set;
        }
    }
}