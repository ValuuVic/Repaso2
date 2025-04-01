using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Repaso2
{
    public partial class FormVehiculo: Form
    {
        List<Vehiculo> vehiculos = new List<Vehiculo>();
        public FormVehiculo()
        {
            InitializeComponent();
        }
        private void mostrar()
        {
            VehiculoArchivo vehiculoArchivo = new VehiculoArchivo();
            vehiculos = vehiculoArchivo.Leer("../../Vehiculos.json");
            dataGridView1.DataSource = null;
            dataGridView1.DataSource = vehiculos;
            dataGridView1.Refresh();
        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void FormVehiculo_Load(object sender, EventArgs e)
        {
            mostrar();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Vehiculo vehiculo = new Vehiculo();
            vehiculo.placa = textBoxPlaca.Text;
            vehiculo.marca = textBoxMarca.Text;
            vehiculo.color = textBoxColor.Text;
            vehiculo.modelo = textBoxModelo.Text;
            vehiculo.PrecioKilometro = Convert.ToInt16(textBoxPrecioK.Text);
            vehiculos.Add(vehiculo);
            VehiculoArchivo archivo = new VehiculoArchivo();
            archivo.guardar("../../Vehiculos.json",vehiculos);
            mostrar();
            textBoxPlaca.Text = "";
            textBoxMarca.Text = "";
            textBoxColor.Text = "";
            textBoxModelo.Text = "";
            textBoxPrecioK.Text = "";
        }
    }
}
