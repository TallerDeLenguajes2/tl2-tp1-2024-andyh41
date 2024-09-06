using System;
using System.Collections.Generic;

namespace EmpresaDeCadetes
{

    public enum Estado
    {
        Aceptado,
        EnCurso,
        Finalizado
    }
    public class Pedidos {
        
        private int nro;

        private string obs;

        private Cliente cliente;

        Estado estadoPedido;

        public int Nro { get => nro; set => nro = value; }
        public string Obs { get => obs; set => obs = value; }
        public Estado EstadoPedido { get => estadoPedido; set => estadoPedido = value; }

        private static int nextNumeroPedido = 1;

        public Pedidos(string nombre, string direccion, string telefono, string refDeDireccion, string obs){

            Nro = nextNumeroPedido++;
            Obs = obs;
            EstadoPedido = Estado.Aceptado;

            this.cliente = new Cliente(){
                Nombre = nombre,
                Direccion = direccion,
                Telefono = telefono,
                RefDeDireccion = refDeDireccion
            };
        }

        public void CambiarEstado(Estado estado)
        {
            EstadoPedido = estado;
        }

        public void VerDireccionCliente(){
            Console.WriteLine("Direccion: ", this.cliente.Direccion);
        }
        public void VerDatosCliente(){
            Console.WriteLine("=======================================");
            Console.WriteLine("         Datos del Cliente");
            Console.WriteLine("=======================================");
            Console.WriteLine("Nombre: ",this.cliente.Nombre);
            VerDireccionCliente();
            Console.WriteLine("Telefono: ", this.cliente.Telefono);
            Console.WriteLine("Referencia de direccion: ", this.cliente.RefDeDireccion);
            Console.WriteLine("=======================================");
            Console.WriteLine(" ");
        }
 
        

    }
    public class Cliente {
        private string nombre;
        private string direccion;
        private string telefono;
        private string refDeDireccion;

        public string Nombre { get => nombre; set => nombre = value; }
        public string Direccion { get => direccion; set => direccion = value; }
        public string Telefono { get => telefono; set => telefono = value; }
        public string RefDeDireccion { get => refDeDireccion; set => refDeDireccion = value; }
    }


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

    public class Cadeteria {
        private string nombre;
        private string telefono;
        private List<Cadete> listaCadetes = new List<Cadete>();

        public string Nombre { get => nombre; set => nombre = value; }
        public string Telefono { get => telefono; set => telefono = value; }

        public void AgregarCadete(Cadete cadete){
            listaCadetes.Add(cadete);
        }

        public Cadeteria(string nombre, string telefono){
 
            Nombre = nombre;
            Telefono = telefono;
           
        }

        //internal List<Cadete> ListaCadetes { get => listaCadetes; set => listaCadetes = value; }
    }
}
   