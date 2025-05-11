using Login.Server.Models;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Login.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class Usuarios : ControllerBase
    {
        //Se inyecta el contexto DBCUsuarios a el controlador Usuarios
        private readonly DBCUsuarios _context;

        public Usuarios(DBCUsuarios context)
        {
            _context = context;
        }

        // GET: api/<Usuarios>
        [HttpGet]
        public IActionResult Get()
        {
            return Ok(_context.Usuarios.Select(a => a).ToList());      
        }

        // GET api/<Usuarios>/5
        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            return Ok(_context.Usuarios.Where(a => a.Id == id).Select(a => a).FirstOrDefault());
        }

        //// POST api/<Usuarios>
        //[HttpPost]
        //public void Post([FromBody] string value)
        //{
        //}

        //// PUT api/<Usuarios>/5
        //[HttpPut("{id}")]
        //public void Put(int id, [FromBody] string value)
        //{
        //}

        //// DELETE api/<Usuarios>/5
        //[HttpDelete("{id}")]
        //public void Delete(int id)
        //{
        //}
    }
}
