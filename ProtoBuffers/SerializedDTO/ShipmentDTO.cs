using DummyDB.Models;
using ProtoBuf;
using ProtoBuffers.DTO;

namespace ProtoBuffers.SerializedDTO
{
    [ProtoContract]
    public class ShipmentDTO : ISerializableDTO
    {
        [ProtoMember(1)]
        public int ID { get; set; }
        [ProtoMember(2)]
        public int ShipToId { get; set; }
        [ProtoMember(3)]
        public string Name { get; set; } = default!;
        [ProtoMember(4)]
        public string CompanyName { get; set; } = default!;
        [ProtoMember(5)]
        public string Address { get; set; } = default!;
        [ProtoMember(6)]
        public string Town { get; set; } = default!;
        [ProtoMember(7)]
        public string PostalCode { get; set; } = default!;
        [ProtoMember(8)]
        public string IsoCountry { get; set; } = default!;

        //Carrier
        [ProtoMember(9)]
        public int CarrierId { get; set; }
        [ProtoMember(10)]
        public string Code { get; set; } = default!;
        [ProtoMember(11)]
        public string Carrier { get; set; } = default!;
        [ProtoMember(12)]
        public int ItemsId { get; set; } = default!;
        [ProtoMember(13)]
        public ICollection<Items> Items { get; set; } = default!;
    }
}
