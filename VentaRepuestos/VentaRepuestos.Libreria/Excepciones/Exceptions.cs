using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VentaRepuestos.Libreria
{
    public class CodigoInexistenteException: Exception
    {
        public CodigoInexistenteException(string message): base (message)
        {

        }
        public CodigoInexistenteException () : base ("El código es inexistente")
        {

        }
    }

    public class ProductoConStockExeption : Exception
    {
        public ProductoConStockExeption (string message) : base (message)
        {
        }
        public ProductoConStockExeption() : base ("Producto con stock")
        {
        }
    }
}
