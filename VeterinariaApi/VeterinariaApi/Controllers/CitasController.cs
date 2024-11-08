using Microsoft.AspNetCore.Mvc;
using VeterinariaApi.Models;
using VeterinariaApi.Services;
using System.Collections.Generic;

namespace VeterinariaApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CitasController : ControllerBase
    {
        private readonly CitaService _citaService;

        public CitasController(CitaService citaService)
        {
            _citaService = citaService;
        }

        [HttpGet]
        public ActionResult<IEnumerable<Cita>> GetCitas()
        {
            return Ok(_citaService.GetAllCitas());
        }

        [HttpGet("{id}")]
        public ActionResult<Cita> GetCita(int id)
        {
            var cita = _citaService.GetCitaById(id);
            if (cita == null)
                return NotFound();
            return Ok(cita);
        }

        [HttpPost]
        public ActionResult<Cita> PostCita(Cita cita)
        {
            _citaService.CreateCita(cita);
            return CreatedAtAction(nameof(GetCita), new { id = cita.Id }, cita);
        }

        [HttpPut("{id}")]
        public IActionResult PutCita(int id, Cita cita)
        {
            if (id != cita.Id)
                return BadRequest();

            var existingCita = _citaService.GetCitaById(id);
            if (existingCita == null)
                return NotFound();

            _citaService.UpdateCita(cita);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteCita(int id)
        {
            var cita = _citaService.GetCitaById(id);
            if (cita == null)
                return NotFound();

            _citaService.DeleteCita(id);
            return NoContent();
        }
    }
}
