using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;

namespace ChatBE.Data
{
    public class User : IdentityUser
    {
        public Guid Id { get; set; } = Guid.NewGuid();
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public bool IsOnline { get; set; } = false;
        public string ConnectionId { get; set; } = string.Empty;
        public virtual IList<ChatMessage> Messages { get; set; }
        public virtual IList<Participants> Participants{ get; set; }

    }
}
