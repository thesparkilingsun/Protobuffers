using DummyDB.Models;
using Microsoft.EntityFrameworkCore;

namespace ProtoBuffers.Repositories.IRepositories
{
    public interface IRepository<T> where T : class, IEntityClass

    {
        // Read
        public Task<T> GetById(int id, CancellationToken cancellationToken);

        public Task<T[]> GetAll(CancellationToken cancellationToken);


        // Create
        public Task Add(T entity, CancellationToken cancellationToken);

        // Delete
        public Task Delete(T entity, CancellationToken cancellationToken);
        

        // Edit
        public Task Update(T entity, CancellationToken cancellationToken);
    }
}
