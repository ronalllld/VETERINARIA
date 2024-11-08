using Microsoft.AspNetCore.Mvc;
using VeterinariaApi.Models;
using VeterinariaApi.Services;
using System.Collections.Generic;

namespace VeterinariaApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ServiciosController : ControllerBase
    {
        private readonly ServicioService _servicioService;

        public ServiciosController(ServicioService servicioService)
        {
            _servicioService = servicioService;
        }

        [HttpGet]
        public ActionResult<IEnumerable<Servicio>> GetServicios()
        {
            return Ok(_servicioService.GetAllServicios());
        }

        [HttpGet("{id}")]
        public ActionResult<Servicio> GetServicio(int id)
        {
            var servicio = _servicioService.GetServicioById(id);
            if (servicio == null)
                return NotFound();
            return Ok(servicio);
        }

        [HttpPost]
        public ActionResult<Servicio> PostServicio(Servicio servicio)
        {
            _servicioService.CreateServicio(servicio);
            return CreatedAtAction(nameof(GetServicio), new { id = servicio.Id }, servicio);
        }

        [HttpPut("{id}")]
        public IActionResult PutServicio(int id, Servicio servicio)
        {
            if (id != servicio.Id)
                return BadRequest();

            var existingServicio = _servicioService.GetServicioById(id);
            if (existingServicio == null)
                return NotFound();

            _servicioService.UpdateServicio(servicio);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteServicio(int id)
        {
            var servicio = _servicioService.GetServicioById(id);
            if (servicio == null)
                return NotFound();

            _servicioService.DeleteServicio(id);
            return NoContent();
        }
    }
}
