using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dominio
{
    public class Factura
    {
      
        private int idPaquete;
        private int idDniCliente;

        public Factura(int idPaquete, int idDniCliente)
        {
            this.idPaquete = idPaquete;
            this.idDniCliente = idDniCliente;
        }

        public Factura()
        {}

        [Key, Column(Order = 0)]
        public int IdPaquete
        {
            get { return idPaquete; }
            set { idPaquete = value; }
        }

        [Key, Column(Order = 1)]
        public int IdDniCliente
        {
            get { return idDniCliente; }
            set { idDniCliente= value; }
        }

       
    }
}
