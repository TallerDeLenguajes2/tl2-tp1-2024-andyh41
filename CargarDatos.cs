using System;
using System.IO;
using System.Text.Json;
using Microsoft.VisualBasic;
using EmpresaDeCadetes;

namespace CargaDeDatos
{
    public abstract class AccesoADatos
    {
        public abstract Cadeteria CargarCadeteria();
        public abstract List<Cadete> CargarCadetes();
    }
    public class AccesoCSV : AccesoADatos
    {
        private string cadeteriaFileName;
        private string cadetesFileName;

        public AccesoCSV(string cadeteriaFilePath, string cadetesFilePath)
        {
            this.cadeteriaFileName = cadeteriaFilePath;
            this.cadetesFileName = cadetesFilePath;
        }

        public override Cadeteria CargarCadeteria()
        {
            string content;
            using (var reader = new StreamReader(cadeteriaFileName))
            {
                content = reader.ReadToEnd();
            }

            string[] datos = content.Split(',');
            var sucursal = new Cadeteria(datos[0], datos[1]);
            return sucursal;
        }

        public override List<Cadete> CargarCadetes()
        {
            var listaCadetes = new List<Cadete>();

            using (var reader = new StreamReader(cadetesFileName))
            {
                string line;
                while ((line = reader.ReadLine()) != null)
                {
                    var values = line.Split(',');
                    var cadete = new Cadete(values[0], values[1], values[2]);
                    listaCadetes.Add(cadete);
                }
            }
            return listaCadetes;
        }
    }

    public class AccesoJSON : AccesoADatos
    {
        private string cadeteriaFileName;
        private string cadetesFileName;

        public AccesoJSON(string cadeteriaFilePath, string cadetesFilePath)
        {
            this.cadeteriaFileName = cadeteriaFilePath;
            this.cadetesFileName = cadetesFilePath;
        }

        public override Cadeteria CargarCadeteria()
        {
            string jsonString = File.ReadAllText(cadeteriaFileName);
            var sucursal = JsonSerializer.Deserialize<Cadeteria>(jsonString);
            return sucursal;
        }

        public override List<Cadete> CargarCadetes()
        {
            string jsonString = File.ReadAllText(cadetesFileName);
            List<Cadete> listaCadetes = JsonSerializer.Deserialize<List<Cadete>>(jsonString);
            return listaCadetes;
        }
    }

    public class MiMenu
    {
        public static void menu(){
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
