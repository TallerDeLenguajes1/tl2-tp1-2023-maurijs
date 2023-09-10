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

        string nombreCadeteria = "La Nona";
        string telefono = "3858402343";
        var cadeteria = new Cadeteria(nombreCadeteria, telefono, listadoCadetes);

        for (int i = 0; i < 6; i++)
        {
            cadeteria.CrearPedido(i, (float)random.Next(2000,10000),"observacion", "nombre","telefono", "direccion", "referencia direccion");
        }
        for (int i = 0; i < 6; i++)
        {
            cadeteria.AsignarCadeteAPedido(i, random.Next(listadoCadetes.Count));  
        }
        //Reasigno el pedido 3 al cadete 2
        cadeteria.ReasignarPedido(3,2);
        cadeteria.PedidoEntregado(0);
        cadeteria.PedidoEntregado(1);
        cadeteria.PedidoEntregado(2);
        cadeteria.PedidoEntregado(3);
        cadeteria.PedidoEntregado(4);
        cadeteria.PedidoEntregado(5);
    

        var informe = cadeteria.GenerarInforme(listadoCadetes);
        informe.MostrarInfCompleto();
    }
}