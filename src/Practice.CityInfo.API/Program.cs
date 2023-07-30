using Microsoft.AspNetCore.StaticFiles;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using Practice.CityInfo.API;
using Practice.CityInfo.API.DBContext;
using Practice.CityInfo.API.Repositories;
using Serilog;
using System.Reflection;
using System.Text;

Log.Logger = new LoggerConfiguration()
    .MinimumLevel.Information()
    .WriteTo.File("logs/cityinfo.txt", rollingInterval: RollingInterval.Day).CreateLogger();

var builder = WebApplication.CreateBuilder(args);

builder.Host.UseSerilog();
// Add services to the container.

builder.Services.AddControllers();

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(setupaction =>
{
    var xmlCommentsFile = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
    var xmlCommentsFullPath = Path.Combine(AppContext.BaseDirectory, xmlCommentsFile);
    setupaction.IncludeXmlComments(xmlCommentsFullPath);

    setupaction.AddSecurityDefinition("CityInfoApiBearerAuth", new Microsoft.OpenApi.Models.OpenApiSecurityScheme
    {
        Type = Microsoft.OpenApi.Models.SecuritySchemeType.Http,
        Scheme = "Bearer",
        Description = "Input a valid token to access this Api"
    });

    setupaction.AddSecurityRequirement(new Microsoft.OpenApi.Models.OpenApiSecurityRequirement
    {
        {
            new OpenApiSecurityScheme
            {
                Reference = new OpenApiReference
                {
                    Type = ReferenceType.SecurityScheme,
                    Id = "CityInfoApiBearerAuth"
                }
            }, new List<string>()
        }
    });
});

builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());

builder.Services.AddSingleton<CitiesDataStore>();
builder.Services.AddScoped<ICityInfoRepository, CityInfoRepository>();

builder.Services.AddAuthentication("Bearer").AddJwtBearer(options =>
{
    options.TokenValidationParameters = new()
    {
        ValidateLifetime = true,
        ValidateIssuer = true,
        ValidateAudience = true,
        ValidateIssuerSigningKey = true,
        ValidIssuer = builder.Configuration["Authentication:Issuer"],
        ValidAudience = builder.Configuration["Authentication:Audience"],
        IssuerSigningKey = new SymmetricSecurityKey(
            Encoding.ASCII.GetBytes(builder.Configuration["Authentication:SecretForKey"]))
    };
});

builder.Services.AddAuthorization(options =>
{
    options.AddPolicy("MustBeFromCleveland", policy =>
    {
        policy.RequireAuthenticatedUser();
        policy.RequireClaim("city", "Cleveland");
    });
});

builder.Services.AddApiVersioning(setup =>
{
    setup.AssumeDefaultVersionWhenUnspecified = true;
    setup.DefaultApiVersion = new Microsoft.AspNetCore.Mvc.ApiVersion(1, 0);
    setup.ReportApiVersions = true;
});

builder.Services.AddDbContext<CityInfoDbContext>(dbContextOptions =>
    dbContextOptions.UseSqlServer(builder.Configuration["ConnectionStrings:CityInfoDbContext"]));

builder.Services.AddSingleton<FileExtensionContentTypeProvider>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseRouting();
app.UseAuthentication();
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
