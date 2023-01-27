using Microsoft.EntityFrameworkCore;
using UserService.Data.EF;
using UserService.Data.EF.Interfaces;
using UserService.Data.EF.Repositories;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddScoped<IUserRepository, UserRepository>();
builder.Services.AddScoped<UnitOfWork>();

builder.Services.AddDbContext<ApplicationDbContext>(opt => opt
    .UseSqlServer("Server=DESKTOP-UUBJ14C\\SQLEXPRESS; Database=OrderDb;Trusted_Connection=True;"));

var app = builder.Build();

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
