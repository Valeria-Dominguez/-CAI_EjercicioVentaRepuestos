using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VentaRepuestos.Libreria;

namespace VentaRepuestos.Consola
{
    static class Program
    {
        static Libreria.VentasRepuestos unLocal;
        static void Main(string[] args)
        {
            unLocal = new VentasRepuestos("El local", "La dirección");
            Menu();

            void Menu()
            {
                string opcion = "";
                const string opABMRepuestos = "1";
                const string opListarRepuestos = "2";
                const string opAgregarStock = "3";
                const string opQuitarStock = "4";
                const string opSalir = "5";
                do
                {
                    opcion=Validaciones.Validaciones.ValidarStrNoVac("Ingrese una opción\n"
                        + opABMRepuestos + ".ABM de repuestos\n"
                        + opListarRepuestos + ".Listar repuestos por categoría\n"
                        + opAgregarStock + ".Agregar stock\n"
                        + opQuitarStock + ".Quitar stock\n"
                        + opSalir + ".Salir\n"
                        );

                    switch (opcion)
                    {
                        case opABMRepuestos:
                            MenuABM();
                            break;
                        case opListarRepuestos:
                            ListarRepuestos(unLocal);
                            break;
                        case opAgregarStock:
                            AgregarStock(unLocal);
                            break;
                        case opQuitarStock:
                            QuitarStock(unLocal);
                            break;
                        default:
                            Console.WriteLine("Opción inválida");
                            break;
                    }
                }
                while (opcion != opSalir);
            }

            void MenuABM()
            {
                string opcion = "";
                const string opAlta = "1";
                const string opBaja = "2";
                const string opModificacion = "3";
                opcion = Validaciones.Validaciones.ValidarStrNoVac("Ingrese una opción\n"
                        + opAlta + ".Alta repuesto\n"
                        + opBaja + ".Baja repuesto\n"
                        + opModificacion + ".Modificar Precio\n"
                        );

                switch (opcion)
                {
                    case opAlta:
                        try
                        {
                            DarAltaRepuesto(unLocal);
                        }
                        catch (CodigoInexistenteException codInexExe)
                        {
                            Console.WriteLine(codInexExe.Message + "\n");
                        }
                        break;
                    case opBaja:
                        DarBajaRepuesto(unLocal);
                        break;
                    case opModificacion:
                        ModificarPrecio(unLocal);
                        break;
                    default:
                        Console.WriteLine("Opción inválida");
                        break;
                }
            }

            void DarAltaRepuesto(Libreria.VentasRepuestos local)
            {
                string nombreRepuesto = Validaciones.Validaciones.ValidarStrNoVac("Ingrese nombre del repuesto");
                double precio = Validaciones.Validaciones.ValidarDoubleMayorACero("Ingrese precio del repuesto");
                int stock = (int)Validaciones.Validaciones.ValidarUint("Ingrese stock del repuesto");

                Categoria categoria;

                string opCategoria;
                do
                {
                    opCategoria = Validaciones.Validaciones.ValidarStrNoVac("Elija una opción:\n1.Ingresar código de categoría\n2.Agregar nueva categoría");
                    if(opCategoria != "1" && opCategoria != "2") { Console.WriteLine("Opción inválida"); }
                }
                while (opCategoria != "1" && opCategoria != "2");

                if (opCategoria == "1")
                {
                    int codigoCategoria = (int)Validaciones.Validaciones.ValidarUint("Ingrese código de categoría");
                    categoria = local.BuscarCategoria(codigoCategoria);
                    if(categoria==null)
                    {
                        throw new CodigoInexistenteException("Código de categoría inexistente");
                    }
                }
                else
                {
                    string nombreCategoria = Validaciones.Validaciones.ValidarStrNoVac("Ingrese nombre de la categoría");
                    int codigoCategoria = local.CodigoAutoGeneradoCategoria;
                    categoria = new Categoria(codigoCategoria, nombreCategoria);
                    local.AgregarCategoria(categoria);
                }

                Repuesto repuesto = new Libreria.Repuesto(local.CodigoAutoGeneradoRepuesto, nombreRepuesto, precio, stock, categoria);
                local.AgregarRepuesto(repuesto);
                Console.WriteLine("Ingreso exitoso\n");
            }

            void DarBajaRepuesto (Libreria.VentasRepuestos local)
            {
                int codigo = (int)Validaciones.Validaciones.ValidarUint("Ingrese código del repuesto");
                try
                {
                    Console.WriteLine(local.QuitarRepuesto(codigo) + "\n");
                }
                catch (CodigoInexistenteException codInexExe)
                {
                    Console.WriteLine(codInexExe.Message + "\n");
                }
                catch (ProductoConStockExeption productCnStckExe)
                {
                    Console.WriteLine(productCnStckExe.Message + "\n");
                }
            }

            void ModificarPrecio (Libreria.VentasRepuestos local)
            {
                int codigo = (int)Validaciones.Validaciones.ValidarUint("Ingrese código del repuesto");
                double precio = (int)Validaciones.Validaciones.ValidarUint("Ingrese precio del repuesto");
                Console.WriteLine(local.ModificarPrecio(codigo, precio) + "\n");
            }

            void ListarRepuestos(Libreria.VentasRepuestos local)
            {
                int codigo = (int)Validaciones.Validaciones.ValidarUint("Ingrese código de categoría");
                List<Repuesto> repuestos = local.TraerPorCategoria(codigo); 
                if(repuestos.Count==0)
                {
                    Console.WriteLine("No hay productos ingresados para esa categoría\n");
                }
                else
                {
                    foreach (Repuesto repuesto in repuestos)
                    {
                        Console.WriteLine(repuesto.ToString()+"\n");
                    }
                }
            }

            void AgregarStock(Libreria.VentasRepuestos local)
            {
                int codigo = (int)Validaciones.Validaciones.ValidarUint("Ingrese código del repuesto");
                int cantidad = (int)Validaciones.Validaciones.ValidarUint("Ingrese cantidad del repuesto");
                Console.WriteLine(local.AgregarStock(codigo, cantidad) + "\n");
            }

            void QuitarStock(Libreria.VentasRepuestos local)
            {
                int codigo = (int)Validaciones.Validaciones.ValidarUint("Ingrese código del repuesto");
                int cantidad = (int)Validaciones.Validaciones.ValidarUint("Ingrese cantidad del repuesto");
                Console.WriteLine(local.QuitarStock(codigo, cantidad) + "\n");
            }

        }
    }
}
