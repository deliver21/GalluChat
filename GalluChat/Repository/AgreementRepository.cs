using GalluChat.Data;
using GalluChat.Models;
using GalluChat.Repository.IRepository;

namespace GalluChat.Repository
{
    public class AgreementRepository : Repository<Agreement>, IAgreementRepository
    {
        private readonly ApplicationDbContext _context;
        public AgreementRepository(ApplicationDbContext context) : base(context)
        {
            _context = context;
        }

        public void Update(Agreement agreement)
        {
            _context.Agreements.Update(agreement);
        }
    }
}
