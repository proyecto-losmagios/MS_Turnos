using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Application.Services;
using Domain.DTOs;
using Domain.Entities;


namespace API.Controllers {

    [Route("api/[controller]")]
    [ApiController]
    public class AgendaController : ControllerBase {
        private readonly IAgendaServices _service;

        public AgendaController(IAgendaServices service) {
            _service = service;
        }

        [HttpPost]
        public ActionResult<Agenda> Post(AgendaDto paciente) {
            return StatusCode(201, _service.CreateAgenda(paciente));
        }

        [HttpGet]
        public IActionResult GetAgenda([FromQuery] DateTime from, [FromQuery] DateTime to, [FromQuery] int medico) {
            try {
                return new JsonResult(_service.SearchAgenda(from, to, medico)) { StatusCode = 200 };
            }
            catch (Exception e) {
                return BadRequest(e.Message);
            }
        }
    }
}