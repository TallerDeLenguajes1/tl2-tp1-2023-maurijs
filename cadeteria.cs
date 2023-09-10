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

      public void AsignarCadeteAPedido(int NumPedido, int  IDcadete)
        {
            var pedido = GetPedidoByID(NumPedido);
            var cadete = GetCadeteByID(IDcadete);
            pedido.Cadete = cadete;
            if (cadete == null)
            {
                Console.WriteLine("Error: el cadete no existe");
            }
            return;
        } 

        public void ReasignarPedido(int NumPedido, int IdNuevoCadete)
        {
            if (ContieneCadete(IdNuevoCadete))
            {
                if (ContienePedido(NumPedido))
                {
                    AsignarCadeteAPedido(NumPedido, IdNuevoCadete);
                    return;
                }
                Console.WriteLine("Error: Id del pedido invalido");
            }
            Console.WriteLine("Error: Id del cadete invalido");
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

        public bool ContienePedido(int NumPedido)
        {
            foreach (var pedido in listadoPedidos)
                {
                    if (pedido.Numero == NumPedido)
                    {
                        return true;
                    }
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

        public Informe GenerarInforme(Cadeteria cadeteria)
        {
            var informe = new Informe(cadeteria);
            return informe;
        }

        public float JornalACobrarCadete(int IdCadete)
        {
            float Ganancias = Calcular(IdCadete, 1);
            return Ganancias;
        }
        public float MontoTotalCadete(int IdCadete)
        {
            float Ganancias = Calcular(IdCadete, 2);
        
            return Ganancias;
        }
        public int EnviosRealizados(int IdCadete)
        {
            int contador = (int)Calcular(IdCadete, 3);
            return contador;
        }

        // Funcion que calcula: 1-ganancias individuales (jornalAcobrar), 2-Ganancias de todos los pedidos del cadete, 
        // 3- Cantidad de envios realizados
        private float Calcular(int IdCadete, int tipo)
        {
            float cantidad = 0;
            if (ContieneCadete(IdCadete))
            {
                foreach (var pedido in listadoPedidos)
                {
                    if (pedido.GetCadeteID() == IdCadete)
                    {
                        if (pedido.Estado == Estado.Aceptado)
                        {
                            switch (tipo)
                            {
                                case 1:
                                    cantidad += 500;
                                    break;
                                case 2:
                                    cantidad += pedido.Monto;
                                    break;
                                case 3:
                                    cantidad++;
                                    break;
                            }
                        }
                    }
                }
            } else {
                Console.WriteLine("Error: el id del cadete no existe");
            }
            return cantidad;
        }
    }
    
}
/*2) Refactorización del Sistema para una Cadeteria
El cliente presentó como nuevo requisito que los pedidos puedan no estar asignados a
algún cadete. Esto evidenció una falla en el diseño de clases del sistema, por lo que se decidió
realizar una refactorización del mismo.
Para poder cumplir con dicho requisito se propuso las siguientes modificaciones:
i) Implemente las modificaciones sugeridas más todas aquellas que crea necesarias
para cumplir con los requerimientos.
ii) Modifique la interfaz de usuario para cumplir con los nuevos requerimientos*/