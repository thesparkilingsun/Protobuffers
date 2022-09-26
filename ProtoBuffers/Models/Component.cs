using ProtoBuffers;
using ProtoBuffers.DTO;
using ProtoBuffers.Repositories;

namespace DummyDB.Models
{
    public class Component : EntityClass , IConvertableToDTO
    {

        public string Code { get; set; } = default!;
        public bool Fetch { get; set; } = default!;
        public string Path { get; set; } = default!;

        public Component()
        {
        }

        public ISerializableDTO ConvertToDTO()
        {
            return new ProtoBuffDTO
            {
                Code = Code,
                Fetch = Fetch,
                Path = Path
            };
        }
    }

}
