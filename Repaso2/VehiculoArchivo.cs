using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace Repaso2
{
    class VehiculoArchivo
    {
        public void guardar(String archivo, List<Vehiculo> vehiculos)
        {
            string json = JsonConvert.SerializeObject(vehiculos);
            System.IO.File.WriteAllText(archivo, json);
        }
        public List<Vehiculo> Leer(string archivo)
        {
            List<Vehiculo> lista = new List<Vehiculo>();
            StreamReader jsonStream = File.OpenText(archivo);
            string json = jsonStream.ReadToEnd();
            jsonStream.Close();
            lista = JsonConvert.DeserializeObject<List<Vehiculo>>(json);
            return lista;
        }
    }
}
