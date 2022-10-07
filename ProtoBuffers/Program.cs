using Microsoft.AspNetCore.Mvc.Formatters;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Logging.Configuration;
using ProtoBuffers;

using ProtoBuffers.Repositories;
using ProtoBuffers.Repositories.IRepositories;
using ProtoBuffers.Services;
using Serilog;

var builder = WebApplication.CreateBuilder(args);

var logger = new LoggerConfiguration()
    .ReadFrom.Configuration(builder.Configuration)
    .WriteTo.Console()
    .Enrich.FromLogContext()
    .CreateLogger();

try
{
    Log.Information("Start Application");

}
catch (Exception ex)
{
    Log.Information(ex, "Application Crashed - Issue with application start");
}
finally { Log.CloseAndFlush(); }



var config = builder.Configuration.Get<AppSettings>();
builder.Services.AddSingleton<AppSettings>();

builder.Services.AddControllers(options =>
{
    options.RespectBrowserAcceptHeader = true;
    options.OutputFormatters.Insert(1, new FormatMediaFormatter());
});



builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddDbContext<DbContextClass>(options => options.UseSqlServer(config.ConnectionString.ConnectToDatabaseString));
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
builder.Logging.ClearProviders();
builder.Logging.AddSerilog(logger);
builder.Host.UseSerilog();


var app = builder.Build();

app.UseHttpsRedirection();
app.UseSwagger();
app.UseSwaggerUI();

app.UseAuthorization();
app.MapControllers();
app.UseSerilogRequestLogging();
app.MapDefaultControllerRoute();

app.Run();