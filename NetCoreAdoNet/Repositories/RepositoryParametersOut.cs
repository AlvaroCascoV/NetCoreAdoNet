using Microsoft.Data.SqlClient;
using NetCoreAdoNet.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Text;

#region PROCEDIMIENTOS ALMACENADOS
//tienen que ir donde esté la logica de datos

/*
create procedure SP_ALL_DEPARTAMENTOS
as
	select * from DEPT
go

create procedure SP_EMPLEADOS_DEPARTAMENTOS_OUT
(@nombre NVARCHAR(50)
, @suma int OUT, @media int OUT, @personas int OUT)
as
	declare @iddept int
	select @iddept = DEPT_NO from DEPT
		where DNOMBRE = @nombre
	--LA CONSULTA DEL PROCEDIMIENTO
	select * from EMP where DEPT_NO=@iddept
	--RELLENAMOS LAS VARIABLES DE SALIDA
	select @suma = SUM(SALARIO),
    @media = AVG(SALARIO),
    @personas = COUNT(EMP_NO) 
	from EMP 
		where DEPT_NO = @iddept
go
*/
#endregion

namespace NetCoreAdoNet.Repositories
{
    public class RepositoryParametersOut
    {
        private SqlConnection cn;
        private SqlCommand com;
        private SqlDataReader reader;

        public RepositoryParametersOut()
        {
            string connectionString = @"Data Source=LOCALHOST\DEVELOPER;Initial Catalog=HOSPITAL;Persist Security Info=True;User ID=SA;Encrypt=True;Trust Server Certificate=True";
            this.cn = new SqlConnection(connectionString);
            this.com = new SqlCommand();
            this.com.Connection = this.cn;
        }

        public async Task<List<string>> GetDepartamentosAsync()
        {
            string sql = "SP_ALL_DEPARTAMENTOS";
            this.com.CommandType = CommandType.StoredProcedure;
            this.com.CommandText = sql;
            await this.cn.OpenAsync();
            this.reader = await this.com.ExecuteReaderAsync();
            List<string> departamentos = new List<string>();
            while (await this.reader.ReadAsync())
            {
                string nombre = this.reader["DNOMBRE"].ToString();
                departamentos.Add(nombre);
            }
            await this.reader.CloseAsync();
            await this.cn.CloseAsync();
            return departamentos;
        }
        
        public async Task<EmpleadosParametersOut> GetEmpleadosModelAsync(string nombreDepartamento)
        {
            string sql = "SP_EMPLEADOS_DEPARTAMENTOS_OUT";
            this.com.Parameters.AddWithValue("@nombre", nombreDepartamento);

            SqlParameter pamSuma = new SqlParameter();
            pamSuma.ParameterName = "@suma";
            pamSuma.Value = 0;
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

            EmpleadosParametersOut model = new EmpleadosParametersOut();
            //si inicializamos la lista aqui, no hay empleados cuando apellidos = null
            //si inicializamos la lista en el model, no hay empleados cuando count = 0
            //model.Apellidos = new List<string>(); 
            while (await this.reader.ReadAsync())
            {
                string apellido = this.reader["APELLIDO"].ToString();
                model.Apellidos.Add(apellido);
            }

            await this.reader.CloseAsync();
            //ESTABLECEMOS LOS DATOS
            model.SumaSalarial = int.Parse(pamSuma.Value.ToString());
            model.MediaSalarial = int.Parse(pamMedia.Value.ToString());
            model.Personas = int.Parse(pamPersonas.Value.ToString());

            await this.cn.CloseAsync();
            this.com.Parameters.Clear();
            return model;
        }
    }
}
