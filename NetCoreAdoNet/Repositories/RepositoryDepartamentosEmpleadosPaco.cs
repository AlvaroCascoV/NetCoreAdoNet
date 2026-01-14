using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Text;

namespace NetCoreAdoNet.Repositories
{
    public class RepositoryDepartamentosEmpleadosPaco
    {
        SqlConnection cn;
        SqlCommand com;
        SqlDataReader reader;

        public RepositoryDepartamentosEmpleadosPaco()
        {
            string connectionString = @"Data Source=LOCALHOST\DEVELOPER;Initial Catalog=HOSPITAL;Persist Security Info=True;User ID=SA;Encrypt=True;Trust Server Certificate=True";
            this.cn = new SqlConnection(connectionString);
            this.com = new SqlCommand();
            this.com.Connection = this.cn;
        }

        public async Task<List<string>> GetNombresDepartamentosAsync()
        {
            string sql = "select DNOMBRE from DEPT";
            this.com.CommandType = CommandType.Text;
            this.com.CommandText = sql;
            await this.cn.OpenAsync();
            this.reader = await this.com.ExecuteReaderAsync();
            List<string> nombresDept = new List<string>();
            while (await this.reader.ReadAsync())
            {
                string nombre = this.reader["DNOMBRE"].ToString();
                nombresDept.Add(nombre);
            }
            await this.reader.CloseAsync();
            await this.cn.CloseAsync();
            return nombresDept;
        }

        public async Task<List<string>> GetApellidosEmpleadosAsync(string dnombre)
        {
            string sql = "select E.APELLIDO from EMP E inner join DEPT D on E.DEPT_NO = D.DEPT_NO where D.DNOMBRE=@dnombre";

            SqlParameter pamDeptNombre = new SqlParameter("@dnombre", dnombre);
            this.com.Parameters.Add(pamDeptNombre);
            this.com.CommandType = CommandType.Text;
            this.com.CommandText = sql;
            await this.cn.OpenAsync();
            this.reader = this.com.ExecuteReader();
            List<string> apellidos = new List<string>();
            while (await this.reader.ReadAsync())
            {
                string ape = this.reader["APELLIDO"].ToString();
                apellidos.Add(ape);
            }
            this.com.Parameters.Clear();
            await this.reader.CloseAsync();
            await this.cn.CloseAsync();
            return apellidos;
        }

        public async Task DeleteEmpleadoAsync(string apellido)
        {
            string sql = "delete from EMP where APELLIDO=@apellido";
            SqlParameter pamApellido = new SqlParameter("@apellido", apellido);
            this.com.Parameters.Add(pamApellido);
            this.com.CommandType = CommandType.Text;
            this.com.CommandText = sql;
            await this.cn.OpenAsync();
            await this.com.ExecuteNonQueryAsync();
            await this.cn.CloseAsync();
            this.com.Parameters.Clear();
        }
    }
}
