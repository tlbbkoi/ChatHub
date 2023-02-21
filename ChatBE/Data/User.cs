using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;

namespace ChatBE.Data
{
    public class User 
    {
        public Guid Id { get; set; } 
        public string UserName { get; set; }
        public string Email { get; set; }
        public string PassWord { get; set; }
        public bool IsOnline { get; set; } = false;
        public virtual IList<ChatMessage> Messages { get; set; }
        public virtual IList<Participants> Participants{ get; set; }

    }
}
