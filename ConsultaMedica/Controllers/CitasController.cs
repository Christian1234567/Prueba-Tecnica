using Modelos.DAO;
using Modelos.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;

namespace ConsultaMedica.Controllers
{
    public class CitaController : ApiController
    {
        public List<Cita> GetAll()
        {
            CitasDAO dao = new CitasDAO();
            return dao.GetAll();
        }

        public Cita GetCita([FromUri] int Id)
        {
            CitasDAO dao = new CitasDAO();
            return dao.GetById(Id);
        }

        [HttpPost]
        public bool Create([FromBody] CitaDTO cita)
        {
            CitasDAO dao = new CitasDAO();
            return dao.InsertCita(cita);
        }

        [HttpPost]
        public bool Cancel([FromBody] CitaCancelarDTO cita)
        {
            CitasDAO dao = new CitasDAO();
            return dao.CancelCita(cita);
        }
    }
}
