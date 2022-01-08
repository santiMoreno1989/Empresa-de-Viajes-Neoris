using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dominio;

namespace Datos
{
    public class RepositorioFactura
    {
        public static List<Factura> listarFactura()
        {
            using (var context = new BaseContext())
            {
                return context.Factura.ToList();
            }
        }

        public static void agregar(Factura f)
        {
            using (var context = new BaseContext())
            {
                context.Factura.Add(f);
                
                context.SaveChanges();
            }
        }
    }
}
