using Microsoft.AspNetCore.Mvc;
using VeterinariaApi.Models;
using VeterinariaApi.Services;
using System.Collections.Generic;

namespace VeterinariaApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ClientesController : ControllerBase
    {
        private readonly ClienteService _clienteService;

        public ClientesController(ClienteService clienteService)
        {
            _clienteService = clienteService;
        }

        [HttpGet]
        public ActionResult<IEnumerable<Cliente>> GetClientes()
        {
            return Ok(_clienteService.GetAllClientes());
        }

        [HttpGet("{id}")]
        public ActionResult<Cliente> GetCliente(int id)
        {
            var cliente = _clienteService.GetClienteById(id);
            if (cliente == null)
                return NotFound();
            return Ok(cliente);
        }

        [HttpPost]
        public ActionResult<Cliente> PostCliente(Cliente cliente)
        {
            _clienteService.CreateCliente(cliente);
            return CreatedAtAction(nameof(GetCliente), new { id = cliente.Id }, cliente);
        }

        [HttpPut("{id}")]
        public IActionResult PutCliente(int id, Cliente cliente)
        {
            if (id != cliente.Id)
                return BadRequest();

            var existingCliente = _clienteService.GetClienteById(id);
            if (existingCliente == null)
                return NotFound();

            _clienteService.UpdateCliente(cliente);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteCliente(int id)
        {
            var cliente = _clienteService.GetClienteById(id);
            if (cliente == null)
                return NotFound();

            _clienteService.DeleteCliente(id);
            return NoContent();
        }
    }
}
