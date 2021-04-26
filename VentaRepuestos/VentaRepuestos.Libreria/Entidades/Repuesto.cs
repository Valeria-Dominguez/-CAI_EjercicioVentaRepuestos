using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VentaRepuestos.Libreria
{
    public class Repuesto
    {
        int _codigo;
        string _nombre;
        double _precio;
        int _stock;
        Categoria _categoria;

        internal int Codigo { get => _codigo; }
        internal int Stock { get => _stock; set => _stock = value; }
        internal double Precio { get => _precio; set => _precio = value; }
        internal Categoria Categoria { get => _categoria; }

        public Repuesto(int codigo, string nombre, double precio, int stock, Categoria categoria)
        {
            this._codigo = codigo;
            this._nombre = nombre;
            this._precio = precio;
            this._stock = stock;
            this._categoria = categoria;
        }

        public override string ToString()
        {
            return $"Código: {this._codigo} - Nombre: {this._nombre} - Precio: ${this._precio} - Stock: {this._stock} - Categoría: {this._categoria.Nombre}";
        }
    }
}
