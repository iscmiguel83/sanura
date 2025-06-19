namespace Sanura.Core.Entities
{
    public class Customer
    {
        required public string Clave
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

        required public string Rfc
        {
            get;
            set;
        }

        required public string NombreComercial
        {
            get;
            set;
        }

        required public string Telefono
        {
            get;
            set;
        }

        required public string Mail
        {
            get;
            set;
        }

        public IEnumerable<Invoice> Invoices
        {
            get;
            set;
        } = [];
    }
}