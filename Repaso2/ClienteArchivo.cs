using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace Repaso2
{
    class ClienteArchivo
    {
        public void guardar(String archivo, List<Cliente> clientes)
        {
            string json = JsonConvert.SerializeObject(clientes);
            System.IO.File.WriteAllText(archivo, json);
        }
        public List<Cliente> Leer(string archivo)
        {
            List<Cliente> lista = new List<Cliente>();
            StreamReader jsonStream = File.OpenText(archivo);
            string json = jsonStream.ReadToEnd();
            jsonStream.Close();
            lista = JsonConvert.DeserializeObject<List<Cliente>>(json);
            return lista;
        }
    }
}
