using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace Repaso2
{
    class AlquilerArchivo
    {
        public void guardar(String archivo, List<Alquiler> alquileres)
        {
            string json = JsonConvert.SerializeObject(alquileres);
            System.IO.File.WriteAllText(archivo, json);
        }
        public List<Alquiler> Leer(string archivo)
        {
            List<Alquiler> lista = new List<Alquiler>();
            StreamReader jsonStream = File.OpenText(archivo);
            string json = jsonStream.ReadToEnd();
            jsonStream.Close();
            lista = JsonConvert.DeserializeObject<List<Alquiler>>(json);
            return lista;
        }
    }
}
