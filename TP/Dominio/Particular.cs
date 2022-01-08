using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dominio
{
    public class Particular : Cliente
    {

        public Particular(int id, int dni, string apellido, string nombre, string nacionalidad,
            string provincia, string direccion, int telefono) : base(id, dni, apellido, nombre, nacionalidad,
            provincia, direccion, telefono)
        { }

        public Particular() :base()
        { }

        public override void mostrar()
        {
            Console.WriteLine("");
            Console.WriteLine("------------------Cliente Particular {0}------------------", id);
            Console.WriteLine("DNI: {0}", dni);
            Console.WriteLine("Apellido: {0}", apellido);
            Console.WriteLine("Nombre: {0}", nombre);
            Console.WriteLine("Nacionalidad: {0}", nacionalidad);
            Console.WriteLine("Provincia: {0}", provincia);
            Console.WriteLine("Direccion: {0}", direccion);
            Console.WriteLine("Telefono: {0}", telefono);
        }

    }
}
