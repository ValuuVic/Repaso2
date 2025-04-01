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
    public partial class FormClientes: Form
    {
        List<Cliente> clientes = new List<Cliente>();
        public FormClientes()
        {
            InitializeComponent();
        }
        private void mostrar()
        {
            ClienteArchivo clienteArchivo = new ClienteArchivo();
            clientes = clienteArchivo.Leer("../../Clientes.json");
            dataGridView1.DataSource = null;
            dataGridView1.DataSource = clientes;
            dataGridView1.Refresh();
        }
        private void buttonGuardar_Click(object sender, EventArgs e)
        {
            Cliente cliente = new Cliente();
            cliente.nombre = textBoxNombre.Text;
            cliente.nit = textBoxNit.Text;
            cliente.direccion = textBoxDireccion.Text;
            clientes.Add(cliente);
            ClienteArchivo clienteArchivo = new ClienteArchivo();
            clienteArchivo.guardar("../../Clientes.json",clientes);
            mostrar();
            textBoxNombre.Text = "";
            textBoxNit.Text = "";
            textBoxDireccion.Text = "";
        }

        private void FormClientes_Load(object sender, EventArgs e)
        {
            mostrar();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            FormVehiculo formVehiculo = new FormVehiculo();
            formVehiculo.Show();
        }

        private void buttonSalir_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void buttonAlquiler_Click(object sender, EventArgs e)
        {
            FormAlquiler formAlquiler = new FormAlquiler();
            formAlquiler.Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Reporte reporte = new Reporte();
            reporte.Show();
        }
    }
}
