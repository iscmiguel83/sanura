namespace Sanura.Core.Entities
{
    public class Seller
    {
        required public string Cve_Vend
        {
            get;
            set;
        }

        public char Status
        {
            get;
            set;
        }

        required public string Nombre
        {
            get;
            set;
        }

        public IEnumerable<Customer> Customers
        {
            get;
            set;
        } = [];
    }
}