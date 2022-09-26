using DummyDB.Models;
using Microsoft.EntityFrameworkCore;
using ProtoBuffers.Repositories.IRepositories;

namespace ProtoBuffers.Repositories
{
    public class ItemRepository : GenericRepository<Items>, IItemRepository
    {
        public ItemRepository(DbContextClass dbContextClass) : base(dbContextClass)
        {

        }

        public async Task AddItem(Items item, CancellationToken cancellationToken)
        {
             
             await _dbSet.AddAsync(item, cancellationToken);
            await _dbContextClass.SaveChangesAsync(cancellationToken);
            
        }

        public async Task<Items> GetItemById(int id, CancellationToken cancellationToken)
        {
            var result = await _dbSet.FindAsync(id, cancellationToken);
            return result!;
        }

        public async Task<Items[]> GetItemsAsync(CancellationToken cancellationToken)
        {
            var result = await _dbSet.AsQueryable().ToArrayAsync(cancellationToken);
            return result;
        }

        public async Task<Component> GetShippingDetails(int id, CancellationToken cancellationToken)
        {
            var item = await _dbSet.FindAsync(id);
            var shippingDetails = item!.Component;
            return shippingDetails;

        }
    }
}
