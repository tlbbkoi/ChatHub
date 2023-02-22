using ChatBE.Data;

namespace ChatBE.Reponsitory
{
    public interface IUnitOfWork : IDisposable
    {
        IGenericRespository<ChatMessage> Message { get;}
        IGenericRespository<Participants> Participants { get;}
        IGenericRespository<Room> Room { get;}
        IGenericRespository<User> User { get;}
        Task Save();
    }
}
