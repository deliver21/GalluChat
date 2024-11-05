using GalluChat.Models;

namespace GalluChat.Repository.IRepository
{
    public interface IMutualAgreementRepository:IRepository<MutualAgreement>
    {
        void Update(MutualAgreement newAgreement);
    }
}
