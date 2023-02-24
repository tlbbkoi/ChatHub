using ChatBE.Data;
using ChatBE.Reponsitory;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using System.Security.Claims;

namespace ChatBE.Services
{
    public interface IChatService
    {
        public Task AddUserLogin(string connectionId);
        public Task RemoveUserLogout();
        public Task<List<User>> GetUserToChat();
    }
    public class ChatService : IChatService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IHttpContextAccessor _httpContextAccessor;
        private readonly HttpContext _httpContext;
        private readonly UserManager<User> _userManager;

        public ChatService(IUnitOfWork unitOfWork, IHttpContextAccessor httpContextAccessor , UserManager<User> userManager)
        {
            _unitOfWork = unitOfWork;
            _httpContextAccessor = httpContextAccessor;
            _userManager = userManager;
        }

        public async Task AddUserLogin(string connectionId)
        {
            var identity = (ClaimsIdentity)_httpContextAccessor.HttpContext.User.Identity;

            //Gets list of claims.
            IEnumerable<Claim> claims = identity.Claims;

            var usernameClaim = claims
                .Where(x => x.Type == ClaimTypes.Name)
            .FirstOrDefault();

            var user = await _userManager.FindByNameAsync(usernameClaim.Value);

            // Lưu trữ ConnectionId của người dùng vào cơ sở dữ liệu
            user.ConnectionId = connectionId;
            user.IsOnline = true;

            _unitOfWork.User.Update(user);
            await _unitOfWork.Save();
        }

        public async Task <List<User>> GetUserToChat()
        {
             // Xử lý lấy danh sách người dùng online 
            var userOnline = await _unitOfWork.User.GetAll(x => x.IsOnline == true);
            var result = userOnline.Select(x => new User
            {
                Email= x.Email,
                IsOnline= x.IsOnline,
                ConnectionId= x.ConnectionId,
                Id= x.Id,

            }).ToList();
            return result;
        }

        public async Task RemoveUserLogout()
        {
            string connectionId = "";
            var identity = (ClaimsIdentity)_httpContextAccessor.HttpContext.User.Identity;

            //Gets list of claims.
            IEnumerable<Claim> claims = identity.Claims;

            var usernameClaim = claims
                .Where(x => x.Type == ClaimTypes.Name)
            .FirstOrDefault();

            var user = await _userManager.FindByNameAsync(usernameClaim.Value);

            // Xoá ConnectionId của người dùng vào cơ sở dữ liệu
            user.ConnectionId = connectionId;
            user.IsOnline = false;

            _unitOfWork.User.Update(user);
            await _unitOfWork.Save();
        }
        
    }
}
