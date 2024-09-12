using System;
using System.IO;
using EmpresaDeCadetes;

namespace CargaDeDatos
{
    public class CargarDatos
    {
        public static Cadeteria ArchivoCVScadeteria()
        {
            string filePath = "Cadeteria.csv"; // Ruta al archivo CSV

            string content; // Declarar 'content'

            // Leer el contenido del archivo
            using (var reader = new StreamReader(filePath))
            {
                content = reader.ReadToEnd(); // Leer todo el contenido del archivo
            }

            string[] datos = content.Split(','); 
            var sucur = new Cadeteria(datos[0], datos[1]);

            return sucur;
        }

        public static void ArchivoCVScadete(Cadeteria sucursal)
        {
            string filePath = "Cadete.csv"; // Ruta al archivo CSV

            using (var reader = new StreamReader(filePath))
            {
                string line;
                
                // Leer el archivo línea por línea
                while ((line = reader.ReadLine()) != null)
                {
                    // Dividir la línea en valores usando la coma como delimitador
                    var values = line.Split(',');
                    // Crea un cadete por linea y le asigna los datos tomados del archivo CSV
                    var cadetes = new Cadete(values[0], values[1], values[2]);
                    // Agrega el cadete creado a la lista de cadetes de la cadeteria
                    sucursal.AgregarCadete(cadetes);
                }        
            }
        }

        public static void Menu(){
            Console.WriteLine("=======================================");
            Console.WriteLine("                 MENU");
            Console.WriteLine("=======================================");
            Console.WriteLine(" 1. Ingresar un pedido ");
            Console.WriteLine(" 2. Asignar pedido a cadete ");
            Console.WriteLine(" 3. Cambiar pedido de estado ");
            Console.WriteLine(" 4. Reasignar el pedido a otro cadete ");
            Console.WriteLine(" 0. Salir del menu ");
            Console.WriteLine("=======================================");
            Console.WriteLine(" ");
        }


    }

}
