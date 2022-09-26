namespace ProtoBuffers.DTO
{
    public interface IConvertableToDTO
    {
        ISerializableDTO ConvertToDTO();
    }
}