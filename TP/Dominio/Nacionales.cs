using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dominio
{
    public class Nacionales: PaquetesVendidos
    {
        public Nacionales(int id, string nombre, float precio, int cantidadDias,
            DateTime fecha, bool activo) :base(id, nombre, precio, cantidadDias,
             fecha, activo)
        {}

        public Nacionales() :base()
        { }

        public override void mostrar(List<Lugar> listaLugares)
        {
            Console.WriteLine("");
            Console.WriteLine("---- PAQUETE NACIONAL-IDENTIFICADOR: {0} ----", id);
            Console.WriteLine("Nombre: {0}", nombre);
            Console.WriteLine("Precio: ${0}", precio);
            Console.WriteLine("Lugares del paquete:");
            foreach (var item in listaLugares){

                item.mostrar();
            }
            Console.WriteLine("Cantidad de dias: {0}", cantidadDias);
            Console.WriteLine("Fecha: {0}", fecha);
            if (activo) {
                Console.WriteLine("Activo: SI");
            }
            else
            {
                Console.WriteLine("Activo: NO");
            }
            
        }

    }
}
