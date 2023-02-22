using ChatBE.Configurations.entities;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace ChatBE.Data
{
    public class DatabaseContext : IdentityDbContext<User>
    {
        public DatabaseContext(DbContextOptions<DatabaseContext> options) : base(options) { }

        public DbSet<ChatMessage> Messages { get; set; }
        public DbSet<Participants> Participants { get; set; }
        public DbSet<Room> Rooms { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            builder.ApplyConfiguration(new ChatMessageConfiguration());
            builder.ApplyConfiguration(new ParticipantsConfiguration());
            builder.ApplyConfiguration(new RoomConfiguration());
            builder.ApplyConfiguration(new RoleConfiguration());
            //builder.ApplyConfiguration(new UserConfiguration());

        }
    }
}
