namespace ChatBE.Model
{
    public class ParticipantDTO
    {
        public Guid Id { get; set; }
        public UserDTO User { get; set; }
        public RoomDTO Room { get; set; }   
    }
}
