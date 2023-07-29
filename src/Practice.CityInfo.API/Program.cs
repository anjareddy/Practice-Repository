using Microsoft.EntityFrameworkCore;
using Practice.CityInfo.API;
using Practice.CityInfo.API.DBContext;
using Serilog;


Log.Logger = new LoggerConfiguration()
    .MinimumLevel.Information()
    .WriteTo.File("logs/cityinfo.txt", rollingInterval: RollingInterval.Day).CreateLogger();

var builder = WebApplication.CreateBuilder(args);

builder.Host.UseSerilog();
// Add services to the container.

builder.Services.AddControllers();

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddSingleton<CitiesDataStore>();

builder.Services.AddDbContext<CityInfoDbContext>(dbContextOptions =>
    dbContextOptions.UseSqlServer(builder.Configuration["ConnectionStrings:CityInfoDbContext"]));

//builder.Services.AddSingleton<FileExtensionContentTypeProvider>();


var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseRouting();
app.UseAuthorization();


//app.Use(async (context, next) =>
//{
//    var endpoint = context.GetEndpoint();
//    if (endpoint != null)
//    {
//        Console.WriteLine($"endpoint.DisplayName: {endpoint.DisplayName}");

//        if (endpoint is RouteEndpoint routeEndpoint)
//        {
//            Console.WriteLine($"routeEndpoint.RoutePattern.RawText:{routeEndpoint.RoutePattern.RawText}");
//        }

//            Console.WriteLine("METADATA");
//        foreach (var metadata in endpoint.Metadata)
//        {
//            Console.WriteLine(metadata);
//        }

//    }
//    else
//    {
//        await context.Response.WriteAsync("End point is null");
//    }

//    await next();
//});

app.UseEndpoints(endPoints => endPoints.MapControllers());

//
//app.Run(async (context) =>
//{
//    await context.Response.WriteAsync("Hello");
//});

app.Run();
