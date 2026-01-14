using NetCoreAdoNet.Repositories;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace NetCoreAdoNet.Forms
{
    public partial class Form07DepartamentosEmpleadosPaco : Form
    {
        RepositoryDepartamentosEmpleadosPaco repo;
        public Form07DepartamentosEmpleadosPaco()
        {
            InitializeComponent();
            this.repo = new RepositoryDepartamentosEmpleadosPaco();
            this.LoadDepartamentosAsync();
        }

        private async void LoadDepartamentosAsync()
        {
            List<string> departamentos = await this.repo.GetNombresDepartamentosAsync();
            this.lstDepartamentos.Items.Clear();
            foreach (string nombre in departamentos)
            {
                this.lstDepartamentos.Items.Add(nombre);
            }
        }

        private async void lstDepartamentos_SelectedIndexChanged_1(object sender, EventArgs e)
        {

            string nombreDept = this.lstDepartamentos.SelectedItem.ToString();
            await this.LoadEmpleados(nombreDept);

        }

        private async Task LoadEmpleados(string nombreDepartamento)
        {
            if (this.lstDepartamentos.SelectedItem == null)
            {
                return;
            }
            this.label3.Text = "DEPT " + nombreDepartamento;
            List<string> empleados = await this.repo.GetApellidosEmpleadosAsync(nombreDepartamento);
            this.lstEmpleados.Items.Clear();
            foreach (string apellido in empleados)
            {
                this.lstEmpleados.Items.Add(apellido);
            }
        }

        private async void btnEliminar_Click_1(object sender, EventArgs e)
        {
            if (this.lstEmpleados.SelectedItem == null)
            {
                return;
            }
            string apeSeleccionado = this.lstEmpleados.SelectedItem.ToString();
            await this.repo.DeleteEmpleadoAsync(apeSeleccionado);
            string nombreDepartamento = this.lstDepartamentos.SelectedItem.ToString();
            await this.LoadEmpleados(nombreDepartamento);
            this.label4.Text = "EMPLEADO " + apeSeleccionado + " ELIMINADO";
        }
    }
}
