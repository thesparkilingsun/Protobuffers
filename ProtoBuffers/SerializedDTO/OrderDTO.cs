using DummyDB.Models;
using ProtoBuf;
using ProtoBuffers.DTO;

namespace ProtoBuffers.SerializedDTO
{
    [ProtoContract]
    public class OrderDTO : ISerializableDTO
    {
        [ProtoMember(1)]
        public int Id { get; set; }
        [ProtoMember(2)]
        public DateTime Date { get; set; }
        [ProtoMember(3)]
        public DateTime Time { get; set; }
        [ProtoMember(4)]
        public string OrderNumber { get; set; } = default!;
        [ProtoMember(5)]
        public int ShipmentId { get; set; }
        [ProtoMember(6)]
        public Shipment Shipment { get; set; } = default!;
    }
}
