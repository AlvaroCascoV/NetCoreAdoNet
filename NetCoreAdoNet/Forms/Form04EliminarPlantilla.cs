using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Microsoft.Data.SqlClient;

namespace NetCoreAdoNet.Forms
{
    public partial class Form04EliminarPlantilla : Form
    {
        //Necesito un formulario igual, pero en lugar de eliminar enfermo, eliminamos Plantilla por su ID. 

        //SOTA, CABALLO Y REY
        SqlConnection cn;
        SqlCommand com;
        SqlDataReader reader;
        public Form04EliminarPlantilla()
        {
            InitializeComponent();
            string connectionString = @"Data Source=LOCALHOST\DEVELOPER;Initial Catalog=HOSPITAL;Persist Security Info=True;User ID=SA;Encrypt=True;Trust Server Certificate=True";
            this.cn = new SqlConnection(connectionString);
            this.com = new SqlCommand();
            this.LoadEmpleados();
        }
        private void LoadEmpleados()
        {
            string sql = "select * from PLANTILLA";
            this.com.Connection = this.cn;
            this.com.CommandType = CommandType.Text;
            this.com.CommandText = sql;
            this.cn.Open();
            this.reader = this.com.ExecuteReader();
            this.lstPlantilla.Items.Clear();
            while(this.reader.Read())
            {
                string empleadoNo = this.reader["EMPLEADO_NO"].ToString();
                string apellido = this.reader["APELLIDO"].ToString();
                this.lstPlantilla.Items.Add(empleadoNo + " - " + apellido);
            }
            this.reader.Close();
            this.cn.Close();
        }

        private void btnEliminarEmpleado_Click(object sender, EventArgs e)
        {
            //NECESITAMOS EL DATO DE EMPLEADO_NO CONCATENADO
            string empleadoNo = this.txtId.Text;
            string sql = "delete from PLANTILLA where EMPLEADO_NO=" + empleadoNo;
            this.com.Connection = this.cn;
            this.com.CommandType = CommandType.Text;
            this.com.CommandText = sql;
            this.cn.Open();
            //LAS CONSULTAS DE ACCION DEVUELVEN UN int CON EL NUMERO DE REGISTROS AFECTADOS
            int registros = this.com.ExecuteNonQuery();
            this.cn.Close();
            this.LoadEmpleados();
            MessageBox.Show("Empleados eliminados: " + registros);
        }
    }
}
