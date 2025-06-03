using Login.Server.auth;
using Login.Server.Models;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Login.Server.Controllers
{
    [Route("api/[controller]")]
    [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
    [ApiController]
    public class Usuarios : ControllerBase
    {
        //Se inyecta el contexto DBCUsuarios a el controlador Usuarios
        private readonly DBCUsuarios _context;

        //Inyectamos la clase con acceso a las funciones de autenticacion
        private readonly Configuration _configuration;  

        public Usuarios(DBCUsuarios context, Configuration configuration)
        {
            _context = context;
            _configuration = configuration;
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
