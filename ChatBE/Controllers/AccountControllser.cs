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
        private readonly IChatService _chatService;

        public AccountControllser(IAumanager aumanager, IChatService chatService)
        {
            _aumanager = aumanager;
            _chatService = chatService;
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

        [HttpGet]
        public async Task<IActionResult> Test()
        {
            var result = await _chatService.GetUserToChat();
            return Ok(result);
        }
    }
}
