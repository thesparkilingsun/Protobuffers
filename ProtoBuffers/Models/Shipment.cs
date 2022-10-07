using ProtoBuffers;
using ProtoBuffers.DTO;
using ProtoBuffers.Repositories;
using ProtoBuffers.SerializedDTO;

namespace DummyDB.Models
{
    public class Shipment : EntityClass, IConvertableToDTO
    {
        // Shipto
        public int ShipToId { get; set; }
        public string Name { get; set; } = default!;
        public string CompanyName { get; set; } = default!;
        public string Address { get; set; } = default!;
        public string Town { get; set; } = default!;
        public string PostalCode { get; set; } = default!;
        public string IsoCountry { get; set; } = default!;

        //Carrier
        public int CarrierId { get; set; }
        public string Code { get; set; } = default!;
        public string Carrier { get; set; } = default!;

        public int ItemsId { get; set; } = default!;
        public ICollection<Items> Items { get; set; } = default!;

        public Shipment()
        {
        }

        public ISerializableDTO ConvertToDTO()
        {
            // return shipment DTO
            return new ShipmentDTO()
            {
                ID = Id,
                ShipToId = ShipToId,
                Name = Name,
                CompanyName = CompanyName,
                Address = Address,
                Town = Town,
                PostalCode = PostalCode,
                IsoCountry = IsoCountry,
                CarrierId = CarrierId,
                ItemsId = ItemsId,
                Code = Code,
                Carrier = Carrier,
                Items = Items,

            };
        }
    }
}
