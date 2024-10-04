using System;
using System.Collections.Generic;
using System.Linq;
using System.IO;
using EmpresaDeCadetes;
using CargaDeDatos;

public static class Program
{
    static void Main(string[] args)
    {
        // cargar los datos de cadeteria y catedes por archivo Json o CSV dependiendo de la opcion elegida
        Console.WriteLine("1. CSV");
        Console.WriteLine("2. JSON");
        Console.Write("\nSeleccione el tipo de acceso a datos:");
        string carga = Console.ReadLine();

        Cadeteria sucursal = null;

            if (carga=="1") // carga de datos desde CSV
            {
                var acceso = new AccesoCSV("ArchivosCSV/Cadeteria.csv", "ArchivosCSV/Cadete.csv");
                sucursal = acceso.CargarCadeteria();
                List<Cadete> cadetes = acceso.CargarCadetes();
                foreach (Cadete uno in cadetes)
                {
                    sucursal.AgregarCadete(uno);
                }
            }else // carga de datos desde JSON
            {
                var acceso = new AccesoJSON("ArchivosJson/Cadeteria.json", "ArchivosJson/Cadetes.json");
                sucursal = acceso.CargarCadeteria();
                var cadetes = acceso.CargarCadetes();
                foreach (Cadete uno in cadetes)
                {
                    sucursal.AgregarCadete(uno);
                }
            }
            
        
        Console.Clear();

        int opcion=5;
        
        do
        {
            MiMenu.menu(); // muestra el menu
            Console.WriteLine(" Ingrese una opcion: "); // seleccionar la opcion del menu
            if (int.TryParse(Console.ReadLine(), out opcion)) // conviente el string a int y controla la salida correcta de int
            {
                Console.Clear();
                Console.WriteLine(" ");
                switch (opcion) // ejecuta la opcion elegida del menu
                {
                    case 1:
                        Console.WriteLine(" ======== Para realizar un pedido ========= ");

                        Console.WriteLine(" Ingrese nombre: ");
                        string name = Console.ReadLine();
                        Console.WriteLine(" Ingrese direccion: ");
                        string dir = Console.ReadLine();
                        Console.WriteLine(" Ingrese telefono: ");
                        string tel = Console.ReadLine();
                        Console.WriteLine(" Ingrese referencia a la direccion: ");
                        string refe = Console.ReadLine();
                        Console.WriteLine(" Ingrese observacion del pedido: ");
                        string obser = Console.ReadLine();
                        
                        var pedido = new Pedidos(name, dir, tel, refe, obser, null);
                        sucursal.AgregarPedido(pedido);
                        Console.WriteLine($"--- El id de su pedido es: {pedido.Nro} ---");
                        Console.WriteLine(" ");
                    break;


                    case 2:
                        Console.WriteLine(" ======== Para asignar un pedido a un cadete ========= ");
                      
                        // pide el id del cadete y el pedido 
                        Console.WriteLine("Ingrese el id del cadete: ");
                        int.TryParse(Console.ReadLine(), out int idCad);
                        Console.WriteLine("Ingrese el id del pedido: ");
                        int.TryParse(Console.ReadLine(), out int idPed);

                        // asigna el pedido al cadete
                        sucursal.Asignarpedido(idCad, idPed);
                        Console.WriteLine(" ");   
                    break;


                    case 3:
                        Console.WriteLine(" ======== Para cambiar el estado de un pedido ========= ");
                       
                        Console.WriteLine("Ingrese el id del pedido: ");
                        int.TryParse(Console.ReadLine(), out int idPedir);
                       
                        Console.WriteLine("Ingrese la opcion a la que quiere cambiar el estado del pedido: ");
                        Console.WriteLine("1. Aceptado");
                        Console.WriteLine("2. En Curso");
                        Console.WriteLine("3. Entregado");
                        int.TryParse(Console.ReadLine(), out int idCambio);

                        sucursal.EstadoPedido(idPedir, idCambio);
                        Console.WriteLine(" ");  
                    break;


                    case 4:
                        Console.WriteLine(" ======== Para RE asignar un pedido a otro cadete ========= ");
                       
                        Console.WriteLine("Ingrese el id del cadete nuevo: ");
                        int.TryParse(Console.ReadLine(), out int idcadete1);
                    
                        Console.WriteLine("Ingrese el id del pedido: ");
                        int.TryParse(Console.ReadLine(), out int idpedido);

                        // Reasigna el pedido
                        sucursal.Asignarpedido(idcadete1, idpedido);
                        Console.WriteLine(" ");  
                    break;


                    case 0:
                        Console.WriteLine(" ---- Salio del menu, a continuacion se detallara el informe final ---- ");
                        Console.WriteLine(" ");
                    break;

                    default:
                        Console.WriteLine("OPCION NO VALIDA");
                        Console.WriteLine("debe ser un numero del 0 al 4");
                    break;
                }
            }else
            {
                Console.WriteLine("OPCION NO VALIDA");
                Console.WriteLine("debe ser un numero del 0 al 4");
            }


        } while (opcion!=0);

        Console.Clear();
        Console.WriteLine(sucursal.Informe());
    }
}
