using GalluChat.Models;

namespace GalluChat.Repository.IRepository
{
    public interface IChatRepository:IRepository<Chat>
    {
        void Update(Chat chat);
    }
}
