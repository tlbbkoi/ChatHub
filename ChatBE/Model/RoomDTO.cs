using System.ComponentModel.DataAnnotations;

namespace ChatBE.Model
{
    public class RoomDTO
    {
        public Guid Id { get; set; }
        [Required]
        public string NameRoom { get; set; }
        public virtual IList<ChatMessageDTO> ChatMessageDTOs { get; set; }
    }
}
