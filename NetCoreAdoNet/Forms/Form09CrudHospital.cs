using NetCoreAdoNet.Models;
using NetCoreAdoNet.Repositories;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace NetCoreAdoNet.Forms
{
    public partial class Form09CrudHospital : Form
    {
        RepositoryHospitales repo;
        public Form09CrudHospital()
        {
            InitializeComponent();
            this.repo = new RepositoryHospitales();
            this.LoadHospitales();
        }
        public async Task LoadHospitales()
        {
            List<Hospital> hospitales = await this.repo.GetHospitalesAsync();
            this.lstHospitales.Items.Clear();
            foreach (Hospital hosp in hospitales)
            {
                this.lstHospitales.Items.Add(hosp.HOSPITAL_COD + " - "
                    + hosp.NOMBRE + " - "
                    + hosp.DIRECCION + " - "
                    + hosp.TELEFONO + " - "
                    + hosp.NUM_CAMA);
            }
        }

        private async void btnInsertar_Click(object sender, EventArgs e)
        {
            int cod = int.Parse(this.txtHospitalCod.Text);
            string nombre = this.txtNombre.Text;
            string direccion = this.txtDireccion.Text;
            string telefono = this.txtTelefono.Text;
            int camas = int.Parse(this.txtCamas.Text);
            await this.repo.CreateHospitalAsync(cod, nombre, direccion, telefono, camas);
            await this.LoadHospitales();
        }

        private async void btnModificar_Click(object sender, EventArgs e)
        {
            int cod = int.Parse(this.txtHospitalCod.Text);
            string nombre = this.txtNombre.Text;
            string direccion = this.txtDireccion.Text;
            string telefono = this.txtTelefono.Text;
            int camas = int.Parse(this.txtCamas.Text);
            await this.repo.UpdateHospitalAsync(cod, nombre, direccion, telefono, camas);
            await this.LoadHospitales();
        }

        private async void btnEliminar_Click(object sender, EventArgs e)
        {
            int cod = int.Parse(this.txtHospitalCod.Text);
            await this.repo.DeleteHospitalAsync(cod);
            await this.LoadHospitales();
        }
    }
}
