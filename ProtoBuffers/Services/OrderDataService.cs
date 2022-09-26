using DummyDB.Models;
using ProtoBuffers.Repositories;
using ProtoBuffers.Repositories.IRepositories;

namespace ProtoBuffers.Services
{
    public class OrderDataService
    {

        public readonly IOrderDataRepository _orderDataRepository;
        public OrderDataService(IOrderDataRepository orderDataRepository)
        {
            _orderDataRepository = orderDataRepository ?? throw new ArgumentNullException(nameof(orderDataRepository));
        }

        public async Task<DateOnly> GetOrderDateAsync(int id, CancellationToken cancellationToken)
        {
            var val = await _orderDataRepository.GetDateOfOrderAsync(id, cancellationToken);
            return val;
        }

        public async Task<OrderData[]> GetAllODAsync(CancellationToken cancellationToken)
        {
            var val = await _orderDataRepository.GetAllOrderDataAsync(cancellationToken);
            return val;
        }

        public async Task<TimeOnly> GetOrderTimeAsync(int id, CancellationToken cancellationToken)
        {
            var val = await _orderDataRepository.GetTimeOfOrderAsync(id, cancellationToken);
            return val;
        }


        public async Task<OrderData> GetOrderDataByIdAsync(int id, CancellationToken cancellationToken)
        {
            var val = await _orderDataRepository.GetOrderDataAsyncById(id, cancellationToken);
            return val;
        }

        public async Task AddAsyncOrderData(OrderData ord, CancellationToken cancellationToken)
        {
            await _orderDataRepository.AddOrderDataAsync(ord, cancellationToken);
            return;
        }

        public async Task EditOrderDataAsy(OrderData ord, CancellationToken cancellationToken)
        {
            await _orderDataRepository.EditOrderDataAsync(ord, cancellationToken);
            return;
        }
    }
}
