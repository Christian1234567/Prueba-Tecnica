using BaseDatos;
using BaseDatos.Interfaces;
using Modelos.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Modelos.DAO
{
    public class CitasDAO : IConsults<Cita>
    {
        public List<Cita> GetAll()
        {
            List<Cita> citas = new List<Cita>();
            var conexion = Conexion.getInstance();
            conexion.Open();
            var reader = conexion.ExecuteCommandRead("AllCitas", null);
            if (reader != null)
            {
                while(reader.Read())
                {
                    citas.Add(new Cita
                    {
                        NombreDoctor = reader.GetString(0),
                        NombrePaciente = reader.GetString(1),
                        Fecha = reader.GetString(2),
                        Hora = reader.GetTimeSpan(3).ToString()
                    });
                }
            }
            conexion.Close();
            return citas;
        }

        public Cita GetById(int Id)
        {
            Cita cita = null;
            var conexion = Conexion.getInstance();
            conexion.Open();
            var parameters = new Dictionary<string, object>();
            parameters.Add("@IdCita", Id);
            var reader = conexion.ExecuteCommandRead("GetCita", parameters);
            if (reader != null)
            {
                while (reader.Read())
                {
                    cita = new Cita
                    {
                        NombreDoctor = reader.GetString(0),
                        NombrePaciente = reader.GetString(1),
                        Fecha = reader.GetString(2),
                        Hora = reader.GetTimeSpan(3).ToString()
                    };
                }
            }
            conexion.Close();
            return cita;
        }

        public bool InsertCita(CitaDTO cita)
        {
            var conexion = Conexion.getInstance();
            conexion.Open();
            var parameter = new Dictionary<string, object>();
            parameter.Add("@IdPaciente", cita.IdPaciente);
            parameter.Add("@IdDoctor", cita.IdDoctor);
            parameter.Add("@Fecha", cita.Fecha);
            var result = conexion.ExecuteCommand("CreateCita", parameter);
            conexion.Close();
            return result;
        }

        public bool CancelCita(CitaCancelarDTO cita)
        {
            var conexion = Conexion.getInstance();
            conexion.Open();
            var parameter = new Dictionary<string, object>();
            parameter.Add("@IdCita", cita.IdCita);
            var result = conexion.ExecuteCommand("CancelCita", parameter);
            conexion.Close();
            return result;
        }
    }
}
