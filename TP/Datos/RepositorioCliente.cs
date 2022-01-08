using Dominio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Datos
{
    public class RepositorioCliente
    {
        public static List<Particular> listarParticular()
        {
            using (var context = new BaseContext())
            {
                return context.Particular.ToList();
            }
        }

        public static void agregar(Particular p)
        {
            using (var context = new BaseContext())
            {
                context.Particular.Add(p);
                context.SaveChanges();
            }
        }

        public static List<Corporativa> listarCorporativa()
        {
            using (var context = new BaseContext())
            {
                return context.Corporativa.ToList();
            }
        }

        public static void agregar(Corporativa c)
        {
            using (var context = new BaseContext())
            {
                context.Corporativa.Add(c);
                context.SaveChanges();
            }
        }

        public static List<Cliente> listarClientes()
        {
            List<Corporativa> c = listarCorporativa();
            List<Particular> p = listarParticular();
            List<Cliente> lista = new List<Cliente>();

            foreach (var item in c)
            {
                lista.Add(item);
            }

            foreach (var item in p)
            {
                lista.Add(item);
            }

            return lista;
        }
    }
}
