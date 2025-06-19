namespace Sanura.Core.Entities
{
    public class Invoice
    {
        required public string Cve_clpv
        {
            get;
            set;
        }

        public char Tip_Doc
        {
            get;
            set;
        }

        required public string Cve_Doc
        {
            get;
            set;
        }

        public DateTime Fecha_Doc
        {
            get;
            set;
        }

        public DateTime Fecha_Ven
        {
            get;
            set;
        }

        public double Importe
        {
            get;
            set;
        }

        public double Saldo
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