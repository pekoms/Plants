using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.DependencyInjection;
using Plants.Api.Domain.Entities;
using Plants.Api.Infrastructure.TokenValidation;
using Plants.Api.Services;
using Plants.Domain.Domain.Dtos;
using System.IdentityModel.Tokens.Jwt;
using System.Text.Json;

namespace Plants.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CaptchaController : Controller
    {

        private IUserService _userService;
        private IConfiguration _config;
        private IUtilsService _utils;
        private ICaptchaService _captchaService;


        public CaptchaController(IUserService userService, IConfiguration config, IUtilsService utils, ICaptchaService captchaService)
        {
            _userService = userService;
            _config = config;
            _utils = utils;
            _captchaService = captchaService;
        }
       

        [HttpPost("verifyCaptcha")]
        public async Task<ActionResult> VerifyCaptcha([FromBody] string recaptchaToken)
        {            
            var secretKey = _config.GetSection("Captcha")["SecretKey"];
            var captchaResponse = await _captchaService.VerifyGoogleCaptcha(secretKey,recaptchaToken);

            return Ok(captchaResponse);
        }

    }
}

