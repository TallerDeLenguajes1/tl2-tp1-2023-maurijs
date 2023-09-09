namespace EspacioPedidos
{
    public class AccesoADatos{
        private string dataPath;
        public string DataPath { get => dataPath; set => dataPath = value; }
        public AccesoADatos(string DirArchivo)
        {
           DataPath = DirArchivo;    
        }

        public  List<Cadete> cargarCadetes(){
            List<Cadete> cadetes = new List<Cadete>();
            var cadetesCargados = File.ReadAllLines(DataPath)
            .Skip(1).                           //Saltea el encabezado
            Select(line => line.Split(',')).
            Select(parts => new Cadete(int.Parse(parts[0]), parts[1], parts[2], parts[3]));
            cadetes.AddRange(cadetesCargados);
            Console.WriteLine("Cadetes cargados correctamente");
            return cadetes;
        }
    }   
}