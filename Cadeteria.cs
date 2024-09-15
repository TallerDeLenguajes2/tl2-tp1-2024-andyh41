using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace EmpresaDeCadetes
{

    public class Cadeteria {
        private string nombre;
        private string telefono;
        private List<Cadete> listaCadetes = new List<Cadete>();
        private List<Pedidos> listaPedidos = new List<Pedidos>();

        public string Nombre { get => nombre; set => nombre = value; }
        public string Telefono { get => telefono; set => telefono = value; }
        //public List<Cadete> ListaCadetes { get => listaCadetes; set => listaCadetes = value; }
        //public List<Pedidos> ListaPedidos { get => listaPedidos; set => listaPedidos = value; }

        public void AgregarCadete(Cadete cadete){
            listaCadetes.Add(cadete);
        }

        public void AgregarPedido(Pedidos pedido){
            listaPedidos.Add(pedido);
        }

        public Cadeteria(string nombre, string telefono){
 
            Nombre = nombre;
            Telefono = telefono;
           
        }

       public void Asignarpedido(int idcadete, int idpedido)
       {
            foreach (Cadete trabajador in listaCadetes)// lista de cadetes con min o may?
            {
                if (idcadete==trabajador.Id)
                {
                    foreach (Pedidos pedir in listaPedidos)
                    {
                        if (idpedido==pedir.Nro)
                        {
                            trabajador.AgregarPedido(pedir);
                        }
                    }
                }
            }

            /*var elcadete = from trabajador in ListaCadetes
                          where trabajador.Id == idcadete
                          select trabajador;
            var elpedido = from pedir in ListaPedidos
                          where pedir.Nro == idpedido
                          select pedir;
            
            elcadete[0].AgregarPedido(elpedido[0]);*/
       }


       public void EstadoPedido(int idpedido, int numerocambio){

            foreach (Cadete trabajador in listaCadetes)// lista de cadetes con min o may?
            { 
                foreach (Pedidos pedir in listaPedidos)// se cambia el estado en la lista de pedidos de cadetedes y en la lista de pedidos de la cadeteria?
                {
                    if (idpedido==pedir.Nro)
                    {
                        Estado cambio = Estado.Aceptado;
                        switch (numerocambio)
                        {
                            case 1:
                                cambio = Estado.Aceptado;
                            break;
                            case 2:
                                cambio = Estado.EnCurso;
                            break;
                            case 3:
                                cambio = Estado.Finalizado;
                            break;
                        }
                        pedir.CambiarEstado(cambio);
                    }
                }   
            }

       }

        public void ReAsignarpedido(int idcadete, int idnuevocadete, int idpedido)
        {
            foreach (Cadete trabajador in listaCadetes)// lista de cadetes con min o may?
            {
                if (idcadete==trabajador.Id)
                {
                    foreach (Pedidos pedir in listaPedidos)
                    {
                        if (idpedido==pedir.Nro)
                        {
                            trabajador.EliminarPedido(pedir);
                        }
                    }
                }
            }
            Asignarpedido(idnuevocadete, idpedido);
        }




        public void Informe(){

        int envios=0;
        Console.Clear();
        Console.WriteLine("============= INFORME ================");
        foreach (Cadete cad in this.listaCadetes)
        {
            Console.WriteLine("----------------------------------------------");
            Console.WriteLine($"Nombre del cadete: {cad.Nombre}");
            Console.WriteLine($"Total de pedidos: {cad.TotalPedidos()}");
            Console.WriteLine($"Pedidos finalizados: {cad.PedidosEnviados()}");
            Console.WriteLine("----------------------------------------------");
            Console.WriteLine(" ");
            envios+=cad.PedidosEnviados();
            Console.ReadKey();
        }
        Console.WriteLine($"-------- TOTAL DE ENVIOS: {envios} ----------");
        Console.WriteLine($"-------- PROMEDIO DE ENVIOS POR CADETE: {envios/this.listaCadetes.Count()} ----------");
        Console.ReadKey();
        }

    }
}