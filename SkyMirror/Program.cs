using Microsoft.EntityFrameworkCore;
using SkyMirror.DataAccess.Seeder;
using SkyMirror.DatabaseContext;
using SkyMirror.Entities;

var builder = WebApplication.CreateBuilder(args);

// ?? Add DbContext to Dependency Injection
builder.Services.AddDbContext<SkyMirrorDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Seeding the data

using (var scope = app.Services.CreateScope())
{
    var services = scope.ServiceProvider;
    var context = services.GetRequiredService<SkyMirrorDbContext>();

    // Apply migrations and seed data
    context.Database.Migrate(); // Applies pending migrations 
    DatabaseSeeder.SeedRoles(context); // Call seeding method
}

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
