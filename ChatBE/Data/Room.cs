namespace ChatBE.Data
{
    public class Room
    {
        public Guid Id { get; set; }    
        public string NameRoom { get; set; }
        public virtual IList<ChatMessage> ChatMessages { get; set; }
        public virtual IList<Participants> Participants { get; set; }
    }
}
