using FlowerApi.Models;
using FlowerApi.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace FlowerApi.Controllers
{
    [Route("api/[controller]")]
    [EnableCors("MyPolicy")]
    [ApiController]
    [Authorize]
    public class FlowerController : ControllerBase
    {
        private readonly FlowerService _service;

        public FlowerController(FlowerService flowerService)
        {
            _service = flowerService;

        }
        // GET: api/<FlowerController>
        [HttpGet]
        public IEnumerable<Flower> Get()
        {
            return _service.FetchFlowerDetails();
        }

        // GET api/<FlowerController>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<FlowerController>
        [HttpPost]
        public Flower Post([FromBody] Flower newFlower)
        {
            return _service.InserNewFlower(newFlower);
        }

        // PUT api/<FlowerController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<FlowerController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
