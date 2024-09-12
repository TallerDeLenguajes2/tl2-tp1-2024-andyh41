using System;
using System.Collections.Generic;
using System.Linq;
using System.IO;
using System.Diagnostics.Contracts;
using EmpresaDeCadetes;
using CargaDeDatos;

public static class Program
{
    static void Main(string[] args)
    {
        // carga cvs de cadeteria y asigna a una variable llamada sucursal
        var sucursal = CargarDatos.ArchivoCVScadeteria(); 
        // carga cadetes a la cadeteria
        CargarDatos.ArchivoCVScadete(sucursal); 

        int opcion=5;
        
        do
        {
            CargarDatos.Menu(); // muestra el menu
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
                        
                        var pedido = new Pedidos(name, dir, tel, refe, obser);
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
                        // pide el id del cadete inicial, cadete nuevo, el pedido y controla que sean un num entero
                       
                        Console.WriteLine("Ingrese el id del cadete actual: ");
                        int.TryParse(Console.ReadLine(), out int idcadete1);
                       
                        Console.WriteLine("Ingrese el id del cadete nuevo: ");
                        int.TryParse(Console.ReadLine(), out int idcadete2);
                    
                        Console.WriteLine("Ingrese el id del pedido: ");
                        int.TryParse(Console.ReadLine(), out int idpedido);

                        // Reasigna el pedido
                        sucursal.ReAsignarpedido(idcadete1, idcadete2, idpedido);
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

        int envios=0;
        Console.Clear();
        Console.WriteLine("============= INFORME ================");
        foreach (Cadete cad in sucursal.ListaCadetes)
        {
            Console.WriteLine("----------------------------------------------");
            Console.WriteLine($"Nombre del cadete: {cad.Nombre}");
            Console.WriteLine($"Total de pedidos: {cad.ListaPedidos.Count()}");
            Console.WriteLine($"Pedidos finalizados: {cad.TotalPedidos}");
            Console.WriteLine("----------------------------------------------");
            Console.WriteLine(" ");
            //envios+=cad.TotalPedidos;
            Console.ReadKey();
        }
        Console.WriteLine($"-------- TOTAL DE ENVIOS: {envios} ----------");
        Console.WriteLine($"-------- PROMEDIO DE ENVIOS POR CADETE: {envios/sucursal.ListaCadetes.Count()} ----------");
        Console.ReadKey();
    }
}
