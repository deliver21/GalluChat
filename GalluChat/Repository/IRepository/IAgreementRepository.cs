using GalluChat.Models;

namespace GalluChat.Repository.IRepository
{
    public interface IAgreementRepository:IRepository<Agreement>
    {
        void Update(Agreement agreement);
    }
}
