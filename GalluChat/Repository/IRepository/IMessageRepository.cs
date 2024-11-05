using GalluChat.Models;

namespace GalluChat.Repository.IRepository
{
    public interface IMessageRepository:IRepository<Message>
    {
        void Update(Message message);
    }
}
