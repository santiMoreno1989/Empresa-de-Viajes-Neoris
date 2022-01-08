using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dominio
{
    public class Lugar
    {
        private int id;
        private string nombre;

        public Lugar(int id, string nombre)
        {
            this.id = id;
            this.nombre = nombre;

        }

        public Lugar()
        {}

        [Key, Column(Order = 0)]
        public  int Id
        {
            get { return id; }
            set { id = value; }
        }

        [Key, Column(Order = 1)]
        public string Nombre
        {
            get { return nombre; }
            set { nombre = value; }
        }

        public void mostrar()
        {
            Console.WriteLine("-----Identificador: {0} --- Lugar: {1}------", id, nombre);
        }

    }
}
