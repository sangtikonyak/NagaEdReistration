using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using UserRegistration.CustomExceptions;
using UserRegistration.Model;
using UserRegistration.Repository;

namespace UserRegistration.Controllers
{
    [Route("api/v1/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        public readonly IUserService _service;

        public UserController(IUserService service)
        {
           this._service = service;
        }

        [HttpPost("Register")]
        public async Task<IActionResult> Register(User user)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(new { StatusCode = 400, error = new { message = "Request Body Field Required" } });
            }

            try
            {
                string response = await _service.Register(user);
                return Ok(new { StatusCode = 200, data = new { body = response } });

            }
            catch (UserAlreadyExistException e)
            {
                return StatusCode(409, new { StatusCode = 409, error = new { message = e.Message } });
            }
            catch (Exception e)
            {
                return StatusCode(500, new { StatusCode = 500, error = new {message = e.Message }});
            }
        }

    }
}
