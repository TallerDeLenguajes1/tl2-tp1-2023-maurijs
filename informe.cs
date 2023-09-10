using System;
using System.Collections.Generic;
using System.IO;
using System.Text.Json;
namespace EspacioPedidos
{

    public class Informe {
        private Cadeteria cadeteria;
        private float enviosPromedioPorCadete;
        private int cantTotalEnvios;
        private float montoTotalGanado;
        public float EnviosPromedioPorCadete { get => enviosPromedioPorCadete; set => enviosPromedioPorCadete = value; }
        public int CantTotalEnvios { get => cantTotalEnvios; set => cantTotalEnvios = value; }
        public float MontoTotalGanado { get => montoTotalGanado; set => montoTotalGanado = value; }

        public Informe(Cadeteria cadeteria) {
            this.cadeteria = cadeteria;
        }

        private void AddCadeteData(int IdCadete)
        {
            cantTotalEnvios += cadete.CantEnviados();
            montoTotalGanado = cadeteria.;
        }
        private void AddListadoData()
        {
            foreach (var cadete in listadoCadetes)
            {
                AddCadeteData(cadete);
            }
        }

        private void CalcularPromedio()
        {
            float cantidadCadetes = listadoCadetes.Count;
            enviosPromedioPorCadete = cantTotalEnvios / cantidadCadetes;
            montoTotalGanado = 0;
            foreach (var cadete in listadoCadetes)
            {
                montoTotalGanado += cadete.Ganancias();
            }
        }
        public void MostrarInfCadete(Cadete cadete)
        {
            Console.WriteLine("\n---------------------------------------------------");
            Console.WriteLine("Cadete:" + cadete.Nombre);
            Console.WriteLine("Cantidad de envios completados:" + cadete.CantEnviados());
            Console.WriteLine("Ganancias:" + cadete.Ganancias());
        }
        public void MostrarInfListCadetes()
        {
            foreach (var cadete in listadoCadetes)
            {
                MostrarInfCadete(cadete);
            }
        }
        public void MostrarInfCadeteria()
        {
            Console.WriteLine("\n==============DATOS DE LA CADETERIA====================\n");
            Console.WriteLine("Cantidad de cadetes:" + listadoCadetes.Count);
            Console.WriteLine("Cantidad Total de envios:" + cantTotalEnvios);
            Console.WriteLine("Monto total ganado:" + montoTotalGanado);
            Console.WriteLine("Envios promedio por cadete:" + enviosPromedioPorCadete);

        }

        public void MostrarInfCompleto()
        {
            AddListadoData();
            CalcularPromedio();
            MostrarInfCadeteria();
            MostrarInfListCadetes();
        }
    }

}