namespace EspacioPedidos
{
    public class Cliente
    {
        string nombre;
        string telefono;
        string direccion;
        string referenciaDireccion;
        public string Nombre { get => nombre; set => nombre = value; }
        public string Telefono { get => telefono; set => telefono = value; }
        public string Direccion { get => direccion; set => direccion = value; }
        public string ReferenciaDireccion { get => referenciaDireccion; set => referenciaDireccion = value; }
    }
    
}