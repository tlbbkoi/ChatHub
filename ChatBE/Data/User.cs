using Microsoft.AspNetCore.Identity;

namespace ChatBE.Data
{
    public class User : IdentityUser
    {
        public Guid Id { get; set; }
        public string UserName { get; set; }
        public string Email { get; set; }
        public string PassWord { get; set; }
        public bool IsOnline { get; set; }
        public virtual IList<ChatMessage> Messages { get; set; }
        public virtual IList<Participants> Participants{ get; set; }

    }
}
