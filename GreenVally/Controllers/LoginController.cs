using GreenValley.Services.Contracters;
using GreenValley.Utility;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace GreenValley.Controllers
{
    [Route("api/[controller]")]
    [ApiController]

    public class LoginController : ControllerBase
    {
        private readonly IUserLogin _userLogin;
        public LoginController(IUserLogin userLogin)
        {
            _userLogin = userLogin;
        }
        [HttpPost]

        public IActionResult AddNewUseDatas(LoginResponse loginResponse)
        {
            ResponseApi<LoginResponse> response = new ResponseApi<LoginResponse>();
            try
            {
                LoginResponse newuser = _userLogin.AddNewOne(loginResponse);
                response = new ResponseApi<LoginResponse> { Msg = "Addd New One", Status = true, Value = newuser };
                return StatusCode(StatusCodes.Status200OK, response);
            }
            catch (Exception ex)
            {
                response = new ResponseApi<LoginResponse> { Msg = ex.Message };
                return StatusCode(StatusCodes.Status500InternalServerError, response);
            }
        }
        [HttpPost("verify")]

        public ActionResult<LoginResponse> CheckUser([FromBody] LoginResponse loginResponds)
        {
            try

            {
                var responses = this._userLogin.ValidUser(loginResponds);
                if (string.IsNullOrWhiteSpace(loginResponds.UserName) || string.IsNullOrWhiteSpace(loginResponds.UserPassword))
                {
                    return BadRequest(responses);
                }

                if (responses == "Not Found" || responses == "Password is wrong")
                {
                    return BadRequest(responses);
                }


                return Ok(responses);
            }
            catch (Exception ex)
            {
                var responce = new ResponseApi<LoginResponse>(); responce.Msg = ex.Message;
                return BadRequest(responce);

            }
        }
    }
}

