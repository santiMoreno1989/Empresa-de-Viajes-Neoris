using Datos;
using Dominio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Empresa
{
    class Program
    {
        static void Main(string[] args)
        {
            Sistema sistema = new Sistema(RepositorioCliente.listarClientes(), RepositorioPaquetes.listarPaquetes(), RepositorioFactura.listarFactura(), RepositorioLugar.listarLugares(), RepositorioPaquetes.listarPaquetesLugar());

            ConsoleKeyInfo opcion;
            do
            {
                Console.WriteLine("");
                Console.WriteLine("Ingrese una opción:");
                Console.WriteLine("[1] - Ingrese un Cliente.");
                Console.WriteLine("[2] - Mostrar datos de todos los clientes.");
                Console.WriteLine("[3] - Mostrar datos de un cliente.");
                Console.WriteLine("[4] - Ingrese un nuevo Paquete."); 
                //Console.WriteLine("[5] - Dar de baja un paquete.");
                Console.WriteLine("[5] - Mostrar Paquetes activos.");
                Console.WriteLine("[6] - Crear nueva factura.");
                Console.WriteLine("[7] - Mostrar todas las facturas.");
                Console.WriteLine("[8] - Mostrar todas las facturas de un cliente.");
                Console.WriteLine("Esc - Salir");

                do
                {
                    opcion = Console.ReadKey(true);
                } while (((int)opcion.KeyChar != 27) && (opcion.KeyChar < '1' || opcion.KeyChar > '8'));


                switch (opcion.KeyChar)
                {
                    
                    case '1':
                        int id = 1;
                        int nrocliente;
                        string apellido;
                        string nombre;
                        string nacionalidad;
                        string provincia;
                        string direccion;
                        int telefono;
                        string razonSocial;
                        Cliente cliente;
                        Console.WriteLine("");
                        Console.WriteLine("[1] - Tipo de Cliente Particular.");
                        Console.WriteLine("[2] - Tipo de Cliente Corporativo.");
                        Console.WriteLine("[3] - VOLVER MENU PRINCIPAL");
                        ConsoleKeyInfo opcion2;
                        do
                        {
                            opcion2 = Console.ReadKey(true);
                        } while(opcion2.KeyChar < '1' || opcion2.KeyChar > '3');
                        if (opcion2.KeyChar != '3')
                        {
                            

                            Console.WriteLine("");
                            Console.WriteLine("Ingrese el numero de identificacion del cliente:");
                            int.TryParse(Console.ReadLine(), out nrocliente);
                            cliente = sistema.LstClientes.Find(x => x.Dni == nrocliente);
                            if (cliente != null)
                            {
                                Console.WriteLine("El cliente ya existe");
                                cliente.mostrar();

                            }
                            else
                            {
                                List<Particular> lstAuxP = RepositorioCliente.listarParticular();
                                List<Corporativa> lstAuxC = RepositorioCliente.listarCorporativa();
                                if (lstAuxP.Count != 0 || lstAuxC.Count != 0)
                                {
                                    if (lstAuxP.Count != 0 && lstAuxC.Count != 0)
                                    {
                                        if (lstAuxP[lstAuxP.Count - 1].Id > lstAuxC[lstAuxC.Count - 1].Id)
                                        {
                                            id = lstAuxP[lstAuxP.Count - 1].Id + 1;
                                        }
                                        else
                                        {
                                            id = lstAuxC[lstAuxC.Count - 1].Id + 1;
                                        }
                                    }
                                    else
                                    {
                                        if (lstAuxP.Count == 0)
                                        {
                                            id = lstAuxC[lstAuxC.Count - 1].Id + 1;
                                        }
                                        else
                                        {
                                            id = lstAuxP[lstAuxP.Count - 1].Id + 1;
                                        }
                                    }
                                }

                                Console.WriteLine("Ingrese Apellido");
                                apellido = Console.ReadLine();
                                Console.WriteLine("Ingrese nombre");
                                nombre = Console.ReadLine();
                                Console.WriteLine("Ingrese nacionalidad");
                                nacionalidad = Console.ReadLine();
                                Console.WriteLine("Ingrese provincia");
                                provincia = Console.ReadLine();
                                Console.WriteLine("Ingrese direccion");
                                direccion = Console.ReadLine();
                                Console.WriteLine("Ingrese telefono");
                                int.TryParse(Console.ReadLine(), out telefono);

                                switch (opcion2.KeyChar)
                                {
                                    case '1':

                                        Particular p = new Particular(id, nrocliente, apellido, nombre, nacionalidad, provincia, direccion, telefono);
                                        sistema.LstClientes.Add(p);
                                        RepositorioCliente.agregar(p);
                                        break;

                                    case '2':

                                        Console.WriteLine("Ingrese razon social");
                                        razonSocial = Console.ReadLine();
                                        Console.WriteLine("Ingrese CUIT");
                                        string cuit = Console.ReadLine();
                                        Corporativa cor = new Corporativa(id, nrocliente, apellido, nombre, nacionalidad, provincia, direccion, telefono, razonSocial, cuit);
                                        sistema.LstClientes.Add(cor);
                                        RepositorioCliente.agregar(cor);
                                        break;
                                }

                            }
                        }
                        break;

                    case '2':
                        if (sistema.LstClientes.Count == 0)
                        {
                            Console.WriteLine("");
                            Console.WriteLine("No existen clientes en el sistema");
                        }
                        else
                        {
                            Console.WriteLine("");
                            Console.WriteLine("-------CLIENTES-------");
                            sistema.mostrarLstClientes();
                        }
                        

                        break;

                    case '3':
                       

                        if (sistema.LstClientes.Count == 0)
                        {
                            Console.WriteLine("");
                            Console.WriteLine("No existen clientes en el sistema");
                        }
                        else
                        {
                            Console.WriteLine("");
                            Console.WriteLine("Ingrese el numero de identificacion del cliente:");
                            int.TryParse(Console.ReadLine(), out nrocliente);
                            Cliente c = sistema.LstClientes.Find(x => x.Dni == nrocliente);
                            if (c != null)
                            {
                                c.mostrar();
                            }
                            else
                            {
                                Console.WriteLine("El cliente ingresado no existe");
                            }
                        }
                        
                        break;

                    case '4':
                        Console.WriteLine("");
                        Console.WriteLine("[1] - Tipo de paquete NACIONAL.");
                        Console.WriteLine("[2] - Tipo de paquete INTERNACIONAL.");
                        Console.WriteLine("[3] - VOLVER MENU ");

                        do
                        {
                            opcion2 = Console.ReadKey(true);
                        } while (opcion2.KeyChar < '1' || opcion2.KeyChar > '3');
                        if (opcion2.KeyChar != '3')
                        {

                            List<Nacionales> lstAuxN = RepositorioPaquetes.listarNacionales();
                            List<Internacionales> lstAuxI = RepositorioPaquetes.listarInternacionales();
                            id = 1;
                            if (lstAuxN.Count != 0 || lstAuxI.Count != 0)
                            {
                                if (lstAuxN.Count != 0 && lstAuxI.Count != 0)
                                {
                                    if (lstAuxN[lstAuxN.Count - 1].Id > lstAuxI[lstAuxI.Count - 1].Id)
                                    {
                                        id = lstAuxN[lstAuxN.Count - 1].Id + 1;
                                    }
                                    else
                                    {
                                        id = lstAuxI[lstAuxI.Count - 1].Id + 1;
                                    }
                                }
                                else
                                {
                                    if (lstAuxN.Count == 0)
                                    {
                                        id = lstAuxI[lstAuxI.Count - 1].Id + 1;
                                    }
                                    else
                                    {
                                        id = lstAuxN[lstAuxN.Count - 1].Id + 1;
                                    }
                                }
                            }
                            Console.WriteLine("");
                            Console.WriteLine("Ingrese el nombre del paquete");
                            nombre = Console.ReadLine();
                            float precio;
                            Console.WriteLine("Ingrese el precio del paquete");
                            float.TryParse(Console.ReadLine(), out precio);
                            int dias;
                            Console.WriteLine("Ingrese la cantidad de dias del paquete");
                            int.TryParse(Console.ReadLine(), out dias);
                            Console.WriteLine("Ingrese la fecha del paquete");
                            DateTime fecha;
                            DateTime.TryParse(Console.ReadLine(), out fecha);



                            switch (opcion2.KeyChar)
                            {
                                case '1':
                                    PaquetesVendidos pa = new Nacionales(id, nombre, precio, dias, fecha, true);
                                    RepositorioPaquetes.agregar((Nacionales)pa);
                                    sistema.LstPaquetes.Add(pa);

                                    ConsoleKeyInfo opc;

                                    do
                                    {
                                        Console.WriteLine("Ingrese los lugares pertenecientes al paquete");
                                        Console.WriteLine("SELECCIONE EL IDENTIFICADOR EN CASO DE NO ESTAR INGRESE 0");
                                        sistema.mostrarLstLugares();
                                        int.TryParse(Console.ReadLine(), out id);
                                        Lugar l = sistema.LstLugar.Find(x => x.Id == id);
                                        if (l == null)
                                        {
                                            Console.WriteLine("Ingrese el nombre del lugar que desea agregar");
                                            nombre = Console.ReadLine();
                                            id = 1;
                                            if (sistema.LstLugar.Count != 0)
                                            {
                                                id = sistema.LstLugar[sistema.LstLugar.Count - 1].Id + 1;
                                            }
                                            l = new Lugar(id, nombre);
                                            RepositorioLugar.agregar(l);
                                            sistema.LstLugar.Add(l);
                                        }
                                        PaqueteLugar pl = new PaqueteLugar(pa.Id, l.Id);
                                        RepositorioPaquetes.agregar(pl);
                                        sistema.LstPaqueteLugar.Add(pl);


                                        do
                                        {

                                            Console.WriteLine("Desea ingresar otro lugar para el paquete (1=SI / 2=NO)");
                                            opc = Console.ReadKey(true);
                                        } while ((opc.KeyChar < '1' || opc.KeyChar > '2'));
                                    } while (opc.KeyChar == '1');

                                    break;

                                case '2':
                                    Console.WriteLine("Se necesita visa para este viaje? (1=SI / 2=NO)");
                                    ConsoleKeyInfo op;
                                    do
                                    {
                                        op = Console.ReadKey(true);
                                    } while ((op.KeyChar < '1' || op.KeyChar > '2'));
                                    bool visa;
                                    if (op.KeyChar == '1')
                                    {
                                        visa = true;
                                    }
                                    else
                                    {
                                        visa = false;
                                    }
                                    pa = new Internacionales(id, nombre, precio, dias, fecha, true, visa);

                                    RepositorioPaquetes.agregar((Internacionales)pa);
                                    sistema.LstPaquetes.Add(pa);



                                    do
                                    {
                                        Console.WriteLine("Ingrese los lugares pertenecientes al paquete");
                                        Console.WriteLine("SELECCIONE EL IDENTIFICADOR, EN CASO DE NO ESTAR INGRESE 0");
                                        sistema.mostrarLstLugares();
                                        int.TryParse(Console.ReadLine(), out id);
                                        Lugar l = sistema.LstLugar.Find(x => x.Id == id);
                                        if (l == null)
                                        {
                                            Console.WriteLine("Ingrese el nombre del lugar que desea agregar");
                                            nombre = Console.ReadLine();
                                            l = new Lugar(sistema.LstLugar[sistema.LstLugar.Count - 1].Id + 1, nombre);
                                            RepositorioLugar.agregar(l);
                                            sistema.LstLugar.Add(l);
                                        }
                                        PaqueteLugar pl = new PaqueteLugar(pa.Id, l.Id);
                                        RepositorioPaquetes.agregar(pl);
                                        sistema.LstPaqueteLugar.Add(pl);


                                        do
                                        {

                                            Console.WriteLine("Desea ingresar otro lugar para el paquete (1=SI / 2=NO)");
                                            op = Console.ReadKey(true);
                                        } while ((op.KeyChar < '1' || op.KeyChar > '2'));
                                    } while (op.KeyChar == '1');


                                    break;

                            }

                        }

                        break;


                    /*case '5':
                        Console.WriteLine("PAQUETES ACTIVOS");
                        sistema.mostrarLstPaquetesActivos();
                        Console.WriteLine("Ingrese el identificador del paquete a dar de baja");
                        int.TryParse(Console.ReadLine(), out id);
                        PaquetesVendidos pv = sistema.LstPaquetes.Find(x => x.Id == id && x.Activo);
                        if (pv == null)
                        {
                            Console.WriteLine("Paquete solicitado no se encuentra o no esta activo");
                        }
                        else
                        {
                            pv.Activo = false;
                            Console.WriteLine("NO SE VOLVERA A MOSTRAR EN PAQUETES ACTIVOS");
                        }

                        break;*/

                    case '5':
                        
                        if (sistema.LstPaquetes.Count == 0)
                        {
                            Console.WriteLine("");
                            Console.WriteLine("No tiene paquetes activos");
                        }
                        else
                        {
                            Console.WriteLine("");
                            Console.WriteLine("PAQUETES ACTIVOS");
                            sistema.mostrarLstPaquetesActivos();
                        }
                        
                        break;

                    case '6':
                        
                        PaquetesVendidos pv;
                        Console.WriteLine("");
                        Console.WriteLine("------PAQUETES ACTIVOS------");
                        if (sistema.LstPaquetes.Count == 0)
                        {
                            Console.WriteLine("No tiene paquetes activos");
                        }
                        else
                        {
                            do
                            {
                                sistema.mostrarLstPaquetesActivos();
                                Console.WriteLine("");
                                Console.WriteLine("Ingrese el identificador del paquete deseado");
                                Console.WriteLine("INGRESE 0 PARA VOLVER AL MENU PRINCIPAL Y CANCELAR LA FACTURA");
                                int.TryParse(Console.ReadLine(), out id);
                                pv = sistema.LstPaquetes.Find(x => x.Id == id && x.Activo);
                                if (id != 0)
                                {
                                    
                                    if (pv != null)
                                    {
                                        if (sistema.LstClientes.Count == 0)
                                        {
                                            Console.WriteLine("No existen clientes en el sistema");
                                        }
                                        else
                                        {
                                            do
                                            {
                                                Console.WriteLine("");
                                                Console.WriteLine("Ingrese el numero de identificacion del cliente:");
                                                Console.WriteLine("INGRESE 0 PARA VOLVER AL MENU PRINCIPAL Y CANCELAR LA FACTURA");
                                                int.TryParse(Console.ReadLine(), out nrocliente);
                                                cliente = sistema.LstClientes.Find(x => x.Dni == nrocliente);
                                                if (nrocliente != 0)
                                                {
                                                    if (cliente != null)
                                                    {
                                                        Factura fac = sistema.LstFacturas.Find(x => x.IdPaquete == pv.Id && x.IdDniCliente == cliente.Dni);
                                                        
                                                        if (fac.IdDniCliente!=cliente.Dni)
                                                        {

                                                            Factura f = new Factura(pv.Id, cliente.Dni);
                                                            RepositorioFactura.agregar(f);
                                                            sistema.LstFacturas.Add(f);
                                                            Console.WriteLine("Factura creada");
                                                        }
                                                        else
                                                        {
                                                            Console.WriteLine("YA EXISTE UNA FACTURA CON EL CLIENTE DADO Y EL PAQUETE DADO");
                                                        }
                                                    }
                                                    else
                                                    {
                                                        Console.WriteLine("Cliente inexistente, el numero de identificacion no fue encontrado");
                                                    }
                                                }
                                            } while (nrocliente != 0 && cliente == null);
                                        }


                                    }
                                    else
                                    {
                                        Console.WriteLine("Paquete inexistente, el numero de identificacion no fue encontrado");
                                    }
                                }
                            } while (id !=0 && pv == null);
                        }
                            

                        break;

                    case '7':
                        if (sistema.LstFacturas.Count == 0)
                        {
                            Console.WriteLine("");
                            Console.WriteLine("No existen facturas");

                        }
                        else
                        {
                            Console.WriteLine("");
                            Console.WriteLine("----TODAS LAS FACTURAS----");
                            sistema.mostrarLstFacuras();
                        }
                        
                        break;

                    case '8':
                        if (sistema.LstClientes.Count == 0)
                        {
                            Console.WriteLine("");
                            Console.WriteLine("No existen clientes");

                        }
                        else
                        {
                            Console.WriteLine("");
                            Console.WriteLine("Ingrese el numero de identificacion del cliente:");
                            int.TryParse(Console.ReadLine(), out nrocliente);
                            cliente = sistema.LstClientes.Find(x => x.Dni == nrocliente);
                            if (cliente == null)
                            {
                                Console.WriteLine("Cliente inexistente");
                            }
                            else
                            {
                                Console.WriteLine("----TODAS LAS FACTURAS DEL CLIENTE: {0}, {1}----", cliente.Apellido, cliente.Nombre);
                                sistema.mostrarLstFacturas(cliente);
                            }
                        }
                        
                        break;

                }

            } while ((int)opcion.KeyChar != 27);

            Console.WriteLine("");
            Console.WriteLine("Listo, Saliste");
            Console.ReadKey();
            
        }
    }
}
