using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dominio
{
    public abstract class Cliente
    {
        
        protected int id;
        protected int dni;
        protected string apellido;
        protected string nombre;
        protected string nacionalidad;
        protected string provincia;
        protected string direccion;
        protected int telefono;

        public Cliente(int id,int dni,string apellido, string nombre,string nacionalidad,
            string provincia,string direccion,int telefono)
        {
            this.id = id;
            this.dni = dni;
            this.apellido = apellido;
            this.nombre = nombre;
            this.nacionalidad = nacionalidad;
            this.provincia = provincia;
            this.direccion = direccion;
            this.telefono = telefono;
        }

        public Cliente()
        { }

        [Key, Column(Order = 0)]
        public int Id
        {
            get { return id; }
            set { id = value; }
        }


        [Key, Column(Order = 1)]
        public int Dni
        {
            get { return dni; }
            set { dni = value; }
        }

        public string Apellido
        {
            get { return apellido; }
            set { apellido = value; }
        }

        public string Nombre
        {
            get { return nombre; }
            set { nombre = value; }
        }

        public string Nacionalidad
        {
            get { return nacionalidad; }
            set { nacionalidad = value; }
        }

        public string Provincia
        {
            get { return provincia; }
            set { provincia = value; }
        }

        public string Direccion
        {
            get { return direccion; }
            set { direccion = value; }
        }

        public int Telefono
        {
            get { return telefono; }
            set { telefono = value; }
        }

        public abstract void mostrar();
    }
}
