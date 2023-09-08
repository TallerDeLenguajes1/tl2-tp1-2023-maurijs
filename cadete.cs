namespace EspacioPedidos
{
    public class Cadete
    {
        private int id;
        private string nombre;
        private string telefono;
        private string direccion;
        private List<Pedido> pedidos;
        public int Id { get => id; set => id = value; }
        public string Nombre { get => nombre; set => nombre = value; }
        public string Telefono { get => telefono; set => telefono = value; }
        public string Direccion { get => direccion; set => direccion = value; }
        public List<Pedido> Pedidos { get => pedidos; set => pedidos = value; }

        //En caso de que ya exista una lista de pedidos
        public Cadete(int id, string nombre, string direccion, string telefono, List<Pedido> pedidos)
        {
            this.id = id;
            this.nombre = nombre;
            this.direccion = direccion;
            this.telefono = telefono;
            this.pedidos = pedidos;
        }
        //En caso de que no exista una lista de pedidos
        public Cadete(int id, string nombre, string telefono, string direccion)
        {
            this.id = id;
            this.nombre = nombre;
            this.telefono = telefono;
            this.direccion = direccion;
            pedidos = new List<Pedido>();
        }
        public float JornalAlCobrar() 
        { 
        }

        public void CargarPedido(Pedido pedido)
        {
            if (!ContienePedido(pedido))
            {
                pedidos.Add(pedido);
            }
            Console.WriteLine("\nError: el cadete ya tiene cargado ese pedido");
        }

        public void EliminarPedido(Pedido pedido)
        {
            pedidos.Remove(pedido);
        }
        
        public void EliminarPedido(int numeroPedido)
        {
            foreach (var pedido in pedidos)
            {
                if (pedido.Numero == numeroPedido)
                {
                    pedidos.Remove(pedido);
                    return;
                }
            }
            Console.WriteLine("\nError: El cadete no posee ese pedido");
        }
        
        public bool ContienePedido(Pedido pedido)
        {
            if (pedidos.Contains(pedido))
            {
                return true;
            }
            return false;
        }

        public Pedido GetPedidoByNumber(int numeroPedido)
        {
            foreach (var pedido in pedidos)
            {
                if (pedido.HasThisNumber(numeroPedido))
                {
                    return pedido;
                }
            }
            return null;
        }

        public int CantEnviados()
        {
            int total = 0;
            foreach (var pedido in pedidos)
            {
                if (pedido.Estado == Estado.Recibido)
                {
                    total++;
                }
            }
            return total;
        }

        public float Ganancias()
        {
            float Ganancias = 0;
            foreach (var pedido in pedidos)
            {
                if (pedido.Estado == Estado.Recibido)
                {
                    Ganancias =+ pedido.Monto;
                }
            }
            return Ganancias;
        }
    }
}