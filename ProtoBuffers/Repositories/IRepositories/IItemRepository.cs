


using DummyDB.Models;

namespace ProtoBuffers.Repositories.IRepositories
{
    public interface IItemRepository 
    {
        public Task<Items[]> GetItemsAsync(CancellationToken cancellationToken);
        public Task<Items> GetItemById(int id, CancellationToken cancellationToken);
        public Task<Component> GetShippingDetails(int id, CancellationToken cancellationToken);
        public Task AddItem(Items item, CancellationToken cancellationToken);

    }
}
