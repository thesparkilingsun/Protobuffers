using DummyDB.Models;
using ProtoBuffers.Repositories.IRepositories;

namespace ProtoBuffers.Services
{
    public class ShipmentServices 
    {
        private readonly IShipmentRepository _shipmentRepository;
        private readonly DbContextClass _dbContextClass;
        
        public ShipmentServices(IShipmentRepository shipmentRepository, DbContextClass dbContextClass)
        {
            _shipmentRepository = shipmentRepository;
            _dbContextClass = dbContextClass;
        }
        
        public async Task<Shipment> GetShipmentByIDAsync(int id,CancellationToken cancellationToken)
        {
            var result = await _shipmentRepository.GetShipmentByIdAsync(id, cancellationToken);
            return result;
        }

        public async Task<Shipment[]> GetAllShipments(CancellationToken cancellationToken)
        {
            var result = await _shipmentRepository.GetAll(cancellationToken);
            return result;
        }

        public async Task AddShipmentAsync(Shipment ship, CancellationToken cancellationToken)
        {
            await _shipmentRepository.AddShipmentAsync(ship, cancellationToken);
            return;
        }

        public async Task<ShipLoad> EditShipment(int id, Shipment _shipload, CancellationToken cancellationToken)
        {
            var ship = ShipLoad.FromShipment(_shipload);
             await _dbContextClass.SaveChangesAsync();
             return ship;

        }

        public async Task DeleteShipmentByID(int id,CancellationToken cancellationToken)
        {
            await _shipmentRepository.DeleteShipmentByIdAsync(id, cancellationToken);
            return;
        }


    }
}
