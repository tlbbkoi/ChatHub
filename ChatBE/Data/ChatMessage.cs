namespace ChatBE.Data
{
    public class ChatMessage
    {
        public Guid Id { get; set; }
        public string Message { get; set; }
        public DateTime CreateAt { get; set; }

        public Guid IdUser { get; set; }
        public User User { get; set; }
        public Guid IdRoom { get; set; }
        public Room Room { get; set; }

    }
}
