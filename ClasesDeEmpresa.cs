

namespace EmpresaDeCadetes
{

    enum Estado
    {
        Aceptado,
        EnCurso,
        Finalizado
    }
    public class Pedidos {
        
        private int nro;

        private string obs;

        private Cliente cliente;

        public int Nro { get => nro; set => nro = value; }
        public string Obs { get => obs; set => obs = value; }
        internal Cliente Cliente { get => cliente; set => cliente = value; }

        enum Estado;

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
        private List<Pedidos> listaPedidos;

        public int Id { get => id; set => id = value; }
        public string Nombre { get => nombre; set => nombre = value; }
        public string Direccion { get => direccion; set => direccion = value; }
        public string Telefono { get => telefono; set => telefono = value; }
        internal List<Pedidos> ListaPedidos { get => listaPedidos; set => listaPedidos = value; }
    }

    public class Cadeteria {
        private string nombre;
        private string telefono;
        private List<Cadete> listaCadetes;

        public string Nombre { get => nombre; set => nombre = value; }
        public string Telefono { get => telefono; set => telefono = value; }
        internal List<Cadete> ListaCadetes { get => listaCadetes; set => listaCadetes = value; }
    }
}
   