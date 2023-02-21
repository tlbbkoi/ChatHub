using ChatBE.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ChatBE.Configurations.entities
{
    public class ParticipantsConfiguration : IEntityTypeConfiguration<Participants>
    {
        public void Configure(EntityTypeBuilder<Participants> builder)
        {
            builder.HasKey(x => x.Id);
            builder.HasOne(x => x.User).WithMany(x => x.Participants);
            builder.HasOne(x => x.Room).WithMany(x => x.Participants);
        }
    }
}
