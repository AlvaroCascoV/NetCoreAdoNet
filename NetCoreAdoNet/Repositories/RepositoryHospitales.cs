using Microsoft.Data.SqlClient;
using NetCoreAdoNet.Models;
using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Text;
using System.Data;

namespace NetCoreAdoNet.Repositories
{
    public class RepositoryHospitales
    {
        SqlConnection cn;
        SqlCommand com;
        SqlDataReader reader; 

        public RepositoryHospitales()
        {
            string connectionString = @"Data Source=LOCALHOST\DEVELOPER;Initial Catalog=HOSPITAL;Persist Security Info=True;User ID=SA;Encrypt=True;Trust Server Certificate=True";
            this.cn = new SqlConnection(connectionString);
            this.com = new SqlCommand();
            this.com.Connection = this.cn;
        }

        public async Task<List<Hospital>> GetHospitalesAsync()
        {
            string sql = "select * from HOSPITAL";
            this.com.CommandType = CommandType.Text;
            this.com.CommandText = sql;
            await this.cn.OpenAsync();
            this.reader = await this.com.ExecuteReaderAsync();
            List<Hospital> hospitales = new List<Hospital>();
            while(await this.reader.ReadAsync())
            {
                Hospital hospital = new Hospital();
                hospital.HOSPITAL_COD = (int)this.reader["HOSPITAL_COD"];
                hospital.NOMBRE = this.reader["NOMBRE"].ToString();
                hospital.DIRECCION = this.reader["DIRECCION"].ToString();
                hospital.TELEFONO = this.reader["TELEFONO"].ToString();
                hospital.NUM_CAMA = (int)this.reader["NUM_CAMA"];
                hospitales.Add(hospital);
            }
            await this.reader.CloseAsync();
            await this.cn.CloseAsync();
            return hospitales;
        }

        public async Task CreateHospitalAsync(int hospitalCod, string nombre, string direccion, string telefono, int numCamas)
        {
            string sql = "insert into HOSPITAL values (@hospitalCod, @nombre, @direccion, @telefono, @numCamas)";
            this.com.Parameters.AddWithValue("@hospitalCod", hospitalCod);
            this.com.Parameters.AddWithValue("@nombre", nombre);
            this.com.Parameters.AddWithValue("@direccion", direccion);
            this.com.Parameters.AddWithValue("@telefono", telefono);
            this.com.Parameters.AddWithValue("@numCamas", numCamas);
            this.com.CommandType = CommandType.Text;
            this.com.CommandText = sql;
            await this.cn.OpenAsync();
            await this.com.ExecuteNonQueryAsync();
            await this.cn.CloseAsync();
            this.com.Parameters.Clear();
        }

        public async Task UpdateHospitalAsync(int hospitalCod, string nombre, string direccion, string telefono, int numCamas)
        {
            string sql = "update HOSPITAL set NOMBRE=@nombre, DIRECCION=@direccion, TELEFONO=@telefono, NUM_CAMA=@numCamas where HOSPITAL_COD=@hospitalCod";
            this.com.Parameters.AddWithValue("@hospitalCod", hospitalCod);
            this.com.Parameters.AddWithValue("@nombre", nombre);
            this.com.Parameters.AddWithValue("@direccion", direccion);
            this.com.Parameters.AddWithValue("@telefono", telefono);
            this.com.Parameters.AddWithValue("@numCamas", numCamas);
            this.com.CommandType = CommandType.Text;
            this.com.CommandText = sql;
            await this.cn.OpenAsync();
            await this.com.ExecuteNonQueryAsync();
            await this.cn.CloseAsync();
            this.com.Parameters.Clear();
        }

        public async Task DeleteHospitalAsync(int hospitalCod)
        {
            string sql = "delete from HOSPITAL where HOSPITAL_COD=@hospitalCod";
            this.com.Parameters.AddWithValue("@hospitalCod", hospitalCod);
            this.com.CommandType = CommandType.Text;
            this.com.CommandText = sql;
            await this.cn.OpenAsync();
            await this.com.ExecuteNonQueryAsync();
            await this.cn.CloseAsync();
            this.com.Parameters.Clear();
        }
    }
}
