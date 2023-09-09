namespace EspacioPedidos
{
    public class Cadeteria
    {
        private string nombre;
        private string telefono;
        private List<Cadete> listadoCadetes;
        private List<Pedido> listadoPedidos;

        public string Nombre { get => nombre; set => nombre = value; }
        public string Telefono { get => telefono; set => telefono = value; }
        public List<Cadete> ListadoCadetes { get => listadoCadetes; set => listadoCadetes = value; }
        public List<Pedido> ListadoPedidos { get => listadoPedidos; set => listadoPedidos = value; }

        //Constructores
        public Cadeteria(string nombre, string telefono)
        {
            this.nombre = nombre;
            this.telefono = telefono;
            listadoCadetes = new List<Cadete>();
            listadoPedidos = new List<Pedido>();
        }
        public Cadeteria(string nombre, string telefono, List<Cadete> listado)
        {
            this.nombre = nombre;
            this.telefono = telefono;
            listadoCadetes = listado;
            listadoPedidos = new List<Pedido>();
        }

        //Metodos
        public void CrearPedido(int numero, float monto, string observacion,string nombre, string telefono, string direccion, string referenciaDireccion)
        {
            var cliente = new Cliente(nombre, telefono, direccion, referenciaDireccion);
            var pedido = new Pedido(numero, monto, observacion, Estado.Aceptado, cliente);
            listadoPedidos.Add(pedido);
        }

      public void AsignarPedido(int NumPedido, int  IDcadete)
        {
            foreach (var cadete in listadoCadetes)
            {
                var cad = listadoCadetes[IDcadete];
                if (cadete.Id == IDcadete)
                {
                    cadete.CargarPedido(GetPedidoByID(NumPedido));
                    Console.WriteLine("Pedido " + NumPedido + " asignado a " + cadete.Nombre );
                    return;
                }
            }
            Console.WriteLine("Error: No se pudo asignar el pedido");
            return;
        } 

        public void ReasignarPedido(Pedido pedido, Cadete NuevoCadete)
        {
            /*FirstOrDefault: Este método busca el primer elemento en la colección que cumple con una condición dada.*/
            var CadeteAnterior = this.ListadoCadetes.FirstOrDefault(cadete => cadete.ContienePedido(pedido), null);
            if (!NuevoCadete.ContienePedido(pedido))
            {
                NuevoCadete.CargarPedido(pedido);
                CadeteAnterior.EliminarPedido(pedido);
            }
        }
        public void ReasignarPedido(int NumPedido, int IdNuevoCadete)
        {
            /*FirstOrDefault: Este método busca el primer elemento en la colección que cumple con una condición dada.*/
            var pedido = GetPedidoByID(NumPedido);
            var CadeteAnterior = listadoCadetes.FirstOrDefault(cadete => cadete.ContienePedido(pedido), null);
            
            //Encuentro el nuevo cadete
            if (ContieneCadete(IdNuevoCadete))
            {
                var NuevoCadete = GetCadeteByID(IdNuevoCadete);
                if (!NuevoCadete.ContienePedido(pedido))
                {
                    NuevoCadete.CargarPedido(pedido);
                    CadeteAnterior.EliminarPedido(pedido);
                    Console.WriteLine("Pedido " + NumPedido + " reasignado a " + NuevoCadete.Nombre );
                    return;
                }  else  {
                    Console.WriteLine("Error: El cadete ya posee ese pedido");
                }
            }
            Console.WriteLine("Error: Id ingresado invalido");
            return;
        }

        public void DarAltaPedido(int NumPedido) 
        {
            var pedido = GetPedidoByID(NumPedido);
            pedido.Estado = Estado.Aceptado;
        }
        public void CancelarPedido(int NumPedido) 
        {
            var pedido = GetPedidoByID(NumPedido);
            pedido.Estado = Estado.Cancelado;
        }
        public void PedidoEntregado(int NumPedido) 
        {
            var pedido = GetPedidoByID(NumPedido);
            pedido.Estado = Estado.Recibido;
        }

        public bool ContieneCadete(int id)
        {
            foreach (var cadete in listadoCadetes)
            {
                if (cadete.Id == id)
                {
                    return true;
                }
            }
            return false;
        }

        public Cadete GetCadeteByID(int id)
        {
            foreach (var cadete in listadoCadetes)
            {
                if (cadete.Id == id)
                {
                    return cadete;
                }
            }
            return null;
        }
        public Pedido GetPedidoByID(int id)
        {
            foreach (var pedido in listadoPedidos)
            {
                if (pedido.Numero == id)
                {
                    return pedido;
                }
            }
            return null;
        }

        public Informe GenerarInforme(List<Cadete> ListadoCadetes)
        {
            var informe = new Informe(ListadoCadetes);
            return informe;
        }
    }
    
}

/*cadeteria  --- Metodo CrearPedido --- recibe los datos del pedido mas los datos del cadete y el cliente(lo obtiene de CargarPedido del cliente)
Cadeteria  --- Metodo ReasignarPedido ---
Cadeteria  --- Metodo EliminarPedido ---
Cadeteria  --- Metodo GenerarInformes ---
Cadeteria  --- Metodo CambiarEstadoDelPedido ---*/