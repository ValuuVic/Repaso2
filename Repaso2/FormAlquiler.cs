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
    public partial class FormAlquiler: Form
    {
        List<Alquiler> alquileres = new List<Alquiler>();
        public FormAlquiler()
        {
            InitializeComponent();
        }
        private void mostrar()
        {
            AlquilerArchivo alquilerArchivo = new AlquilerArchivo();
            alquileres = alquilerArchivo.Leer("../../Alquileres.json");
            dataGridView1.DataSource = null;
            dataGridView1.DataSource = alquileres;
            dataGridView1.Refresh();
        }

        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void FormAlquiler_Load(object sender, EventArgs e)
        {
            mostrar();
            List<Cliente> clientes= new List<Cliente>();
            ClienteArchivo clienteArchivo = new ClienteArchivo();
            clientes = clienteArchivo.Leer("../../Clientes.json");
            comboBox1.DisplayMember = "nombre";
            comboBox1.ValueMember = "nit";
            comboBox1.DataSource = clientes;
            //mostrar en el combo box los vehiculos
            List<Vehiculo> vehiculos = new List<Vehiculo>();
            VehiculoArchivo vehiculoArchivo = new VehiculoArchivo();
            vehiculos = vehiculoArchivo.Leer("../../Vehiculos.json");
            comboBox2.DisplayMember = "placa";
            comboBox2.ValueMember = "placa";
            comboBox2.DataSource = vehiculos;
        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void buttonGuardar_Click(object sender, EventArgs e)
        {
            Alquiler alquiler = new Alquiler();
            alquiler.nit = comboBox1.SelectedValue.ToString();
            alquiler.placa = comboBox2.SelectedValue.ToString();
            alquiler.fechaAlquiler = dateTimePicker1.Value;
            alquiler.fechaDevolucion = dateTimePicker2.Value;
            alquiler.kilometrosRecorridos = Convert.ToInt16(textBoxKilo.Text);
            alquileres.Add(alquiler);
            AlquilerArchivo alquilerArchivo = new AlquilerArchivo();
            alquilerArchivo.guardar("../../Alquileres.json",alquileres);
            mostrar();
            comboBox1.SelectedItem = null;
            comboBox2.SelectedItem = null;
            textBoxKilo.Text = "";

        }
    }
}
