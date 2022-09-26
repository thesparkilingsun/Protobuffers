using DummyDB.Models;
using System.ComponentModel.DataAnnotations;

namespace ProtoBuffers
{
    public class ShipLoad
    {
        public int Id { get; set; }
        // Shipto
        [Required]
        public int ShipToId { get; set; } = default(int);

        [Required]
        [StringLength(100)]
        public string Name { get; set; } = default!;
        [Required]
        [StringLength(100)]
        public string CompanyName { get; set; } = default!;
        [Required]
        [StringLength(200)]
        public string Address { get; set; } = default!;
        [Required]
        [StringLength(100)]
        public string Town { get; set; } = default!;
        [Required]
        [StringLength(7)]
        public string PostalCode { get; set; } = default!;
        [Required]
        [StringLength(5)]
        public string IsoCountry { get; set; } = default!;

        //Carrier
        [Required]
        public int CarrierId { get; set; } = default(int);

        [Required]
        [StringLength(10)]
        public string Code { get; set; } = default!;
        [Required]
        [StringLength(5)]
        public string Carrier { get; set; } = default!;

        public static ShipLoad FromShipment(Shipment shipment)
        {
            return new ShipLoad
            {
                Id = shipment.Id,
                Name = shipment.Name,
                CompanyName = shipment.CompanyName,
                Address = shipment.Address,
                Town = shipment.Town,
                IsoCountry = shipment.IsoCountry,
                PostalCode = shipment.PostalCode,
                ShipToId = shipment.ShipToId,
                Carrier = shipment.Carrier,
                Code = shipment.Code,
                CarrierId = shipment.CarrierId
            };
        }
    }
}
