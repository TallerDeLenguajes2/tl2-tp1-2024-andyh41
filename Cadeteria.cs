using System;
using System.Collections.Generic;
using System.IO;

namespace EmpresaDeCadetes
{

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