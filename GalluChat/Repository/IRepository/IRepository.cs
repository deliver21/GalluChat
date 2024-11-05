namespace GalluChat.Repository.IRepository
{
    public interface IRepository<T> where T : class
    {
        void Add(T entity);
        void Delete(T entity);
        T Get(System.Linq.Expressions.Expression<Func<T, bool>> filter, string? includeproperties = null, bool track = false);
        IEnumerable<T> GetAll(System.Linq.Expressions.Expression<Func<T, bool>>? filter = null, string? includeproperties = null);
        void RemoveRange(IEnumerable<T> entity);
    }
}
