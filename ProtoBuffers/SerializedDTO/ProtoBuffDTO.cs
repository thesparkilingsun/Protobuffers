

using DummyDB.Models;
using ProtoBuf;
using ProtoBuffers.DTO;

namespace ProtoBuffers.SerializedDTO
{
    [ProtoContract]
    public class ProtoBuffDTO : ISerializableDTO
    {
        [ProtoMember(1)]
        public int Id { get; set; }
        [ProtoMember(2)]
        public string Code { get; set; } = default!;
        [ProtoMember(3)]
        public bool Fetch { get; set; } = default;
        [ProtoMember(4)]
        public string Path { get; set; } = default!;

    }

}
