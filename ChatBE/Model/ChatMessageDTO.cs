namespace ChatBE.Model
{
    public class ChatMessageDTO
    {
        public Guid Id { get; set; }
        public string Message { get; set; }
        public DateTime CreateAt { get; set; }
        public UserDTO User { get; set; }

    }
}
