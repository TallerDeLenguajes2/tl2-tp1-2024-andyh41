using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace EmpresaDeCadetes
{

    public class Cadeteria {
        private string nombre;
        private string telefono;
        private List<Cadete> listaCadetes = new List<Cadete>();
        private List<Pedidos> listaPedidos = new List<Pedidos>();

        public string Nombre { get => nombre; set => nombre = value; }
        public string Telefono { get => telefono; set => telefono = value; }


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
                            //trabajador.AgregarPedido(pedir);
                            pedir.CadeteAsignado = trabajador;
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

            //foreach (Cadete trabajador in listaCadetes)
            //{ 
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
            //}

       }

        public int JornalACobrar(int idcade){
            return PedidosEnviados(idcade)*500;
        } 
        public int TotalPedidos(int idcade){
            var pedidosTotal = from ped in listaPedidos
                                where ped.CadeteAsignado.Id == idcade
                                select ped;
            return pedidosTotal.Count();
        }

        public int PedidosEnviados(int idcade){
            var pedidosFinalizados = from ped in listaPedidos
                                where ped.CadeteAsignado.Id == idcade && ped.EstadoPedido == Estado.Finalizado 
                                select ped;
            return pedidosFinalizados.Count();
        }

    


        public string Informe(){

            var sb = new StringBuilder();
            int envios=0;
            //Console.Clear();
            sb.AppendLine("=============== INFORME ================");
            foreach (Cadete cad in this.listaCadetes)
            {
                sb.AppendLine("----------------------------------------------");
                sb.AppendLine($"Nombre del cadete: {cad.Nombre}");
                sb.AppendLine($"Total de pedidos: {TotalPedidos(cad.Id)}");
                sb.AppendLine($"Pedidos finalizados: {PedidosEnviados(cad.Id)}");
                sb.AppendLine($"Jornal a cobrar: {JornalACobrar(cad.Id)}");
                sb.AppendLine("----------------------------------------------");
                sb.AppendLine(" ");
                envios+=PedidosEnviados(cad.Id);
                //Console.ReadKey();
            }
            sb.AppendLine($"-------- TOTAL DE ENVIOS: {envios} ----------");
            sb.AppendLine($"-------- PROMEDIO DE ENVIOS POR CADETE: {envios/this.listaCadetes.Count()} ----------");
            //Console.ReadKey();
            return sb.ToString();
        }

    }

}