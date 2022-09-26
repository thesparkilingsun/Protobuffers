using ProtoBuf;

namespace ProtoBuffers.DTO
{
    public interface ISerializableDTO
    {
        public byte[] Serialize()
        {
            using var memoryStream = new MemoryStream();
            Serializer.Serialize(memoryStream, this);
            var byteArray = memoryStream.ToArray();
            return byteArray;
        }
    }
}
