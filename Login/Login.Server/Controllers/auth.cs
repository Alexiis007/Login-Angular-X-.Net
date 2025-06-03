using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Login.Server.Models;
using Login.Server.auth;
using Microsoft.EntityFrameworkCore;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Login.Server.Controllers
{
    [Route("api/[controller]")]
    [AllowAnonymous]
    [ApiController]
    public class auth : ControllerBase
    {
        private readonly DBCUsuarios _context;
        private readonly Configuration _configuration;

        public auth(DBCUsuarios context, Configuration configuration)
        {
            _context = context;
            _configuration = configuration;
        }

        //Registramos nuevos usuarios reciviendo un modelo de Usuario y creando un 
        // nuevo modelo de usuario usando como datos los datos del modelo que se recibe
        [HttpPost]
        [Route("register")]
        public async Task<IActionResult> Register(Usuario modelo)
        {
            Usuario usuario = new Usuario();
            usuario.Nombre = modelo.Nombre;      
            usuario.Apellido = modelo.Apellido;
            usuario.Correo = modelo.Correo;
            usuario.ContraseñaHash = _configuration.encriptSHA256(modelo.ContraseñaHash);
            usuario.Rol = modelo.Rol;
            usuario.Activo = modelo.Activo;

            await _context.Usuarios.AddAsync(usuario);
            await _context.SaveChangesAsync();

            if (usuario.Id > 0)
            {
                return Ok(new { mensaje = "Usuario registrado correctamente" });
            }
            else
            {
                return Ok(new { mensaje = "Error al registrar el usuario" });
            }
        }

        [HttpPost]
        [Route("login")]
        public async Task<IActionResult> Login(Usuario modelo)
        {
            var usuario = await _context.Usuarios
            .Where(x => x.Correo == modelo.Correo && x.ContraseñaHash == _configuration.encriptSHA256(modelo.ContraseñaHash)
            ).FirstOrDefaultAsync();

            if (usuario == null) {
                return Ok(new { mensaje = "Usuario o contraseña incorrectos" });
            }
            else
            {
                //Generamos el token
                var token = _configuration.generatorJWT(usuario);
                return Ok(new { token, mensaje = "Usuario logueado correctamente" });
            }
        }
    }
}
