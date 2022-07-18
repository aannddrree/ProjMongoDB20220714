using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ProjMongoDB20220714.Models;
using ProjMongoDB20220714.Services;
using System.Collections.Generic;

namespace ProjMongoDB20220714.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ClientController : ControllerBase
    {

        private readonly ClientService _clientService;
        private readonly AddressService _addressService;

        public ClientController(ClientService clientService, AddressService addressService)
        {
            _clientService = clientService;
            _addressService = addressService;
        }

        [HttpGet]
        public ActionResult<List<Client>> Get() =>
            _clientService.Get();


        [HttpGet("{id:length(24)}", Name = "GetClient")]
        public ActionResult<Client> Get(string id)
        {
            var client = _clientService.Get(id);

            if (client == null)
            {
                return NotFound();
            }

            return client;
        }

        [HttpPost]
        public ActionResult<Client> Create(Client client)
        {

            Address address = _addressService.Create(client.Address);
            client.Address = address;

            _clientService.Create(client);

            return CreatedAtRoute("GetClient", new { id = client.Id.ToString() }, client);
        }

        [HttpPut("{id:length(24)}")]
        public IActionResult Update(string id, Client clienteIn)
        {
            var cliente = _clientService.Get(id);

            if (cliente == null)
            {
                return NotFound();
            }

            _clientService.Update(id, clienteIn);

            return NoContent();
        }

        [HttpDelete("{id:length(24)}")]
        public IActionResult Delete(string id)
        {
            var cliente = _clientService.Get(id);

            if (cliente == null)
            {
                return NotFound();
            }

            _clientService.Remove(cliente.Id);

            return NoContent();
        }
    }
}
