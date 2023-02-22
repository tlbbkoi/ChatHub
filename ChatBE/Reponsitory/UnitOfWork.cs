using ChatBE.Data;
using Microsoft.EntityFrameworkCore;
using static ChatBE.Reponsitory.GenericRespository;

namespace ChatBE.Reponsitory
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly DatabaseContext _databaseContext;

        private IGenericRespository<ChatMessage> _chatMessage;
        private IGenericRespository<Participants> _participants;
        private IGenericRespository<Room> _room;
        private IGenericRespository<User> _user;

        public UnitOfWork(DatabaseContext databaseContext)
        {
            _databaseContext = databaseContext;
        }
        public IGenericRespository<ChatMessage> Message => _chatMessage ??= new GenericRepository<ChatMessage>(_databaseContext);

        public IGenericRespository<Participants> Participants => _participants ??= new GenericRepository<Participants>(_databaseContext);

        public IGenericRespository<Room> Room => _room ??= new GenericRepository<Room>(_databaseContext);

        public IGenericRespository<User> User => _user ??= new GenericRepository<User>(_databaseContext);

        public void Dispose()
        {
            _databaseContext.Dispose();
            GC.SuppressFinalize(this);
        }

        public async Task Save()
        {
            await _databaseContext.SaveChangesAsync();
        }
    }
}
