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

        //Constructores
        public Cadeteria(string nombre, string telefono)
        {
            this.nombre = nombre;
            this.telefono = telefono;
            listadoCadetes = new List<Cadete>();
        }
        public Cadeteria(string nombre, string telefono, List<Cadete> listado)
        {
            this.nombre = nombre;
            this.telefono = telefono;
            listadoCadetes = listado;
        }

        //Metodos
        public void CrearPedido(int numero, string observacion,string nombre, string telefono, string direccion, string referenciaDireccion)
        {
            var cliente = new Cliente(nombre, telefono, direccion, referenciaDireccion);
            var pedido = new Pedido(numero, observacion, Estado.Aceptado, cliente);
        }
        public void AsignarPedido(Pedido pedido, Cadete cadete)
        {
            if (pedido.Estado == Estado.Aceptado)
            {
                if (listadoCadetes.Contains(cadete))
                {
                    cadete.CargarPedido(pedido);
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
        public void ReasignarPedido(Pedido pedido, int IdNuevoCadete)
        {
            /*FirstOrDefault: Este método busca el primer elemento en la colección que cumple con una condición dada.*/
            var CadeteAnterior = listadoCadetes.FirstOrDefault(cadete => cadete.ContienePedido(pedido), null);
            //Encuentro el nuevo cadete
            if (ContieneCadete(IdNuevoCadete))
            {
                var NuevoCadete = GetCadeteByID(IdNuevoCadete);
                if (!NuevoCadete.ContienePedido(pedido))
                {
                    NuevoCadete.CargarPedido(pedido);
                    CadeteAnterior.EliminarPedido(pedido);
                }     
                Console.WriteLine("Error: El cadete ya posee ese pedido");
            }
            Console.WriteLine("Error: Id ingresado invalido");
            return;
        }

        public void DarAltaPedidos(Pedido pedido) 
        {
            pedido.Estado = Estado.Aceptado;
        }

        public bool ContieneCadete(Cadete cadete)
        {
            if (listadoCadetes.Contains(cadete))
            {
                return true;
            }
            return false;
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

        public void GenerarInformes()
        {

        }
    }
    
}

/*cadeteria  --- Metodo CrearPedido --- recibe los datos del pedido mas los datos del cadete y el cliente(lo obtiene de CargarPedido del cliente)
Cadeteria  --- Metodo ReasignarPedido ---
Cadeteria  --- Metodo EliminarPedido ---
Cadeteria  --- Metodo GenerarInformes ---
Cadeteria  --- Metodo CambiarEstadoDelPedido ---*/