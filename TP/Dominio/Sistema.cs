using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Dominio
{
    public class Sistema
    {
        private List<Cliente> lstClientes;
        private List<PaquetesVendidos> lstPaquetes;
        private List<Factura> lstFacturas;
        private List<Lugar> lstLugar;
        private List<PaqueteLugar> lstPaqueteLugar;

        public Sistema(List<Cliente> lstClientes,List<PaquetesVendidos> lstPaquetes,
            List<Factura> lstFacturas, List<Lugar> lstLugar, List<PaqueteLugar> lstPaqueteLugar)
        {
            this.lstClientes = lstClientes;
            this.lstPaquetes = lstPaquetes;
            this.lstFacturas = lstFacturas;
            this.lstLugar = lstLugar;
            this.lstPaqueteLugar = lstPaqueteLugar;
        }

        public List<Cliente> LstClientes
        {
            get { return lstClientes; }
            set { lstClientes = value; }
        }

        public List<PaquetesVendidos> LstPaquetes
        {
            get { return lstPaquetes; }
            set { lstPaquetes = value; }
        }

        public List<Factura> LstFacturas
        {
            get { return lstFacturas; }
            set { lstFacturas = value; }
        }

        public List<Lugar> LstLugar
        {
            get { return lstLugar; }
            set { lstLugar = value; }
        }

        public List<PaqueteLugar> LstPaqueteLugar
        {
            get { return lstPaqueteLugar; }
            set { lstPaqueteLugar = value; }
        }

        public void mostrarLstClientes()
        {
            foreach (var item in lstClientes)
            {
                item.mostrar();
            }
        }

        public void mostrarLstLugares()
        {
            foreach (var item in lstLugar)
            {
                Console.WriteLine("");
                item.mostrar();
            }
        }

        public void mostrarLstPaquetesActivos()
        {
            foreach (var item in lstPaquetes)
            {
                if (item.Activo)
                {
                    List<PaqueteLugar> pl = lstPaqueteLugar.FindAll(x => x.IdPaquete == item.Id);
                    List<Lugar> lugares = new List<Lugar>();
                    foreach ( var paqueteLug in pl)
                    {
                        lugares.Add(lstLugar.Find(x => x.Id == paqueteLug.IdLugar));
                    }
                    item.mostrar(lugares);
                }
                
            }

            
        }

        public void mostrarLstFacuras()
        {
            foreach (var factura in LstFacturas)
            {
                Console.WriteLine("");
                Cliente c = lstClientes.Find(x => x.Dni == factura.IdDniCliente);
                PaquetesVendidos p = lstPaquetes.Find(x => x.Id == factura.IdPaquete);
                Console.WriteLine("------DATOS DEL CLIENTE------");
                c.mostrar();
                Console.WriteLine("------PAQUETE ADQUIRIDO------");
                List<PaqueteLugar> pl = lstPaqueteLugar.FindAll(x => x.IdPaquete == p.Id);
                List<Lugar> lugares = new List<Lugar>();
                foreach (var paqueteLug in pl)
                {
                    lugares.Add(lstLugar.Find(x => x.Id == paqueteLug.IdLugar));
                }
                p.mostrar(lugares);
            }
        }

        public void mostrarLstFacturas(Cliente c)
        {
            bool encontro = false;
            foreach (var factura in LstFacturas)
            {
                //Cliente c = lstClientes.Find(x => x.Dni == factura.IdDniCliente);
                if (factura.IdDniCliente == c.Dni)
                {
                    Console.WriteLine("");
                    PaquetesVendidos p = lstPaquetes.Find(x => x.Id == factura.IdPaquete);
                    Console.WriteLine("------DATOS DEL CLIENTE------");
                    c.mostrar();
                    Console.WriteLine("------PAQUETE ADQUIRIDO------");
                    List<PaqueteLugar> pl = lstPaqueteLugar.FindAll(x => x.IdPaquete == p.Id);
                    List<Lugar> lugares = new List<Lugar>();
                    foreach (var paqueteLug in pl)
                    {
                        lugares.Add(lstLugar.Find(x => x.Id == paqueteLug.IdLugar));
                    }
                    p.mostrar(lugares);
                    encontro = true;

                } 
                if (!encontro)
                {
                    Console.WriteLine("No existen facturas de este cliente");
                }
                
            }
        }

    }
}
