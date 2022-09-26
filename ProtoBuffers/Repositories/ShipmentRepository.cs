using DummyDB.Models;
using Microsoft.EntityFrameworkCore;
using ProtoBuffers.Repositories.IRepositories;

namespace ProtoBuffers.Repositories
{
    public class ShipmentRepository : GenericRepository<Shipment>, IShipmentRepository
    {
        public ShipmentRepository(DbContextClass dbContextClass) : base(dbContextClass) 
        { 

        }
        public async Task<Shipment> GetShipmentByIdAsync(int id, CancellationToken cancellationToken)
        {
            var ship = await _dbSet.SingleOrDefaultAsync(x => x.Id == id, cancellationToken);
            return ship!;
        }


        public async Task DeleteShipmentByIdAsync(int id, CancellationToken cancellationToken)
        {
            var val = await _dbSet.FindAsync(id); 
            _dbSet.Remove(val!);
            await _dbContextClass.SaveChangesAsync();
        }

        public async Task AddShipmentAsync(Shipment shipment, CancellationToken cancellationToken)
        {
             await _dbSet.AddAsync(shipment, cancellationToken);
            await _dbContextClass.SaveChangesAsync();
            
        }
    } 
    
}
