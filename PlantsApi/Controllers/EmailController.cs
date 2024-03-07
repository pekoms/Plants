using Microsoft.AspNetCore.Mvc;
using Plants.Api.Services;

namespace Plants.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class EmailController : Controller
    {

        
        private IConfiguration _config;
        private IUtilsService _utils;
        private IEmailService _emailService;


        public EmailController( IConfiguration config, IEmailService emailService)
        {
            
            _config = config;            
            _emailService = emailService;
        }
       

        [HttpPost("CheckEmailExists")]
        public async Task<ActionResult> CheckEmailExists([FromBody] string email)
        {
            var exists = await _emailService.CheckEmailExists(email);

            return Ok(exists);
        }

        [HttpPost("SendEmail")]
        public async Task<ActionResult> SendEmail([FromBody] string email)
        {
            _emailService.SendEmail(email);

            return Ok("Success");
        }

    }
}

