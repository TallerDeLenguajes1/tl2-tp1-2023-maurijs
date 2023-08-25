namespace EspacioPedidos
{
    public class Cadete
    {
        string id;
        string nombre;
        string telefono;
        string direccion;
        List<Pedido> pedidos;

        public string Id { get => id; set => id = value; }
        public string Nombre { get => nombre; set => nombre = value; }
        public string Telefono { get => telefono; set => telefono = value; }
        public string Direccion { get => direccion; set => direccion = value; }
        public List<Pedido> Pedidos { get => pedidos; set => pedidos = value; }

        public float JornalAlCobrar() 
        { 
        }
    }
}