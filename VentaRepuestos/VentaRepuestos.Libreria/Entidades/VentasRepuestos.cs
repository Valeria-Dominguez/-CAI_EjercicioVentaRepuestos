using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VentaRepuestos.Libreria
{
    public class VentasRepuestos
    {
        List<Repuesto> _listaProductos;
        string _nombreComercio;
        string _direccion;
        int _codigoAutoGeneradoRepuesto;
        int _codigoAutoGeneradoCategoria;
        List<Categoria> _categorias;

        public int CodigoAutoGeneradoRepuesto { get => _codigoAutoGeneradoRepuesto; }
        public int CodigoAutoGeneradoCategoria { get => _codigoAutoGeneradoCategoria; }

        public VentasRepuestos(string nombre, string direccion)
        {
            this._nombreComercio = nombre;
            this._direccion = direccion;
            this._listaProductos = new List<Repuesto>();
            this._codigoAutoGeneradoRepuesto = 1;
            this._codigoAutoGeneradoCategoria = 1;
            this._categorias = new List<Categoria>();
        }

        public void AgregarCategoria(Categoria categoria)
        {
            _categorias.Add(categoria);
            this._codigoAutoGeneradoCategoria++;
        }

        public void AgregarRepuesto (Repuesto repuesto)
        {
            _listaProductos.Add(repuesto);
            this._codigoAutoGeneradoRepuesto++;
        }

        public string QuitarRepuesto(int codigo)
        {
            string valor = "";
            Repuesto repuesto = BuscarRepuesto(codigo);
            if (repuesto == null)
            {
                throw new CodigoInexistenteException("No existe producto con ese código");
            }
            if (repuesto.Stock != 0)
            {
                throw new ProductoConStockExeption("No puede darse de baja el producto, posee stock");
            }
            else
            {
                _listaProductos.Remove(repuesto);
                valor = "Baja exitosa";
            }
            return valor;
        }
        public string ModificarPrecio (int codigo, double precio)
        {
            string valor = "";
            Repuesto repuesto = BuscarRepuesto(codigo);
            if (repuesto == null)
            {
                valor = "El repuesto no existe";
            }
            else
            {
                repuesto.Precio = precio;
                valor = "Modificación exitosa";
            }
            return valor;
        }
        public string AgregarStock(int codigo, int cantidad)
        {
            string valor = "";
            Repuesto repuesto = BuscarRepuesto(codigo);
            if(repuesto==null)
            {
                valor = "El repuesto no existe";
            }
            else
            {
                repuesto.Stock = repuesto.Stock + cantidad;
                valor = "Operación exitosa";
            }
            return valor;
        }
        public string QuitarStock(int codigo, int cantidad)
        {
            string valor = "";
            Repuesto repuesto = BuscarRepuesto(codigo);
            if (repuesto == null)
            {
                valor = "El repuesto no existe";
            }
            else if (repuesto.Stock < cantidad)
            {
                valor = "La cantidad de stock disponible es menor: " + repuesto.Stock.ToString();
            }
            else
            {
                repuesto.Stock = repuesto.Stock - cantidad;
                valor = "Operación exitosa";
            }
            return valor;
        }
        public List<Repuesto> TraerPorCategoria (int codigo)
        {
            List<Repuesto> valor = new List<Repuesto>();
            foreach (Repuesto repuesto in _listaProductos)
            {
                if (repuesto.Categoria.Codigo == codigo)
                {
                    valor.Add(repuesto);
                }
            }
            return valor;
        }

        Repuesto BuscarRepuesto (int codigo)
        {
            Repuesto valor = null;
            foreach(Repuesto repuesto in this._listaProductos)
            {
                if (repuesto.Codigo==codigo)
                {
                    valor = repuesto;
                }
            }
            return valor;
        }
        public Categoria BuscarCategoria (int codigo)
        {
            Categoria valor = null;
            foreach (Categoria categoria in this._categorias)
            {
                if (categoria.Codigo == codigo)
                {
                    valor = categoria;
                }
            }
            return valor;
        }

    }
}
