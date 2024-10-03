using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

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
        private Cadete cadete;

        public int Nro { get => nro; set => nro = value; }
        public string Obs { get => obs; set => obs = value; }
        public Estado EstadoPedido { get => estadoPedido; set => estadoPedido = value; }
        public Cadete CadeteAsignado { get => cadete; set => cadete = value; }

        private static int nextNumeroPedido = 1;

        public Pedidos(string nombre, string direccion, string telefono, string refDeDireccion, string obs, Cadete cadete){

            Nro = nextNumeroPedido++;
            Obs = obs;
            EstadoPedido = Estado.Aceptado;

            this.cliente = new Cliente(){
                Nombre = nombre,
                Direccion = direccion,
                Telefono = telefono,
                RefDeDireccion = refDeDireccion
            };
            
            this.cadete = cadete;
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

}        
