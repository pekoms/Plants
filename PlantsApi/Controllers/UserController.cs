﻿using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Plants.Api.Services;
using Plants.Services.Dtos;
using PlantsApi.Controllers;

namespace Plants.Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class UserController : Controller
    {

        private IUserService _userService;
        private readonly ILogger<WeatherForecastController> _logger;
        public UserController(IUserService userService, ILogger<WeatherForecastController> logger)
        {
            _userService = userService;
            _logger = logger;
        }

        //    // GET: UserController
        [HttpGet(Name ="GetAllUsers")]
        public async Task<ActionResult<List<User>>> Get()
        {
            return await _userService.GetAllUsers();
        }

        // GET: UserController/Details/5
        //[HttpGet]
        //public ActionResult Details(int id)
        //{
        //    return View();
        //}

        //    // GET: UserController/Create
        //    public ActionResult Create()
        //    {
        //        return View();
        //    }

        //    // POST: UserController/Create
        //    [HttpPost]
        //    [ValidateAntiForgeryToken]
        //    public ActionResult Create(IFormCollection collection)
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
