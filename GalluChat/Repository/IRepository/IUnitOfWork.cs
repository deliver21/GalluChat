namespace GalluChat.Repository.IRepository
{
    public interface IUnitOfWork
    {
        public IApplicationUserRepository ApplicationUser { get; }
        public IAgreementRepository Agreement { get; }
        public IChatRepository Chat { get; }
        public IMessageRepository Message { get; }
        public IMutualAgreementRepository MutualAgreement { get; }
        void Save();
    }
}
