using DummyDB.Models;
using Microsoft.EntityFrameworkCore;
using ProtoBuffers.Repositories.IRepositories;

namespace ProtoBuffers.Repositories
{
    public class OrderDataRepository : GenericRepository<OrderData>, IOrderDataRepository
    {
        public OrderDataRepository(DbContextClass dbContextClass) : base(dbContextClass) { }

        public async Task AddOrderDataAsync(OrderData orderData, CancellationToken cancellationToken)
        {
            await _dbSet.AddAsync(orderData, cancellationToken);
            await _dbContextClass.SaveChangesAsync();
            return;
        }

        public async Task EditOrderDataAsync(OrderData ord, CancellationToken cancellationToken)
        {
            OrderData order =  await _dbSet.FirstAsync(x=> x.Id == ord.Id);
            order.OrderNumber = ord.OrderNumber;
            order.Shipment = ord.Shipment;
            order.Time = ord.Time;
            order.Shipment = ord.Shipment;
            order.Date = ord.Date;
            order.ShipmentId = ord.ShipmentId;
            await _dbContextClass.SaveChangesAsync();
            return;
        }

        public async Task<OrderData[]> GetAllOrderDataAsync(CancellationToken cancellationToken)
        {
            var ordt = await _dbSet.ToArrayAsync(cancellationToken);
            return ordt;
        }

        public async Task<DateOnly> GetDateOfOrderAsync(int id, CancellationToken cancellationToken)
        {
            var dt = await _dbSet.FirstOrDefaultAsync(x => x.Id == id,cancellationToken);
            var dates = dt!.Date;
            return DateOnly.Parse(dates.Date.ToShortDateString());
        }

        public async Task<OrderData> GetOrderDataAsyncById(int id, CancellationToken cancellationToken)
        {
            var dt = await _dbSet.FirstOrDefaultAsync(x => x.Id == id,cancellationToken);
            return dt!;
        }

        public async Task<TimeOnly> GetTimeOfOrderAsync(int id, CancellationToken cancellationToken)
        {
            var dt = await _dbSet.FirstOrDefaultAsync(x => x.Id == id, cancellationToken);
            var dates = dt!.Time.ToShortTimeString();
            return TimeOnly.Parse(dates);
        }

       
    }
}
