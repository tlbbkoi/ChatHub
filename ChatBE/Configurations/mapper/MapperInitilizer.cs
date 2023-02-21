using AutoMapper;
using ChatBE.Data;
using ChatBE.Model;

namespace ChatBE.Configurations.mapper
{
    public class MapperInitilizer : Profile
    {
        public MapperInitilizer()
        {
            CreateMap<ChatMessage, ChatMessageDTO>().ReverseMap();
            CreateMap<Participants, ParticipantDTO>().ReverseMap();
            CreateMap<Room, RoomDTO>().ReverseMap();
            CreateMap<User, UserDTO>().ReverseMap();
        }
    }
}
