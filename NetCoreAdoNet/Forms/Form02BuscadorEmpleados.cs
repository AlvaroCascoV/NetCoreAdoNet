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
    public partial class Form02BuscadorEmpleados : Form
    {
        //SOTA, CABALLO Y REY
        SqlConnection cn;
        SqlCommand com;
        SqlDataReader reader;
        public Form02BuscadorEmpleados()
        {
            InitializeComponent();
            string connectionString = @"Data Source=LOCALHOST\DEVELOPER;Initial Catalog=HOSPITAL;Persist Security Info=True;User ID=SA;Trust Server Certificate=True";
            this.cn = new SqlConnection(connectionString);
            this.com = new SqlCommand();
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            //VAMOS A CONCATENAR, POR LO QUE NUESTRO SALARIO SERA UN STRING
            string salario = this.txtSalario.Text;
            //CONSULTA SQL
            string sql = "select * from EMP where SALARIO >= " + salario;
            //CONFIGURAMOS EL COMANDO
            this.com.Connection = this.cn;
            //TIPO DE CONSULTA
            this.com.CommandType = CommandType.Text;
            //LA CONSULTA
            this.com.CommandText = sql;
            //ENTRAR Y SALIR 
            //ABRIMOS CONEXION
            this.cn.Open();
            //EJECUTAMOS LA CONSULTA
            this.reader = this.com.ExecuteReader();
            //DIBUJAMOS LOS DATOS
            this.lstEmpleados.Items.Clear();
            while (this.reader.Read())
            {
                string apellido = this.reader["APELLIDO"].ToString();
                string sal = this.reader["SALARIO"].ToString();
                this.lstEmpleados.Items.Add(apellido + " - " + sal);
            }
            //SALIMOS, LIBERAMOS RECURSOS
            this.reader.Close();
            this.cn.Close();
        }
    }
}
