using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dominio
{
    public abstract class PaquetesVendidos
    {
        protected int id;
        protected string nombre;
        protected float precio;
        //protected List<String> lugares;
        protected int cantidadDias;
        protected DateTime fecha;
        protected bool activo;

        public PaquetesVendidos(int id, string nombre, float precio, int cantidadDias,
            DateTime fecha, bool activo)
        {
            this.id = id;
            this.nombre = nombre;
            this.precio = precio;
            this.cantidadDias = cantidadDias;
            this.fecha = fecha;
            this.activo = activo;

        }

        public PaquetesVendidos()
        {}

        [Key, Column(Order = 0)]
        public int Id
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

        public float Precio
        {
            get { return precio; }
            set { precio = value; }
        }

        public int CantidadDias
        {
            get { return cantidadDias; }
            set { cantidadDias = value; }
        }

        public DateTime Fecha
        {
            get { return fecha; }
            set { fecha = value; }
        }

        public bool Activo
        {
            get { return activo; }
            set {activo = value; }
        }

        public abstract void mostrar(List<Lugar> listaLugares);
    }
}
