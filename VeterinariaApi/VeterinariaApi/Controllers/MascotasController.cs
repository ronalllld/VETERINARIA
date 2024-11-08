using Microsoft.AspNetCore.Mvc;
using VeterinariaApi.Models;
using VeterinariaApi.Services;
using System.Collections.Generic;

namespace VeterinariaApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MascotasController : ControllerBase
    {
        private readonly MascotaService _mascotaService;

        public MascotasController(MascotaService mascotaService)
        {
            _mascotaService = mascotaService;
        }

        [HttpGet]
        public ActionResult<IEnumerable<Mascota>> GetMascotas()
        {
            return Ok(_mascotaService.GetAllMascotas());
        }

        [HttpGet("{id}")]
        public ActionResult<Mascota> GetMascota(int id)
        {
            var mascota = _mascotaService.GetMascotaById(id);
            if (mascota == null)
                return NotFound();
            return Ok(mascota);
        }

        [HttpPost]
        public ActionResult<Mascota> PostMascota(Mascota mascota)
        {
            _mascotaService.CreateMascota(mascota);
            return CreatedAtAction(nameof(GetMascota), new { id = mascota.Id }, mascota);
        }

        [HttpPut("{id}")]
        public IActionResult PutMascota(int id, Mascota mascota)
        {
            if (id != mascota.Id)
                return BadRequest();

            var existingMascota = _mascotaService.GetMascotaById(id);
            if (existingMascota == null)
                return NotFound();

            _mascotaService.UpdateMascota(mascota);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteMascota(int id)
        {
            var mascota = _mascotaService.GetMascotaById(id);
            if (mascota == null)
                return NotFound();

            _mascotaService.DeleteMascota(id);
            return NoContent();
        }
    }
}
