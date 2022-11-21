using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Plants.Api.Services;
using Plants.Services.Dtos;
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
            return await _userService.GetAllUsers();
        }

        //GET: UserController/Details/5
        [HttpGet("{id}",Name = "GetDetailedUser")]
        public async Task<ActionResult<User>> Details(string id, CancellationToken cancellationToken)
        {
            return await _userService.Get(id);
        }

        // GET: UserController/Create

        [HttpPost(Name ="CreateUser")]
        public async Task<ActionResult> Create([FromBody] User newUser,CancellationToken cancellationToken)
        {
               await _userService.Create(newUser);
            return await Create(newUser, cancellationToken);
        }

        // POST: UserController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        //    // GET: UserController/Edit/5
        //    public ActionResult Edit(int id)
        //    {
        //        return View();
        //    }

        //    // POST: UserController/Edit/5
        //    [HttpPost]
        //    [ValidateAntiForgeryToken]
        //    public ActionResult Edit(int id, IFormCollection collection)
        //    {
        //        try
        //        {
        //            return RedirectToAction(nameof(Index));
        //        }
        //        catch
        //        {
        //            return View();
        //        }
        //    }

        //    // GET: UserController/Delete/5
        //    public ActionResult Delete(int id)
        //    {
        //        return View();
        //    }

        //    // POST: UserController/Delete/5
        //    [HttpPost]
        //    [ValidateAntiForgeryToken]
        //    public ActionResult Delete(int id, IFormCollection collection)
        //    {
        //        try
        //        {
        //            return RedirectToAction(nameof(Index));
        //        }
        //        catch
        //        {
        //            return View();
        //        }
        //    }
        //}
    }
}
