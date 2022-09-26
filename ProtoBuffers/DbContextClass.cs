using DummyDB.Models;
using Microsoft.EntityFrameworkCore;

namespace ProtoBuffers
{
    public class DbContextClass : DbContext
    {

        public DbContextClass(DbContextOptions<DbContextClass> options): base(options) 
        {
            //Configure Data base Provider
            //Which DB provider to use
            
        }

        
       

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<OrderSchema>().HasData
               (
                 new OrderSchema
                 {
                     Id = 1,
                     OrderDataId = 2,
                     OrderSourceDestinatonId = 3,
                 },
                 new OrderSchema
                 {
                     Id = 10,
                     OrderDataId = 11,
                     OrderSourceDestinatonId = 12,
                 }
               );

            modelBuilder.Entity<OrderSourceDestinaton>().HasData(
             new OrderSourceDestinaton
             {
                 Id = 3,
                 SourceId = 88,
                 SourceName = "BHA",
                 DestinationId = 98,
                 DestinationName = "IND"

             },
             new OrderSourceDestinaton
             {
                 Id = 12,
                 SourceId = 89,
                 SourceName = "BA",
                 DestinationId = 99,
                 DestinationName = "ND"
             }
             );


            modelBuilder.Entity<OrderData>().HasData(
                new OrderData
                {
                    Id = 2,
                    Date= DateTime.Now.Date,
                    Time= DateTime.Now.ToLocalTime(),
                    OrderNumber="3745896",
                    ShipmentId = 4,
                     
                },
                new OrderData
                {
                    Id = 11,
                    Date = DateTime.Now.Date,
                    Time = DateTime.Now.ToLocalTime(),
                    OrderNumber = "3745896",
                    ShipmentId = 13,
                }
                );


            modelBuilder.Entity<Shipment>().HasData(
                new Shipment
                {
                    Id = 4,
                    ShipToId = 214,
                    Address = "Hindus Force Fortress",
                    Name = "Netaji",
                    CompanyName = "Hindu Force",
                    Town = "Bharat",
                    PostalCode = "61282",
                    IsoCountry = "IN",

                    CarrierId = 412,
                    Code = "368M",
                    Carrier = "DeltaD",



                },
                new Shipment
                {
                    Id = 13,
                    ShipToId = 100,
                    Address = "Hindus Forc",
                    Name = "Neta",
                    CompanyName = "Hindu orce",
                    Town = "Bhar",
                    PostalCode = "1282",
                    IsoCountry = "NI",

                    CarrierId = 412,
                    Code = "MM368",
                    Carrier = "DeltD"
                    


                }
               );


            modelBuilder.Entity<DummyDB.Models.Items>().HasData(
                    new DummyDB.Models.Items
                    {
                        Id = 5,
                        Sku = "LA1",
                        ComponentId = 6


                    },
                    new DummyDB.Models.Items
                    {
                        Id = 14,
                        Sku = "LA3",
                        ComponentId = 15,
                        
                    }
                );

            modelBuilder.Entity<Component>().HasData(
                       new Component
                       {
                           Id =6,
                           Code = "101",
                           Fetch = false,
                           Path = "La-CA"
                       },
                       new Component
                       {
                           Id = 15,
                           Code = "111",
                           Fetch = true,
                           Path = "CA-LA"
                       }
                    );


        }

        public DbSet<OrderSchema> OrderSchema { get; set; } = default!;
        public DbSet<OrderData> OrderData { get; set; } = default!;
        public DbSet<OrderSourceDestinaton> OrderSourceDestinaton { get; set; } = default!;
        public DbSet<Shipment> Shipment { get; set; } = default!;
        public DbSet<DummyDB.Models.Items> Items { get; set; } = default!;
        public DbSet<Component> Component { get; set ; } = default!;
    }
}
