namespace EspacioPedidos
{
    enum estado
    {
        pendiente,
        enviado,
        recibido
    }
    public class Pedido
    {
        int numero;
        string observacion;
        estado estado;
        Cliente cliente;

        public int Numero { get => numero; set => numero = value; }
        public string Observacion { get => observacion; set => observacion = value; }
        public Cliente Cliente { get => cliente; set => cliente = value; }
        internal estado Estado { get => estado; set => estado = value; }
    }
    
}