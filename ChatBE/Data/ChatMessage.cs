namespace ChatBE.Data
{
    public class ChatMessage
    {
        public Guid Id { get; set; } = new Guid();
        public string Message { get; set; }
        public DateTime CreateAt { get; set; }

        public Guid UserId { get; set; }
        public User User { get; set; }
        public Guid RoomId { get; set; }        
        public Room Room { get; set; }

    }
}
