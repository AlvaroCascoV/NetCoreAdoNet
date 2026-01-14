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
    public partial class Form07DepartamentosEmpleados : Form
    {
        RepositoryDepartamentosEmpleados repo;
        public Form07DepartamentosEmpleados()
        {
            InitializeComponent();
            this.repo = new RepositoryDepartamentosEmpleados();
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

        private async void lstDepartamentos_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (this.lstDepartamentos.SelectedItem == null)
            {
                return;
            }
            this.label3.Text = "DEPT " + this.lstDepartamentos.SelectedItem.ToString();
            List<string> empleados = await this.repo.GetApellidosEmpleadosAsync(this.lstDepartamentos.SelectedItem.ToString());
            this.lstEmpleados.Items.Clear();
            foreach (string apellido in empleados)
            {
                this.lstEmpleados.Items.Add(apellido);
            }
        }

        private async void btnEliminar_Click(object sender, EventArgs e)
        {
            if (this.lstEmpleados.SelectedItem == null)
            {
                return;
            }
            string apeSeleccionado = this.lstEmpleados.SelectedItem.ToString();
            await this.repo.DeleteEmpleadoAsync(apeSeleccionado);
            this.label4.Text = "EMPLEADO " + apeSeleccionado + " ELIMINADO";
            this.lstEmpleados.Items.Remove(apeSeleccionado);
        }
    }
}
