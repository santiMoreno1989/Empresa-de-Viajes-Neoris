using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dominio
{
    public class PaqueteLugar
    {
        private int idPaquete;
        private int idLugar;

        public PaqueteLugar(int idPaquete,int idLugar)
        {
            this.idPaquete = idPaquete;
            this.idLugar = idLugar;
        }

        public PaqueteLugar()
        {}

        [Key, Column(Order = 0)]
        public int IdPaquete
        {
            get { return idPaquete; }
            set { idPaquete = value; }
        }

        [Key, Column(Order = 1)]
        public int IdLugar
        {
            get { return idLugar; }
            set { idLugar = value; }
        }

        
    }
}
