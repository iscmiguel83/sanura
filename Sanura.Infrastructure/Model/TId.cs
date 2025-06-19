using System.Data;

namespace Sanura.Infrastructure.Model
{
    internal class TId : DataTable
    {
        public TId()
        {
            this.Columns.Add("id");
        }

        public void Add(int item, bool clear = true)
        {
            if (clear)
            {
                this.Clear();
            }

            var row = this.NewRow();
            row["id"] = item;

            this.Rows.Add(row);
        }

        public void AddRange(IEnumerable<int> items)
        {
            this.Clear();
            foreach (var item in items)
            {
                this.Add(item, false);
            }
        }
    }
}