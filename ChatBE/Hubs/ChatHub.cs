using ChatBE.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.SignalR;

namespace ChatBE.Hubs
{
    [Authorize]
    public class ChatHub : Hub
    {
        //private readonly IUnitOfWork _unitOfWork;
        //private readonly IHttpContextAccessor _httpContextAccessor;
        //private readonly IGenericRespository<User> _userRes;
        //private readonly UserManager<User> _userManager;
        private readonly IChatService _chatService;


        public ChatHub(IChatService chatService)
            //IUnitOfWork unitOfWork 
            //, IHttpContextAccessor httpContextAccessor
            //, UserManager<User> userManager,
            //IGenericRespository<User> userRes) 
        {
            //_unitOfWork = unitOfWork;
            //_httpContextAccessor = httpContextAccessor;
            //_userManager = userManager;
            //_userRes = userRes;
            _chatService= chatService;
        }
        public override async Task OnConnectedAsync()
        {
            //var userId = Context.User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
            //string connectionId = Context.ConnectionId;
            //var identity = (ClaimsIdentity)_httpContextAccessor.HttpContext.User.Identity;

            ////Gets list of claims.
            //IEnumerable<Claim> claims = identity.Claims;

            //var usernameClaim = claims
            //    .Where(x => x.Type == ClaimTypes.Name)
            //.FirstOrDefault();

            //var user = await _userManager.FindByNameAsync(usernameClaim.Value);

            //// Lưu trữ ConnectionId của người dùng vào cơ sở dữ liệu
            //var queryUser =  await _userRes.FindOneAsync(x => x.Email == user.Email);
            //queryUser.ConnectionId = connectionId;
            //queryUser.IsOnline= true;

            //_userRes.Update(queryUser); 
            //await _unitOfWork.SaveChangesAsync();
            //await Clients.All.SendAsync("UserConnected", queryUser);
            await _chatService.AddUserLogin(Context.ConnectionId);
            await base.OnConnectedAsync();
        }

        public override async Task OnDisconnectedAsync(Exception? exception)
        {
            //string connectionId = "";
            //var identity = (ClaimsIdentity)_httpContextAccessor.HttpContext.User.Identity;

            ////Gets list of claims.
            //IEnumerable<Claim> claims = identity.Claims;

            //var usernameClaim = claims
            //    .Where(x => x.Type == ClaimTypes.Name)
            //.FirstOrDefault();

            //var user = await _userManager.FindByNameAsync(usernameClaim.Value);

            //// Xoá ConnectionId của người dùng vào cơ sở dữ liệu
            //var queryUser = await _userRes.FindOneAsync(x => x.Email == user.Email);
            //queryUser.ConnectionId = connectionId;
            //queryUser.IsOnline = false;

            //_userRes.Update(queryUser);
            //await _unitOfWork.SaveChangesAsync();
            //await Clients.All.SendAsync("UserDisconnected", queryUser);
            await _chatService.RemoveUserLogout();
            await base.OnDisconnectedAsync(exception);
        }

        public async Task GetUserOnline()
        {
            // Xử lý lấy danh sách người dùng online 
            var result = await _chatService.GetUserToChat();
            await Clients.All.SendAsync("OnlineUser", result);
        }

        public async Task SendMessage(string user, string message)
        {
            var userName = Context.User.Identity.Name;
            await Clients.All.SendAsync("ReceiveMessage", user, message);
        }
        public async Task OnExit()
        {
            var result = await _chatService.GetUserToChat();
            await Clients.All.SendAsync("OfflineUser", result);
        }

    }
}
