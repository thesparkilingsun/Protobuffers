using DummyDB.Models;
using ProtoBuffers.Repositories;
using ProtoBuffers.Repositories.IRepositories;

namespace ProtoBuffers.Services
{
    public class DeliverProtoBuffService
    {
        private readonly IComponentRepository _comprepo;
        private readonly IOrderDataRepository _orderdatarepo;

        public DeliverProtoBuffService(IComponentRepository componentRepository,IOrderDataRepository orderDataRepository)
        {
            _comprepo = componentRepository ?? throw new ArgumentNullException(nameof(componentRepository));
            _orderdatarepo = orderDataRepository ?? throw new ArgumentNullException(nameof(orderDataRepository));
        }
        

        public async Task<Component> GetSerializedComponentAsync (int id,CancellationToken cancellationToken)
        {
            var val = await _comprepo.GetComponent(id,cancellationToken);
            return val;
        }

        public async Task<OrderData> GetSerializedOrderData(int id,CancellationToken cancellationToken)
        {
            var val = await _orderdatarepo.GetOrderDataAsyncById(id,cancellationToken);
            return val;
        }

    }
}
