using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Plants.Api.Domain.Entities;
using Plants.Api.Services;
using Plants.Services.Services;


namespace Plants.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UserController : Controller
    {

        private IUserService _userService;

        public UserController(IUserService userService)
        {
            _userService = userService;

        }

        // GET: UserController
        [HttpGet(Name = "GetAllUsers")]
        public async Task<ActionResult<List<User>>> Get(CancellationToken cancellationToken)
        {
            var users = await _userService.GetAllUsers();

            return Ok(users);
        }

        //GET: UserController/Details/5
        [HttpGet("{id}",Name = "GetDetailedUser")]
        public async Task<ActionResult<User>> GetDetailedUser(string id, CancellationToken cancellationToken)
        {
            var user = await _userService.Get(id); ;

            return Ok(user);
        }

        // POST: UserController/Create

        [HttpPost(Name ="CreateUser")]
        public async Task<ActionResult> CreateUser([FromBody] User newUser,CancellationToken cancellationToken)
        {
            await _userService.Create(newUser);
            return  Ok(newUser);
        }

        // POST: UserController/Edit/5
        [HttpPut("{id}",Name ="UpdateDetailedUser")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> UpdateDetailedUser(string id, [FromBody] User user, CancellationToken cancellationToken)
        {
                await _userService.Update(id, user);

                return Ok(user);
        }

        // Delete: UserController/Delete/5
        [HttpDelete("{id}", Name = "DeleteDetailedUser")]
        public async Task<ActionResult> Delete(string id)
        {
             await _userService.Remove(id);
            
             return Ok();
        }

     
    }
}

