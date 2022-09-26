using DummyDB.Models;

namespace ProtoBuffers.Repositories.IRepositories
{
    public interface IOrderDataRepository
    {
        public Task<DateOnly> GetDateOfOrderAsync(int id, CancellationToken cancellationToken);
        public Task<TimeOnly> GetTimeOfOrderAsync(int id, CancellationToken cancellationToken);
        public Task<OrderData[]> GetAllOrderDataAsync(CancellationToken cancellationToken);
        public Task<OrderData> GetOrderDataAsyncById(int id, CancellationToken cancellationToken);
        public Task AddOrderDataAsync(OrderData orderData,CancellationToken cancellationToken);
        public Task EditOrderDataAsync(OrderData ord, CancellationToken cancellationToken);
    }
}
