namespace EspacioPedidos
{
    public class AccesoADatos{
        private List<Cadete> listaCadetes;
        private string dataPath;
        public List<Cadete> ListaCadetes { get => listaCadetes; set => listaCadetes = value; }
        public string DataPath { get => dataPath; set => dataPath = value; }

        public AccesoADatos(string DirArchivo)
        {
            dataPath = DirArchivo;
        }
        public  void cargarCadetes(){
            List<Cadete> cadetes = new List<Cadete>();
            var cadetesCargados = File.ReadAllLines(dataPath + ".csv")
            .Skip(1).                           //Saltea el encabezado
            Select(line => line.Split(',')).
            Select(parts => new Cadete(int.Parse(parts[0]), parts[1], parts[2], parts[3]));
            cadetes.AddRange(cadetesCargados);
            ListaCadetes = cadetes;
            Console.WriteLine("Cadetes cargados correctamente");
            
        }
        public Informe GenerarInforme()
        {
            cargarCadetes();   
            Informe informe = new Informe(listaCadetes);
            return informe;
        }
    }   
}