using DummyDB.Models;
using ProtoBuffers.Repositories.IRepositories;

namespace ProtoBuffers.Services
{
    public class ItemsService
    {
        private readonly IItemRepository _itemRepo;
        public ItemsService(IItemRepository itemRepository)
        {
            _itemRepo = itemRepository ?? throw new ArgumentNullException(nameof(itemRepository));
        }

        public async Task<Items> GetItemByIdAsync(int id, CancellationToken cancellationToken)
        {
            var res = await _itemRepo.GetItemById(id, cancellationToken);
            return res;
        }

        public async Task<Items[]> GetAllItems(CancellationToken cancellationToken)
        {
            var res = await _itemRepo.GetItemsAsync(cancellationToken);
            return res;
        }

        public async Task<Component> GetShippingDetails(int id,CancellationToken cancellationToken)
        {
            var val = await _itemRepo.GetShippingDetails(id, cancellationToken);
            return val;
        }

        public async Task AddItem(Items item, CancellationToken cancellationToken)
        {
            await _itemRepo.AddItem(item, cancellationToken);   
            
        }

    }
}
