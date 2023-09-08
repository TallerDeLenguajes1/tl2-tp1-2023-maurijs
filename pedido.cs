namespace EspacioPedidos
{
    public enum Estado
    {
        Aceptado,
        Cancelado,
        Recibido
    }
    public class Pedido
    {
        private int numero;
        private string observacion;
        private Estado estado;
        private Cliente cliente;
        private float monto;

        public int Numero { get => numero; set => numero = value; }
        public string Observacion { get => observacion; set => observacion = value; }
        public Cliente Cliente { get => cliente; set => cliente = value; }
        internal Estado Estado { get => estado; set => estado = value; }
        public float Monto { get => monto; set => monto = value; }

        public Pedido(int numero, string observacion, Estado estado, Cliente cliente)
        {
            this.numero = numero;
            this.observacion = observacion; 
            this.estado = estado;
            this.cliente = cliente;
        }

        public bool HasThisNumber(int numeroPedido)
        {   
            if (numero == numeroPedido){ return true; };
            return false;

        }
        public string VerDireccionCliente()
        {
            return cliente.Direccion + " - " + cliente.ReferenciaDireccion;
        }
        public string VerDatosCliente()
        {
            return cliente.Nombre + " - " + cliente.Telefono;
        }

        

    }
}