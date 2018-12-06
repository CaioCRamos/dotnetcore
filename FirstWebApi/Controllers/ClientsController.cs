using System;
using System.Collections.Generic;
using FirstWebApi.Entities;
using FirstWebApi.ViewModels;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace FirstWebApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ClientsController : ControllerBase
    {
        private readonly IClients _clients;

        public ClientsController(IClients clients) => _clients = clients;

        [Route("badrequest")]
        [HttpGet]
        public ActionResult GetBadResult() => BadRequest();

        [HttpGet]
        public ActionResult<List<Client>> GetAll() => _clients.GetAll();

        [HttpGet("{id}")]
        public ActionResult<Client> Get(Guid id) => _clients.Get(id);

        [HttpPost]
        public ActionResult Post([FromBody] ClientSubmit newClient) => StatusCode(StatusCodes.Status201Created);

        [HttpPut("{id}")]
        public ActionResult Put(Guid id, [FromBody] ClientSubmit edit) => StatusCode(StatusCodes.Status200OK);

        [HttpDelete("{id}")]
        public ActionResult Delete(Guid id) => StatusCode(StatusCodes.Status200OK);
    }
}