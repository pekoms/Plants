using Microsoft.AspNetCore.Mvc;
using Plants.Api.Domain.Entities;
using Plants.Api.Services;
using Plants.Domain.Domain.Dtos;
using System.IdentityModel.Tokens.Jwt;

namespace Plants.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UserController : Controller
    {

        private IUserService _userService;
        private IConfiguration _config;
        private IUtilsService _utils;


        public UserController(IUserService userService, IConfiguration config, IUtilsService utils)
        {
            _userService = userService;
            _config = config;
            _utils = utils;

        }

        // GET: UserController
        [HttpGet(Name = "GetAllUsers")]
        public async Task<ActionResult<List<User>>> Get(CancellationToken cancellationToken)
        {
            var users = await _userService.GetAllUsers();

            return Ok(users);
        }

        //GET: UserController/Details/5
        [HttpGet("{id}", Name = "GetDetailedUser")]
        public async Task<ActionResult<User>> GetDetailedUser(string id, CancellationToken cancellationToken)
        {
            var user = await _userService.Get(id); ;

            return Ok(user);
        }

        // POST: UserController/Create

        [HttpPost(Name = "CreateUser")]
        public async Task<ActionResult> CreateUser([FromBody] UserDTO newUser, CancellationToken cancellationToken)
        {
            // Verifica si el usuario ya existe en la base de datos         
            var existingUser = await _userService.Get(newUser.Name);
            if (existingUser != null)
            {
                return BadRequest("El usuario ya existe.");
            }

            // Crea un nuevo usuario
            var userRegistration = new User
            {
                Name = newUser.Name,
                Password = await _utils.HashPassword(newUser.Password)
            };

            await _userService.Create(userRegistration);
            return Ok(userRegistration);
        }

        // POST: UserController/Edit/5
        [HttpPut("{id}", Name = "UpdateDetailedUser")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> UpdateDetailedUser(string id, [FromBody] UserDTO user, CancellationToken cancellationToken)
        {
            var userUpdate = await _userService.Get(id);
            await _userService.Update(id, userUpdate);

            return Ok(user);
        }

        // Delete: UserController/Delete/5
        [HttpDelete("{id}", Name = "DeleteDetailedUser")]
        public async Task<ActionResult> Delete(string id)
        {
            await _userService.Remove(id);

            return Ok();
        }

        [HttpPost("Login")]
        public async Task<IActionResult> Login([FromBody] UserDTO user, CancellationToken cancellationToken)
        {
           
                // Verifica si el usuario existe            
                var loginUser = await _userService.Get(user.Name);
                if (loginUser == null)
                {
                    return Unauthorized("Credenciales incorrectas.");
                }

                // Verifica la contraseña
                if (await _utils.VerifyPassword(user.Password, loginUser.Password) != true)
                {
                    return Unauthorized("Credenciales incorrectas.");
                }

                // Genera un token JWT
                var token = await _utils.GenerateJwtToken(loginUser.Name);

                return Ok(new
                {
                    token = new JwtSecurityTokenHandler().WriteToken(token),
                    expiration = token.ValidTo
                });            
           
        }




    }
}

