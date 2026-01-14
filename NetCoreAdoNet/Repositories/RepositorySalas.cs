using Microsoft.Data.SqlClient;
using System.Data;
using System;
using System.Collections.Generic;
using System.Text;

namespace NetCoreAdoNet.Repositories
{
    public class RepositorySalas
    {
        //son como lso service de front
        SqlConnection cn;
        SqlCommand com;
        SqlDataReader reader;

        public RepositorySalas()
        {
            string connectionString = @"Data Source=LOCALHOST\DEVELOPER;Initial Catalog=HOSPITAL;Persist Security Info=True;User ID=SA;Encrypt=True;Trust Server Certificate=True";
            this.cn = new SqlConnection(connectionString);
            this.com = new SqlCommand();
            this.com.Connection = this.cn;
        }

        //necesitamos un metodo que me devuelva un conjunto con los nombres de las salas
        //tiene que ser async
        public async Task<List<string>> GetNombresSalasAsync()
        {
            //cambiamos los metodos asociados a metodos asincronos
            string sql = "select distinct NOMBRE from SALA";
            this.com.CommandType = CommandType.Text;
            this.com.CommandText = sql;
            await this.cn.OpenAsync();
            this.reader = await this.com.ExecuteReaderAsync();
            //CREAMOS LA COLECCION A DEVOLVER
            List<string> salas = new List<string>();
            while (await this.reader.ReadAsync())
            {
                string nombre = this.reader["NOMBRE"].ToString();
                salas.Add(nombre);
            }
            await this.reader.CloseAsync();
            await this.cn.CloseAsync();
            return salas;
        }

        //metodo para actualizar una sala
        public async Task<int> UpdateSalaAsync(string newName, string oldName)
        {
            string sql = "update SALA set NOMBRE=@newName where NOMBRE=@oldName";
            SqlParameter pamNew = new SqlParameter("@newName", newName);
            SqlParameter pamOld = new SqlParameter("@oldName", oldName);
            this.com.Parameters.Add(pamNew);
            this.com.Parameters.Add(pamOld);
            this.com.CommandType = CommandType.Text;
            this.com.CommandText = sql;
            await this.cn.OpenAsync();
            int registros = await this.com.ExecuteNonQueryAsync();
            await this.cn.CloseAsync();
            this.com.Parameters.Clear();
            return registros;
        }
    }
}
