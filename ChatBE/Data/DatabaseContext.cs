using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace ChatBE.Data
{
    public class DatabaseContext : IdentityDbContext<User>
    {
        public DatabaseContext(DbContextOptions options) : base(options) { }

        public DbSet<ChatMessage> Messages { get; set; }
        public DbSet<Participants> Participants { get; set; }
        public DbSet<Room> Rooms { get; set; }
    }
}
