using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dominio;

namespace Datos
{
    public class RepositorioPaquetes
    {
        public static List<Nacionales> listarNacionales()
        {
            using (var context = new BaseContext())
            {
                return context.Nacionales.ToList();
            }
        }

        public static List<Internacionales> listarInternacionales()
        {
            using (var context = new BaseContext())
            {
                return context.Internacionales.ToList();
            }
        }

        public static List<PaquetesVendidos> listarPaquetes()
        {
            List<Internacionales> inter = listarInternacionales();
            List<Nacionales> nac = listarNacionales();
            List<PaquetesVendidos> lista = new List<PaquetesVendidos>();

            foreach (var item in inter)
            {
                lista.Add(item);
            }
            foreach (var item in nac)
            {
                lista.Add(item);
            }
            return lista;
        }

        public static void agregar(Nacionales n)
        {
            using (var context = new BaseContext())
            {
                context.Nacionales.Add(n);
                context.SaveChanges();
            }
        }

        public static void agregar(Internacionales i)
        {
            using (var context = new BaseContext())
            {
                context.Internacionales.Add(i);
                context.SaveChanges();
            }
        }

        public static List<PaqueteLugar> listarPaquetesLugar()
        {
            using (var context = new BaseContext())
            {
                return context.PaqueteLugar.ToList();
            }
        }

        public static void agregar(PaqueteLugar pl)
        {
            using (var context = new BaseContext())
            {
                context.PaqueteLugar.Add(pl);
                context.SaveChanges();
            }
        }
    }
}
