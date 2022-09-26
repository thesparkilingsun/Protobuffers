using ProtoBuffers.Repositories;

namespace DummyDB.Models
{
    public class OrderSourceDestinaton : EntityClass
    {
        
        public int SourceId { get; set; } = default;
        public string SourceName { get; set; } = default!;
        
        public int DestinationId { get; set; } = default;
        public string DestinationName { get; set; } = default!;


        public OrderSourceDestinaton()
        {
            
        }
    }
}
