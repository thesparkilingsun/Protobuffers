using Microsoft.EntityFrameworkCore;
using ProtoBuffers.Repositories.IRepositories;
using System.Linq;

namespace ProtoBuffers.Repositories
{

    public abstract class GenericRepository<T> : IRepository<T> where T : class, IEntityClass
    {
        protected DbContextClass _dbContextClass;
        protected DbSet<T> _dbSet;



        public GenericRepository(DbContextClass dbContextClass):base()
        {
            _dbContextClass = dbContextClass ?? throw new ArgumentNullException(nameof(dbContextClass));
            _dbSet = _dbContextClass.Set<T>();
        }

        // Get
        public Task<T[]> GetAll(CancellationToken cancellationToken) =>  _dbSet.ToArrayAsync(cancellationToken);
        public  async Task<T> GetById(int id, CancellationToken cancellationToken)
        {
            var val= await _dbSet.FirstOrDefaultAsync(x=> x.Id == id, cancellationToken);
            return val!;
        }

        // Post
        public async Task Add(T entity, CancellationToken cancellationToken)
        {
            _dbSet.Add(entity);
            await _dbContextClass.SaveChangesAsync(cancellationToken);
             
        }

        // Delete
        public async Task Delete(T entity, CancellationToken cancellationToken)
        {
            _dbSet.Remove(entity);
            await _dbContextClass.SaveChangesAsync(cancellationToken);
        }

        public async Task Update(T entity, CancellationToken cancellationToken)
        {
            _ = _dbSet.Update(entity);
            await _dbContextClass.SaveChangesAsync(cancellationToken);
        }

    }

}
