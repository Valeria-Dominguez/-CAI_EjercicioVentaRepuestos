using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VentaRepuestos.Libreria
{
    public class Categoria
    {
        int _codigo;
        string _nombre;

        internal int Codigo { get => _codigo;}
        internal string Nombre { get => _nombre;}

        public Categoria(int codigo, string nombre)
        {
            _codigo = codigo;
            _nombre = nombre;
        }

    }
}
