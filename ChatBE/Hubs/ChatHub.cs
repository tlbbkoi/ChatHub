using ChatBE.Services;
using Microsoft.AspNetCore.SignalR;

namespace ChatBE.Hubs
{
    public class ChatHub : Hub
    {
        private readonly IChatService _iChatService;
       public ChatHub( IChatService chatService)
        {
            _iChatService = chatService;
        }
        public async Task GetUserToChat()
        {
            var user = _iChatService.GetUserToChat();
            await Clients.All.SendAsync("GetUser", user);
        }

        public override Task OnConnectedAsync()
        {
            return base.OnConnectedAsync();
        }

        public override Task OnDisconnectedAsync(Exception? exception)
        {
            return base.OnDisconnectedAsync(exception);
        }
    }
}
