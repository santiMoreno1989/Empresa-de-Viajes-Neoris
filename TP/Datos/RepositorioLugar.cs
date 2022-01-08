using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dominio;

namespace Datos
{
    public class RepositorioLugar
    {
        public static List<Lugar> listarLugares()
        {
            using (var context = new BaseContext())
            {
                return context.Lugar.ToList();
            }
        }

        public static void agregar(Lugar l)
        {
            using (var context = new BaseContext())
            {
                context.Lugar.Add(l);
                context.SaveChanges();
            }
        }
    }
}
