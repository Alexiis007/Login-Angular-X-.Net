using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Login.Server.Models;
using System.Security.Cryptography;

namespace Login.Server.auth
{
    public class Configuration
    {
        // Inyectamos la configuracion de appsettings
        private readonly IConfiguration _configuration;
        //Inyeccion por constructor
        public Configuration(IConfiguration configuration)
        {
            _configuration = configuration;
        }
        //Funcion para encriptar
        public string encriptSHA256(string param) 
        {
            using (SHA256 sha256Hash = SHA256.Create())
            {
                byte[] bytes = sha256Hash.ComputeHash(Encoding.UTF8.GetBytes(param));

                StringBuilder builder = new StringBuilder();

                for (int i = 0; i < bytes.Length; i++)
                {
                    //Se agrega el valor en exadecimal
                    builder.Append(bytes[i].ToString("x2"));
                }

                //Se regresa la cadena encriptada
                return builder.ToString();
            }
        }

        //Creando la funcion para generar el JWT. Le pasamos el modelo de Usuario
        public string generatorJWT(Usuario modelo) 
        {
            // Creamos el arreglo de Claims, que son los datos que se van a guardar en el token
            var userClaims = new[] 
            {
                new Claim(ClaimTypes.NameIdentifier, modelo.Id.ToString()),
                new Claim(ClaimTypes.Email, modelo.Correo.ToString())
            };

            // Creamos la variable secret key en base a la llave que tenemos en el appsettings
            var secretKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["Jwt:Key"]));
            
            //Creamos la credencial en base a la secret key
            var credentials = new SigningCredentials(secretKey, SecurityAlgorithms.HmacSha256Signature);

            // creamos la configuracion del token en base a los claims y la credencial
            var jwtConfig = new JwtSecurityToken(
                claims: userClaims,
                expires: DateTime.UtcNow.AddMinutes(10),
                signingCredentials: credentials
            );

            return new JwtSecurityTokenHandler().WriteToken(jwtConfig);
        }


    }
}
