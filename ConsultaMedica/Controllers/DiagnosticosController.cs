using Modelos.DAO;
using Modelos.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;

namespace ConsultaMedica.Controllers
{
    public class DiagnosticoController : ApiController
    {
        public List<Diagnostico> GetAll()
        {
            DiagnosticosDAO dao = new DiagnosticosDAO();
            return dao.GetAll();
        }

        public Diagnostico GetDiagnostico([FromUri] int Id)
        {
            DiagnosticosDAO dao = new DiagnosticosDAO();
            return dao.GetById(Id);
        }

        [HttpPost]
        public bool Create([FromBody] DiagnosticoDTO diagnostico)
        {
            DiagnosticosDAO dao = new DiagnosticosDAO();
            return dao.InsertDiagnostico(diagnostico);
        }
    }
}