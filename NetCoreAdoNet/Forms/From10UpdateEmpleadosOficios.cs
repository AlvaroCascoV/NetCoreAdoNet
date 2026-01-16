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
    public partial class From10UpdateEmpleadosOficios : Form
    {
        RepositoryUpdateEmpelados repo;
        public From10UpdateEmpleadosOficios()
        {
            InitializeComponent();
            this.repo = new RepositoryUpdateEmpelados();
            this.LoadOficios();
        }

        public async void LoadOficios()
        {
            this.lstOficios.Items.Clear();
            List<string> oficios = await this.repo.GetOficiosAsync();
            foreach (string oficio in oficios)
            {
                this.lstOficios.Items.Add(oficio);
            }
        }

        public async Task LoadDatosSalario()
        {
            string oficio = this.lstOficios.SelectedItem.ToString();
            List<int> datosSalario = await this.repo.GetDatosSalarioAsync(oficio);
            this.lblSumaSalarial.Text = datosSalario[0].ToString();
            this.lblMediaSalarial.Text = datosSalario[1].ToString();
            this.lblMaximoSalario.Text = datosSalario[2].ToString();
        }

        private async void lstOficios_SelectedIndexChanged(object sender, EventArgs e)
        {
            int index = this.lstOficios.SelectedIndex;
            if (index != -1)
            {
                string oficio = this.lstOficios.SelectedItem.ToString();
                List<string> apellidos = await this.repo.GetEmpleadosByOficioAsync(oficio);
                this.lstEmpleados.Items.Clear();
                foreach (string ape in apellidos)
                {
                    this.lstEmpleados.Items.Add(ape);
                }
                await this.LoadDatosSalario();
            }
        }

        private async void btnIncremento_Click(object sender, EventArgs e)
        {
            int incremento = int.Parse(this.txtIncremento.Text);
            string oficio = this.lstOficios.SelectedItem.ToString();
            int registros = await this.repo.UpdateSalarioEmpleadosAsync(oficio, incremento);
            MessageBox.Show("Registros afectados: " + registros + "; Incremento: " + incremento);
        }

    }
}
