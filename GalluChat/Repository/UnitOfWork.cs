using GalluChat.Data;
using GalluChat.Repository.IRepository;

namespace GalluChat.Repository
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly ApplicationDbContext _db;
        public IApplicationUserRepository ApplicationUser { get; private set; }

        public IAgreementRepository Agreement { get; private set; }

        public IChatRepository Chat { get; private set; }

        public IMessageRepository Message { get; private set; }

        public IMutualAgreementRepository MutualAgreement { get; private set; }

        public UnitOfWork(ApplicationDbContext db) {
            _db = db;
            ApplicationUser=new ApplicationUserRepository(_db);
            Agreement=new AgreementRepository(_db);
            Chat=new ChatRepository(_db);
            Message=new MessageRepository(_db);
            MutualAgreement = new MutualAgreementRepository(_db);
        } 
        public void Save()
        {
            _db.SaveChanges();
        }
    }
}
