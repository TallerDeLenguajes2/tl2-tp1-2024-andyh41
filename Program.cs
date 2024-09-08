using System;
using System.Collections.Generic;
using EmpresaDeCadetes;
using System.IO;
using System.Diagnostics.Contracts;


public static class Program
{
    static void Main(string[] args)
    {
        // cargar cvs de cadeteria y asignarla a una variable llamada sucursal
        // cargar cadetes
        Console.WriteLine("=======================================");
        Console.WriteLine("                 MENU");
        Console.WriteLine("=======================================");
        Console.WriteLine(" Ingrese una opcion: ");
        Console.WriteLine(" 1. Ingresar un pedido ");
        Console.WriteLine(" 2. Asignar pedido a cadete ");
        Console.WriteLine(" 3. Cambiar pedido de estado ");
        Console.WriteLine(" 4. Reasignar el pedido a otro cadete ");
        Console.WriteLine(" 0. Salir del menu ");
        Console.WriteLine(" ");
        int opcion=5;
        
        do
        {
            if (int.TryParse(Console.ReadLine(), out opcion)) // conviente el string a int y controla la salida correcta de int
            {
                switch (opcion)
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
                        //pedir el id del cadete
                        //pedir el id del pedido
                        sucursal.Asignarpedido(idCAd, idPed);
                        Console.WriteLine(" ");   
                    break;

                    case 3:
                         Console.WriteLine(" ======== Para cambiar el estado de un pedido ========= ");
                        // pedir el id del pedido
                        // pedir el num de estado de cambio 1acep 2encur 3entreg
                        sucursal.EstadoPedido(idPed, idCambio);
                        Console.WriteLine(" ");  
                    break;

                    case 4:
                         Console.WriteLine(" ======== Para RE asignar un pedido a otro cadete ========= ");
                        // pedir id cadete inicial
                        // pedir id cadete final
                        // pedir id del pedido
                        sucursal.ReAsignarpedido(idcadete1, idcadete2, idpedido);
                        Console.WriteLine(" ");  
                    break;

                    case 0:
                        Console.WriteLine(" ---- Salio del menu, a continuacion se detallara el informe final ---- ");
                        Console.WriteLine(" ");
                    break;

                    default:
                        Console.WriteLine("OPCION NO VALIDA");
                        Console.WriteLine("Ingrese un numero del 0 al 4: ");
                    break;
                }
            }else
            {
                Console.WriteLine("OPCION NO VALIDA");
                Console.WriteLine("Ingrese un numero del 0 al 4: ");
            }


        } while (opcion!=0); 


    }
}
