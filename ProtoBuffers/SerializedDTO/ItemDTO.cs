using DummyDB.Models;
using ProtoBuf;
using ProtoBuffers.DTO;

namespace ProtoBuffers.SerializedDTO
{
    [ProtoContract]
    public class ItemDTO : ISerializableDTO
    {
        [ProtoMember(1)]
        public int Id { get; set; }
        [ProtoMember(2)]
        public string Sku { get; set; } = default!;
        [ProtoMember(3)]
        public int ComponentId { get; set; } = default!;
        [ProtoMember(4)]
        public Component Component { get; set; } = default!;
    }
}
