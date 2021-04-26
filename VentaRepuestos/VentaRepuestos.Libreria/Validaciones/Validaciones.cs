using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Validaciones
{
    public class Validaciones
    {
        public static string ValidarStrNoVac(string mensaje)
        {
            string valor;
            do
            {
                Console.WriteLine(mensaje);
                valor = Console.ReadLine().ToUpper();
                if (valor == "")
                {
                    Console.WriteLine("El campo no puede estar vacío\n");
                }
            }
            while (valor == "");
            return valor;
        }
        public static uint ValidarUint(string mensaje)
        {
            uint valor;
            do
            {
                Console.WriteLine(mensaje);
                if (!uint.TryParse(Console.ReadLine(), out valor))
                {
                    valor = uint.MaxValue;
                }
                if (valor == uint.MaxValue)
                {
                    Console.WriteLine("Debe ingresar un valor entero positivo");
                }
            }
            while (valor == uint.MaxValue);
            return valor;
        }
        public static int ValidarInt(string mensaje)
        {
            int valor;
            do
            {
                Console.WriteLine(mensaje);
                if (!int.TryParse(Console.ReadLine(), out valor))
                {
                    valor = int.MaxValue;
                }
                if (valor == int.MaxValue)
                {
                    Console.WriteLine("Debe ingresar un valor entero positivo");
                }
            }
            while (valor == int.MaxValue);
            return valor;
        }
        public static double ValidarDoubleMayorACero(string mensaje)
        {
            double valor;
            do
            {
                Console.WriteLine(mensaje);
                if (!double.TryParse(Console.ReadLine(), out valor))
                {
                    valor = 0;
                }
                if (valor <= 0)
                {
                    Console.WriteLine("Debe ingresar un valor positivo");
                }
            }
            while (valor <= 0);
            return valor;
        }

        public static double ValidarDouble(string mensaje)
        {
            double valor;
            do
            {
                Console.WriteLine(mensaje);
                if (!double.TryParse(Console.ReadLine(), out valor))
                {
                    valor = double.MaxValue;
                }
                if (valor == double.MaxValue)
                {
                    Console.WriteLine("Debe ingresar un valor");
                }
            }
            while (valor == double.MaxValue);
            return valor;
        }

        public static DateTime PedirFecha(string mensaje)
        {
            DateTime valor;
            bool esFecha;
            int dia;
            int mes;
            int año;
            do
            {
                Console.WriteLine(mensaje);
                dia = (int)ValidarUint("Ingrese día");
                mes = (int)ValidarUint("Ingrese mes");
                año = (int)ValidarUint("Ingrese año");
                esFecha = ValidarFecha(dia, mes, año);
                if (esFecha == false)
                {
                    Console.WriteLine("Fecha inválida, ingrese fecha nuevamente:");
                }
            }
            while (esFecha == false);
            string date = $"{dia}/{mes}/{año} 00:00:00";
            valor = DateTime.Parse(date);
            return valor;
        }
        public static bool ValidarFecha(int dia, int mes, int año)
        {
            string date = $"{dia}/{mes}/{año} 00:00:00";
            DateTime valor;
            if (!DateTime.TryParse(date, out valor))
            {
                return false;
            }
            else
            {
                return true;
            }
        }

    }
}
