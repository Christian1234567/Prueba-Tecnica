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
    public class DiagnosticosDAO : IConsults<Diagnostico>
    {
        public List<Diagnostico> GetAll()
        {
            List<Diagnostico> diagnosticos = new List<Diagnostico>();
            var conexion = Conexion.getInstance();
            conexion.Open();
            var reader = conexion.ExecuteCommandRead("AllDiagnosticos", null);
            if (reader != null)
            {
                while (reader.Read())
                {
                    diagnosticos.Add(new Diagnostico
                    {
                        NombrePaciente = reader.GetString(0),
                        Altura = reader.GetInt32(1).ToString(),
                        Peso = reader.GetInt32(2).ToString(),
                        Descripcion = reader.GetString(3),
                        Sintomas = reader.GetString(4).Split(','),
                        Receta = reader.GetString(5).Split(',')
                    });
                }
            }
            conexion.Close();
            return diagnosticos;
        }

        public Diagnostico GetById(int Id)
        {
            Diagnostico diagnostico = new Diagnostico();
            var conexion = Conexion.getInstance();
            conexion.Open();
            var parameters =  new Dictionary<string, object>();
            parameters.Add("@IdDiagnostico", Id);
            var reader = conexion.ExecuteCommandRead("GetDiagnostico", parameters);
            if (reader != null)
            {
                while (reader.Read())
                {
                    diagnostico = new Diagnostico
                    {
                        NombrePaciente = reader.GetString(0),
                        Altura = reader.GetInt32(1).ToString(),
                        Peso = reader.GetInt32(2).ToString(),
                        Descripcion = reader.GetString(3),
                        Sintomas = reader.GetString(4).Split(','),
                        Receta = reader.GetString(5).Split(',')
                    };
                }
            }
            conexion.Close();
            return diagnostico;
        }

        public bool InsertDiagnostico(DiagnosticoDTO diagnostico)
        {
            var conexion = Conexion.getInstance();
            conexion.Open();
            var parameter = new Dictionary<string, object>();
            parameter.Add("@IdPaciente", diagnostico.IdPaciente);
            parameter.Add("@IdCita", diagnostico.IdCita);
            parameter.Add("@Altura", diagnostico.Altura);
            parameter.Add("@Peso", diagnostico.Peso);
            parameter.Add("@Descripcion", diagnostico.Descripcion);
            parameter.Add("@Sintoma", diagnostico.Sintomas);
            parameter.Add("@Receta", diagnostico.Receta);
            var result = conexion.ExecuteCommand("CreateDiagnostico", parameter);
            conexion.Close();
            return result;
        }
    }
}
