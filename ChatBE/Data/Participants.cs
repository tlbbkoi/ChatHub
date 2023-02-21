namespace ChatBE.Data
{
    public class Participants
    {
        public Guid Id { get; set; } = new Guid();
        public Guid UserId { get; set; }
        public User User { get; set; }
        public Guid RoomId { get; set; }
        public Room Room { get; set; }

    }
}
