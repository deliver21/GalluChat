using GalluChat.Data;
using GalluChat.Models;
using GalluChat.Repository.IRepository;

namespace GalluChat.Repository
{
    public class MessageRepository : Repository<Message>, IMessageRepository
    {
        private readonly ApplicationDbContext _context;
        public MessageRepository(ApplicationDbContext context) : base(context)
        {
            _context=context;
        }

        public void Update(Message message)
        {
            _context.Messages.Update(message);
        }
    }
}
