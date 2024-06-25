using Microsoft.AspNetCore.Mvc;

namespace hng_task1.Controllers
{
    [ApiController]
    [Route("api/hello")]
    [EnableCors("AllowAllOrigins")]
    public class UserController : ControllerBase
    {

        private readonly ILogger<UserController> _logger;
        private readonly IIpService _ipService;
        private readonly IUserService _userService;


        public UserController(ILogger<UserController> logger, IIpService ipService, IUserService userService)
        {
            _logger = logger;
            _ipService = ipService;
            _userService = userService;
        }


        [HttpGet]
        public IActionResult GreetClient([FromQuery] string visitor_name)
        {
            _logger.LogInformation("Handling Log Information");
            var clientIp = _ipService.GetClientIp(HttpContext);
            _logger.LogInformation("Client Ip: {ClientIp}", clientIp);

            var user = _userService.CreateUser(visitor_name, clientIp);

            return Ok(user);
        }
    }
}