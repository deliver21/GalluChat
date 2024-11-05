using GalluChat.Data;
using GalluChat.Repository.IRepository;
using Microsoft.EntityFrameworkCore;

namespace GalluChat.Repository
{
    public class Repository<T> :IRepository<T> where T : class
    {
        private readonly ApplicationDbContext _context;
        internal DbSet<T> dbSet { get; set;}
        public Repository(ApplicationDbContext context)
        {
            _context=context;
            dbSet=_context.Set<T>();
        }
        public void Add(T entity)
        {
            dbSet.Add(entity);
        }
        public void Delete(T entity)
        {
            dbSet.Remove(entity);
        }
        public T Get(System.Linq.Expressions.Expression<Func<T, bool>> filter, string? includeproperties = null, bool track = false)
        {
            IQueryable<T> query;
            if (track)
            {
                query = dbSet;

            }
            else
            {
                query = dbSet.AsNoTracking();
            }
            query = query.Where(filter);
            if (!string.IsNullOrEmpty(includeproperties))
            {
                foreach (var includeProp in includeproperties.Split(new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries))
                {
                    query = query.Include(includeProp);
                }
            }
            return query.FirstOrDefault();

        }

        public IEnumerable<T> GetAll(System.Linq.Expressions.Expression<Func<T, bool>>? filter = null, string? includeproperties = null)
        {
            IQueryable<T> query = dbSet.AsNoTracking();
            if (filter != null)
            {
                query = query.Where(filter);
            }
            if (!string.IsNullOrEmpty(includeproperties))
            {
                foreach (var includeProp in includeproperties.Split(new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries))
                {
                    query = query.Include(includeProp);
                }
            }
            return query.ToList();
        }
        public void RemoveRange(IEnumerable<T> entity)
        {
            dbSet.RemoveRange(entity);
        }

    }
}
