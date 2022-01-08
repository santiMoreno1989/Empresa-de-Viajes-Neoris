using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dominio;


namespace Datos
{
    public class BaseContext : DbContext
    {
        public BaseContext() : base("BaseContext")
        { }

        public DbSet<Particular> Particular { get; set; }
        public DbSet<Corporativa> Corporativa { get; set; }

        
        public DbSet<Nacionales> Nacionales { get; set; }

        public DbSet<Internacionales> Internacionales { get; set; }

        public DbSet<Lugar> Lugar { get; set; }

        public DbSet<PaqueteLugar> PaqueteLugar { get; set; }

        public DbSet<Factura> Factura { get; set; }

        
    }
}
