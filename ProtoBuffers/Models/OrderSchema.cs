using ProtoBuffers.Repositories;

namespace DummyDB.Models
{
    public class OrderSchema : EntityClass
    {
       
        
        public int OrderSourceDestinatonId { get; set; } = default!;
        public OrderSourceDestinaton OrderSourceDestinaton { get; set; }= default!;

        public int OrderDataId { get; set; } = default!;
        public OrderData OrderData { get; set; } = default!;

        public OrderSchema() 
        {
           
           
        }


       
    }
}
