namespace EspacioPedidos
{
    public class Cadete
    {
        private int id;
        private string nombre;
        private string telefono;
        private string direccion;
        private List<Pedido> pedidosPendientes;
        private List<Pedido> pedidosEntregados;

        public int Id { get => id; set => id = value; }
        public string Nombre { get => nombre; set => nombre = value; }
        public string Telefono { get => telefono; set => telefono = value; }
        public string Direccion { get => direccion; set => direccion = value; }
        public List<Pedido> PedidosPendientes { get => pedidosPendientes; set => pedidosPendientes = value; }
        public List<Pedido> PedidosEntregados { get => pedidosEntregados; set => pedidosEntregados = value; }

        public float JornalAlCobrar() 
        { 
        }

        public Cadete(int id, string nombre, string telefono, string direccion)
        {
            this.id = id;
            this.nombre = nombre;
            this.telefono = telefono;
            this.direccion = direccion;
            pedidosPendientes = new List<Pedido>();
        }

        public void CargarPedido(Pedido pedido)
        {
            pedidosPendientes.Add(pedido);
        }
    }
}