using Microsoft.EntityFrameworkCore;
using Planet.Infrastructure;
using Planet.Persistence.Contexts;
using Planet.Persistence.Seeding;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddDbContext<PlanetContext>(options => options.UseSqlServer(builder.Configuration.GetConnectionString("SqlServer")));
builder.Services.AddInfrastructureServices();
var app = builder.Build();

if (bool.Parse(app.Configuration.GetSection("Seeding")["IsActive"]))
{
    await app.SeedAsync(builder.Configuration);
}

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseAuthorization();

app.MapControllers();

app.Run();
