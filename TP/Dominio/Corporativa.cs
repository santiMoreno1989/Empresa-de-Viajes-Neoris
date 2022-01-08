using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dominio
{
    public class Corporativa : Cliente
    {
        private string razonSocial;
        private string cuit;

        public Corporativa(int id, int dni, string apellido, string nombre, string nacionalidad,
            string provincia, string direccion, int telefono, string razonSocial,
            string cuit) : base(id, dni, apellido, nombre, nacionalidad,
            provincia, direccion, telefono)
        {
            this.razonSocial = razonSocial;
            this.cuit = cuit;
        }

        public Corporativa() :base()
        { }

        public  string RazonSocial
        {
            get { return razonSocial; }
            set { razonSocial = value; }
        }

        public string Cuit
        {
            get { return cuit; }
            set { cuit = value; }
        }

        public override void mostrar()
        {
            Console.WriteLine("");
            Console.WriteLine("------------------Cliente Corporativo {0}------------------", id);
            Console.WriteLine("DNI: {0}", dni);
            Console.WriteLine("Apellido: {0}", apellido);
            Console.WriteLine("Nombre: {0}", nombre);
            Console.WriteLine("Nacionalidad: {0}", nacionalidad);
            Console.WriteLine("Provincia: {0}", provincia);
            Console.WriteLine("Direccion: {0}", direccion);
            Console.WriteLine("Telefono: {0}", telefono);
            Console.WriteLine("Razon Social: {0}", razonSocial);
            Console.WriteLine("CUIT: {0}", cuit);
        }
    }
}
