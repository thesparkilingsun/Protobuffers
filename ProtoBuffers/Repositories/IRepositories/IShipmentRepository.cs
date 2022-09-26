using DummyDB.Models;

namespace ProtoBuffers.Repositories.IRepositories
{
    public interface IShipmentRepository : IRepository<Shipment>
    {
        Task<Shipment> GetShipmentByIdAsync(int id,CancellationToken cancellationToken);
        Task AddShipmentAsync(Shipment shipment,CancellationToken cancellationToken);
        Task DeleteShipmentByIdAsync(int id,CancellationToken cancellationToken);                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                   
    }
}
