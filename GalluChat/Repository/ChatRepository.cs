using GalluChat.Data;
using GalluChat.Models;
using GalluChat.Repository.IRepository;

namespace GalluChat.Repository
{
    public class ChatRepository: Repository<Chat>,IChatRepository
    {
        private readonly ApplicationDbContext _context;
        public ChatRepository(ApplicationDbContext context) : base(context)
        {
            _context = context;
        }

        public void Update(Chat chat)
        {
            _context.Chats.Update(chat);
        }
    }
}
