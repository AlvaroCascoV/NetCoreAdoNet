using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

#region PROCEDIMIENTOS ALMACENADOS
//create procedure SP_ALL_DEPARTAMENTOS
//as
//	select * from DEPT
//go

//create procedure SP_EMPLEADOS_DEPARTAMENTOS_OUT
//(@nombre NVARCHAR(50)
//, @suma int OUT, @media int OUT, @personas int OUT)
//as
//	declare @iddept int
//	select @iddept = DEPT_NO from DEPT
//		where DNOMBRE = @nombre
//	--LA CONSULTA DEL PROCEDIMIENTO
//	select * from EMP where DEPT_NO=@iddept
//	--RELLENAMOS LAS VARIABLES DE SALIDA
//	select @suma = SUM(SALARIO),
//    @media = AVG(SALARIO),
//    @personas = COUNT(EMP_NO) 
//	from EMP 
//		where DEPT_NO = @iddept
//go
#endregion

namespace NetCoreAdoNet.Forms
{
    public partial class Form13ParametrosSalida : Form
    {
        SqlConnection cn;
        SqlCommand com;
        SqlDataReader reader;
        public Form13ParametrosSalida()
        {
            InitializeComponent();
            string connectionString = @"Data Source=LOCALHOST\DEVELOPER;Initial Catalog=HOSPITAL;Persist Security Info=True;User ID=SA;Encrypt=True;Trust Server Certificate=True";
            this.cn = new SqlConnection(connectionString);
            this.com = new SqlCommand();
            this.com.Connection = this.cn;
            this.LoadDepartamentos();
        }

        private async Task LoadDepartamentos()
        {
            string sql = "SP_ALL_DEPARTAMENTOS";
            this.com.CommandType = CommandType.StoredProcedure;
            this.com.CommandText = sql;
            await this.cn.OpenAsync();
            this.reader = await this.com.ExecuteReaderAsync();
            this.cmbDepartamentos.Items.Clear();
            while (await this.reader.ReadAsync())
            {
                string nombre = this.reader["DNOMBRE"].ToString();
                this.cmbDepartamentos.Items.Add(nombre);
            }
            await this.reader.CloseAsync();
            await this.cn.CloseAsync();
        }

        private async void btnMostrarDatos_Click(object sender, EventArgs e)
        {
            string sql = "SP_EMPLEADOS_DEPARTAMENTOS_OUT";
            //TENEMOS UN PARAMETRO DE ENTRADA, POR DEFECTO, TODOS
            //SON DE ENTRADA. PODEMOS SEGUIR UTILIZANDO AddWithValue
            //CON DICHO PARAMETRO
            string nombre = this.cmbDepartamentos.SelectedItem.ToString();
            this.com.Parameters.AddWithValue("@nombre", nombre);
            //la forma explicita seria:
            //SqlParameter pamNombre = new SqlParameter();
            //pamNombre.ParameterName = "@nombre";
            //pamNombre.Value = nombre;
            //this.com.Parameters.Add(pamNombre);

            //LOS PARAMETROS DE SALIDA DEBEMOS CREARLOS DE FORMA EXPLICITA
            //EN ESTE EJEMPLO, NO HEMOS PUESTO VALORES POR DEFECTO A LOS PARAMETROS
            //DE SALIDA POR LO QUE SON OBLIGATORIOS
            SqlParameter pamSuma = new SqlParameter();
            pamSuma.ParameterName = "@suma";
            //HAY QUE PONER VALOR POR DEFECTO, SI NO, DA ERROR
            pamSuma.Value = 0;
            //INDICAMOS QUE ES DE SALIDA
            pamSuma.Direction = ParameterDirection.Output;
            this.com.Parameters.Add(pamSuma);
            SqlParameter pamMedia = new SqlParameter();
            pamMedia.ParameterName = "@media";
            pamMedia.Value = 0;
            pamMedia.Direction = ParameterDirection.Output;
            this.com.Parameters.Add(pamMedia);
            SqlParameter pamPersonas = new SqlParameter();
            pamPersonas.ParameterName = "@personas";
            pamPersonas.Value = 0;
            pamPersonas.Direction = ParameterDirection.Output;
            this.com.Parameters.Add(pamPersonas);

            this.com.CommandType = CommandType.StoredProcedure;
            this.com.CommandText = sql;
            await this.cn.OpenAsync();
            this.reader = await this.com.ExecuteReaderAsync();
            this.lstEmpleados.Items.Clear();
            while (await this.reader.ReadAsync())
            {
                string apellido = this.reader["APELLIDO"].ToString();
                this.lstEmpleados.Items.Add(apellido);
            }
            //se cierra el lector antes de leer los parametros de salida
            //porque los devuelve despues de cerrar el lector
            await this.reader.CloseAsync();
            //DIBUJAMOS LOS PARAMETROS DE SALIDA
            this.txtSumaSalarial.Text = pamSuma.Value.ToString();
            this.txtMediaSalarial.Text = pamMedia.Value.ToString();
            this.txtPersonas.Text = pamPersonas.Value.ToString();
            //LIBERAMOS LOS RECURSOS
            await this.cn.CloseAsync();
            this.com.Parameters.Clear(); 
        }
    }
}
