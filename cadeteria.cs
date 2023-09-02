namespace EspacioPedidos
{
    public class Cadeteria
    {
        private string nombre;
        private string telefono;
        private List<Cadete> listadoCadetes;

        public string Nombre { get => nombre; set => nombre = value; }
        public string Telefono { get => telefono; set => telefono = value; }
        public List<Cadete> ListadoCadetes { get => listadoCadetes; set => listadoCadetes = value; }

        public Cadeteria(string nombre, string telefono)
        {
            this.nombre = nombre;
            this.telefono = telefono;
            listadoCadetes = new List<Cadete>();
        }
        public void AsignarPedidoACadete(Pedido pedido, Cadete cadete)
        {
            if (pedido.Estado == Estado.Pendiente)
            {
                if (listadoCadetes.Contains(cadete))
                {
                    cadete.CargarPedido(pedido);
                }
            }
            Console.WriteLine("No se pudo asignar el pedido");
            return;
        }

        public void DarAltaPedidos(Pedido pedido) 
        {
            pedido.Estado = Estado.Recibido;
            foreach (var cadete in ListadoCadetes)
            {
                if (cadete.PedidosPendientes.Contains(pedido))
                {
                    cadete.PedidosEntregados.Add(pedido);
                    cadete.PedidosPendientes.Remove(pedido);
                }
            }
        }

        
    }
    
}

/*cadeteria  --- Metodo CrearPedido --- recibe los datos del pedido mas los datos del cadete y el cliente(lo obtiene de CargarPedido del cliente)
Cadeteria  --- Metodo ReasignarPedido ---
Cadeteria  --- Metodo EliminarPedido ---
Cadeteria  --- Metodo GenerarInformes ---
Cadeteria  --- Metodo CambiarEstadoDelPedido ---*/