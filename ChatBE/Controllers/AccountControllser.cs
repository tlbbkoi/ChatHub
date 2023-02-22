using ChatBE.Model;
using ChatBE.Properties;
using ChatBE.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ChatBE.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    
    public class AccountControllser : ControllerBase
    {
        private readonly IAumanager _aumanager;

        public AccountControllser(IAumanager aumanager)
        {
            _aumanager = aumanager;
        }

        [HttpPost]
        [Route("register")]


        public async Task<IActionResult> Register([FromBody] UserDTO userDTO)
        {
            var result = await _aumanager.Register(userDTO);
            return Ok(new Response(Resource.REGISTER_SUCCESS));

        }
        
        [HttpPost]
        [Route("login")]
        public  async Task<IActionResult> Login([FromBody] LoginUserDTO loginUserDTO)
        {
            var result = await _aumanager.Login(loginUserDTO);
            return Ok(new Response(Resource.LOGIN_SUC, null, new { Token = result }));
        }
    }
}
