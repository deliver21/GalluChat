using GalluChat.Data;
using GalluChat.Models;
using GalluChat.Repository.IRepository;

namespace GalluChat.Repository
{
    public class MutualAgreementRepository : Repository<MutualAgreement>, IMutualAgreementRepository
    {
        private readonly ApplicationDbContext _context;
        public MutualAgreementRepository(ApplicationDbContext context) : base(context)
        {
            _context = context;
        }

        public void Update(MutualAgreement mutualAgreement)
        {
            _context.MutualAgreements.Update(mutualAgreement);
        }
    }
}
