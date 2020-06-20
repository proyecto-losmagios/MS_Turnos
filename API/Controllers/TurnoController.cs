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
    public class TurnoController : ControllerBase {
        private readonly ITurnoServices _service;

        public TurnoController(ITurnoServices service) {
            _service = service;
        }

        [HttpPost]
        public ActionResult<Turno> Post(TurnoDto paciente) {
            return StatusCode(201, _service.CreateTurno(paciente));
        }

        [HttpGet]
        public IActionResult GetTurno([FromQuery] string q) {
            try {
                return new JsonResult(_service.SearchTurno(q)) { StatusCode = 200 };
            }
            catch (Exception e) {
                return BadRequest(e.Message);
            }
        }
    }
}