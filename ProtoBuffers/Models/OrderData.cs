using ProtoBuffers;
using ProtoBuffers.DTO;
using ProtoBuffers.Repositories;
using ProtoBuffers.SerializedDTO;

namespace DummyDB.Models
{
    public class OrderData : EntityClass, IConvertableToDTO
    {
        public DateTime Date { get; set; } = default!;
        public DateTime Time { get; set; } = default!;
        
        public string OrderNumber { get; set; } = default!;
        
        public int ShipmentId { get; set; }
        public Shipment Shipment { get; set; } = default!;

        
        public OrderData()
        {  
        }

        public ISerializableDTO ConvertToDTO()
        {
            return new OrderDTO()
            {
                Id = Id,
                Date = Date,
                Time = Time,
                OrderNumber = OrderNumber,
                ShipmentId = ShipmentId,
                Shipment = Shipment,
            };
        }
    }
}
