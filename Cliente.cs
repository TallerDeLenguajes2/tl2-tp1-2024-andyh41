using System;
using System.Collections.Generic;
using System.IO;

namespace EmpresaDeCadetes
{

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
}