using Microsoft.AspNetCore.Mvc.Formatters;
using Microsoft.EntityFrameworkCore;
using ProtoBuffers;

using ProtoBuffers.Repositories;
using ProtoBuffers.Repositories.IRepositories;
using ProtoBuffers.Services;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers(options =>
{
    options.RespectBrowserAcceptHeader = true;
    options.OutputFormatters.Insert(1, new FormatMediaFormatter());
});

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddDbContext<DbContextClass>(options => options.UseSqlServer(builder.Configuration.GetConnectionString("DBConnection")));
builder.Services.AddControllers();
builder.Services.AddRouting(options => { options.LowercaseUrls = true; options.AppendTrailingSlash = true; });

builder.Services.AddScoped<IComponentRepository, ComponentRepository>();
builder.Services.AddScoped<IShipmentRepository, ShipmentRepository>();
builder.Services.AddScoped<IItemRepository,ItemRepository>();
builder.Services.AddScoped<IOrderDataRepository, OrderDataRepository>();
builder.Services.AddScoped<OrderDataService>();
builder.Services.AddScoped<ComponentServices>();
builder.Services.AddScoped<ShipmentServices>();
builder.Services.AddScoped<GrpcService>();
builder.Services.AddScoped<ItemsService>();
var app = builder.Build();


app.UseHttpsRedirection();
app.UseSwagger();
app.UseSwaggerUI();

app.UseAuthorization();
app.MapControllers();
app.MapDefaultControllerRoute();

app.Run();