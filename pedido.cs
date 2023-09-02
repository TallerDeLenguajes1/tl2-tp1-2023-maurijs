namespace EspacioPedidos
{
    public enum Estado
    {
        Pendiente,
        Enviado,
        Recibido
    }
    public class Pedido
    {
        private int numero;
        private string observacion;
        private Estado estado;
        private Cliente cliente;

        public int Numero { get => numero; set => numero = value; }
        public string Observacion { get => observacion; set => observacion = value; }
        public Cliente Cliente { get => cliente; set => cliente = value; }
        internal Estado Estado { get => estado; set => estado = value; }
    
        private Pedido(int numero, string observacion, Estado estado, Cliente cliente)
        {
            this.numero = numero;
            this.observacion = observacion; 
            this.estado = estado;
            this.cliente = cliente;
        }
        public string VerDireccionCliente()
        {
            return cliente.Direccion + " - " + cliente.ReferenciaDireccion;
        }
        public string VerDatosCliente()
        {
            return cliente.Nombre + " - " + cliente.Telefono;
        }

        public Pedido CrearPedido(int numero, string observacion,string nombre, string telefono, string direccion, string referenciaDireccion)
        {
            cliente = new Cliente(nombre, telefono, direccion, referenciaDireccion);
            var pedido = new Pedido(numero, observacion, Estado.Pendiente, cliente);
            return pedido;
        }

    }
}