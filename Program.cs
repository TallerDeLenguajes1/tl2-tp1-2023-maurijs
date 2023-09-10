using EspacioPedidos;

public class Program
{
    public static void Main()
    {
        var random = new Random();
        string DataPath = "cadetes.csv";
        //Cargo los datos de los cadetes
        var Datos = new AccesoADatos(DataPath);
        //Instancio una clase Informe que mostrara los datos y estadisticas 
        var listadoCadetes = Datos.cargarCadetes();
        int IdCadete;
        string nombreCadeteria = "La Nona";
        string telefono = "3858402343";
        var cadeteria = new Cadeteria(nombreCadeteria, telefono, listadoCadetes);

        for (int i = 0; i < 6; i++)
        {
            cadeteria.CrearPedido(i, (float)random.Next(2000,10000),"observacion", "nombre","telefono", "direccion", "referencia direccion");
        }
        for (int i = 0; i < 6; i++)
        {
            IdCadete = random.Next(listadoCadetes.Count);
            cadeteria.AsignarCadeteAPedido(i, IdCadete);  
            Console.WriteLine("Pedido "+ i + " asignado a "+ cadeteria.GetCadeteByID(IdCadete).Nombre);
        }
        //Reasigno el pedido 3 al cadete 2
        cadeteria.ReasignarPedido(3,2);
        Console.WriteLine("Pedido "+ 3 + " reasignado a "+ cadeteria.GetCadeteByID(2).Nombre);
        cadeteria.PedidoEntregado(0);
        Console.WriteLine("Pedido 0 entregado");
        cadeteria.PedidoEntregado(1);
        Console.WriteLine("Pedido 1 entregado");
        cadeteria.PedidoEntregado(2);
        Console.WriteLine("Pedido 2 entregado");
        cadeteria.PedidoEntregado(3);
        Console.WriteLine("Pedido 3 entregado");
        cadeteria.PedidoEntregado(4);
        Console.WriteLine("Pedido 4 entregado");
        cadeteria.PedidoEntregado(5);
        Console.WriteLine("Pedido 5 entregado");
    

        var informe = new Informe(cadeteria);
        informe.MostrarInfCompleto();
    }
}