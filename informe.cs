using System;
using System.Collections.Generic;
using System.IO;
using System.Text.Json;
namespace EspacioPedidos
{

    public class Informe {
        private List<Cadete> listadoCadetes;
        private float enviosPromedioPorCadete;
        private int cantTotalEnvios;
        private float montoTotalGanado;
        public List<Cadete> ListadoCadetes { get => listadoCadetes; set => listadoCadetes = value; }
        public float EnviosPromedioPorCadete { get => enviosPromedioPorCadete; set => enviosPromedioPorCadete = value; }
        public int CantTotalEnvios { get => cantTotalEnvios; set => cantTotalEnvios = value; }
        public float MontoTotalGanado { get => montoTotalGanado; set => montoTotalGanado = value; }

        public Informe(List<Cadete> listadoCadetes) {
            this.listadoCadetes = listadoCadetes;
        }
        public Informe() {
            listadoCadetes = new List<Cadete>();
            enviosPromedioPorCadete = 0;
            cantTotalEnvios = 0;
            montoTotalGanado = 0;
        }

        private void AddCadeteData(Cadete cadete)
        {
            cantTotalEnvios += cadete.CantEnviados();
            montoTotalGanado = +cadete.Ganancias();
        }
        private void AddListadoData()
        {
            foreach (var cadete in listadoCadetes)
            {
                AddCadeteData(cadete);
            }
        }

        private float CalcularPromedio()
        {
            float cantidadCadetes = listadoCadetes.Count();
            return cantTotalEnvios / cantidadCadetes;
        }
        public void InformeCadete(Cadete cadete)
        {
            Console.WriteLine("\n---------------------------------------------------\n");
            Console.WriteLine("Cadete:" + cadete.Nombre);
            Console.WriteLine("\nCantidad de envios:" + cadete.CantEnviados());
            Console.WriteLine("\nGanancias:" + cadete.Ganancias());
        }
        public void InformeListadoCadetes()
        {
            foreach (var cadete in listadoCadetes)
            {
                InformeCadete(cadete);
            }
        }
        public void InformeCadeteria()
        {
            Console.WriteLine("\n==============DATOS DE LA CADETERIA====================\n");
            Console.WriteLine("Cantidad Total de envios:" + cantTotalEnvios);
            Console.WriteLine("Monto total ganado:" + montoTotalGanado);
            Console.WriteLine("Envios promedio por cadete:" + CalcularPromedio());

        }

        public void InformeCompleto()
        {
            AddListadoData();
            CalcularPromedio();
            InformeCadeteria();
            InformeListadoCadetes();
        }
    }

}