namespace ChatBE.Model
{
    public class RoomDTO
    {
        public Guid Id { get; set; }
        public string NameRoom { get; set; }
        public virtual IList<ChatMessageDTO> ChatMessageDTOs { get; set; }
    }
}
