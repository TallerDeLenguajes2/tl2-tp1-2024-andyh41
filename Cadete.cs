using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace EmpresaDeCadetes
{
    public class Cadete {
        private int id;
        private string nombre;
        private string direccion;
        private string telefono;
        private List<Pedidos> listaPedidos = new List<Pedidos>();

        public int Id { get => id; set => id = value; }
        public string Nombre { get => nombre; set => nombre = value; }
        public string Direccion { get => direccion; set => direccion = value; }
        public string Telefono { get => telefono; set => telefono = value; }
        //public List<Pedidos> listaPedidos { get => listaPedidos; set => listaPedidos = value; }

        public void AgregarPedido(Pedidos pedido){
            listaPedidos.Add(pedido);
        }

        public void EliminarPedido(Pedidos pedido){
            listaPedidos.Remove(pedido);
        }
        public int JornalACobrar(){
            return this.PedidosEnviados() * 500;
        }

        public int PedidosEnviados(){
            var pedidosTerminados = from ped in listaPedidos
                              where ped.EstadoPedido == Estado.Finalizado
                              select ped;
            return pedidosTerminados.Count();
        }

        public int TotalPedidos(){
            return listaPedidos.Count();
        }

        private static int nextId = 0;
        public Cadete(string nombre, string direccion, string telefono){

            Id = nextId++; 
            Nombre = nombre;
            Direccion = direccion;
            Telefono = telefono;
         
        }
    
    }
}