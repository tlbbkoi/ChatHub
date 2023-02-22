using ChatBE.Data;
using ChatBE.Model;
using ChatBE.Reponsitory;
using Microsoft.AspNetCore.Identity;

namespace ChatBE.Services
{
    public interface IChatService
    {
        Task<List<UserDTO>> GetUserToChat();
    }
    public class ChatService : IChatService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly HttpContext _httpContext;
        public ChatService(IUnitOfWork unitOfWork, UserManager<User> userManager)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<List<UserDTO>> GetUserToChat()
        {
           // var userId = _httpContext.User.FindFirst("id");
            var query = await _unitOfWork.User.GetAll();
            var result = query.Select(x => new UserDTO
            {
                Id = x.Id,
                FirstName = x.FirstName,
                LastName = x.LastName,
                IsOnline = x.IsOnline
            }).ToList();
            return result;
        }
    }
}
