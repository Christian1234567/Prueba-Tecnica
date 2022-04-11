using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Sql;
using System.Data.SqlClient;
using BaseDatos.Interfaces;

namespace BaseDatos
{
    public class Conexion : IConexion
    {
        private readonly string server = @"DESKTOP-I3PLNEH\SQLEXPRESS01";
        private readonly string dataBase = "ConsultaMedica";
        private string connectionString = "";
        private SqlConnection connection = null;

        private Conexion()
        {

            //DESKTOP-I3PLNEH\SQLEXPRESS01
            connectionString = $"Server={server}; Initial Catalog={dataBase}; Integrated Security=True;";
            connection = new SqlConnection(connectionString);
        }

        public void Open()
        {
            connection.Open();
        }

        public void Close()
        {
            connection.Close();
        }

        public bool ExecuteCommand(string nameProcedure, Dictionary<string, object> parameters)
        {
            try
            {
                var command = connection.CreateCommand();
                command.CommandType = System.Data.CommandType.StoredProcedure;
                command.CommandText = nameProcedure;
                if (parameters != null)
                {
                    foreach (var parameter in parameters)
                        command.Parameters.AddWithValue(parameter.Key, parameter.Value);
                }
                command.ExecuteNonQuery();
                return true;
            }
            catch (Exception e)
            {
                return false;
            }
        }

        public SqlDataReader ExecuteCommandRead(string nameProcedure, Dictionary<string, object> parameters)
        {
            try
            {
                var command = connection.CreateCommand();
                command.CommandType = System.Data.CommandType.StoredProcedure;
                command.CommandText = nameProcedure;
                if (parameters != null)
                {
                    foreach (var parameter in parameters)
                        command.Parameters.AddWithValue(parameter.Key, parameter.Value);
                }
                return command.ExecuteReader();
            }
            catch (Exception e)
            {
                return null;
            }
        }

        private static Conexion instance = null;
        public static Conexion getInstance()
        {
            if (instance == null)
                instance = new Conexion();
            return instance;
        }
    }
}
