using System;
using System.Collections.Generic;
using System.IO;

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

        public void AgregarPedido(Pedidos pedido){
            listaPedidos.Add(pedido);
        }

        public void EliminarPedido(Pedidos pedido){
            listaPedidos.Remove(pedido);
        }
        public int JornalACobrar(){
            return listaPedidos.Count * 500;
        }

        private static int nextId = 1;
        public Cadete(string nombre, string direccion, string telefono){

            Id = nextId++; 
            Nombre = nombre;
            Direccion = direccion;
            Telefono = telefono;
            Id = id;
         
        }
    
        //internal List<Pedidos> ListaPedidos { get => listaPedidos; set => listaPedidos = value; }
    }
}