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
    public partial class Reporte: Form
    {
        List<Cliente> clientes = new List<Cliente>();
        List<Vehiculo> vehiculos = new List<Vehiculo>();
        List<Alquiler> alquileres = new List<Alquiler>();    
        List<ReporteAlquiler> reportes = new List<ReporteAlquiler>();

        public Reporte()
        {
            InitializeComponent();
        }
        private void CargarClientes()
        {
            ClienteArchivo clienteArchivo = new ClienteArchivo();
            clientes = clienteArchivo.Leer("../../Clientes.json");
        }
        private void CargarVehiculos()
        {
            VehiculoArchivo vehiculoArchivo = new VehiculoArchivo();
            vehiculos = vehiculoArchivo.Leer("../../Vehiculos.json");
        }
        private void cargarAlquiler()
        {
            AlquilerArchivo alquilerArchivo = new AlquilerArchivo();
            alquileres = alquilerArchivo.Leer("../../Alquileres.json");
        }

        private void buttonRegresar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void Reporte_Load(object sender, EventArgs e)
        {
            CargarClientes();
            CargarVehiculos();
            cargarAlquiler();
            label2.Visible = false;
            label3.Visible = false;
        }

        private void buttonMostrar_Click(object sender, EventArgs e)
        {
            foreach (var cliente in clientes) {
                foreach (var vehiculo in vehiculos) { 
                    foreach(var alquiler in alquileres)
                    {
                        if((cliente.nit == alquiler.nit) && (vehiculo.placa == alquiler.placa))
                        {
                            ReporteAlquiler reporteAlquiler = new ReporteAlquiler();
                            reporteAlquiler.nombre = cliente.nombre;
                            reporteAlquiler.placa = vehiculo.placa;
                            reporteAlquiler.fechaDevolucion = alquiler.fechaDevolucion;
                            reporteAlquiler.total = vehiculo.PrecioKilometro*alquiler.kilometrosRecorridos;
                            reportes.Add(reporteAlquiler);
                        }
                    }
                }
            }
            int mayor = alquileres.Max(a => a.kilometrosRecorridos);
            dataGridView1.DataSource = null;
            dataGridView1.DataSource = reportes;
            dataGridView1.Refresh();
            label3.Visible = true;
            label3.Text = mayor.ToString()+" km/h";
            label2.Visible = true;
        }
    }
}
