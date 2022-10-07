using ProtoBuf;
using ProtoBuffers;
using ProtoBuffers.DTO;
using ProtoBuffers.Repositories;
using ProtoBuffers.SerializedDTO;
using System.ComponentModel;
using System.Runtime.Serialization;

namespace DummyDB.Models
{
    public class Items : EntityClass, IConvertableToDTO

    {
        public string Sku { get; set; } = default!;
        public int ComponentId { get; set; } = default!;
        public Component Component { get; set; } = default!;
        
        public Items()
        {
            
           
        }

        public ISerializableDTO ConvertToDTO()
        {
            return new ItemDTO()
            {
                Sku = Sku,
                Component = Component,
                ComponentId = ComponentId,
                Id = Id,
            };
        }
    }
}
