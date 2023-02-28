using Sentry;
using UserService.GraphQL.HotChocolate.GraphQL;
using UserService.GraphQL.HotChocolate.GraphQL.Queries;
using UserService.GraphQL.HotChocolate.IOC;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

DataInjection.ConfigureServices(builder.Services, builder.Configuration);
ServiceInjection.ConfigureServices(builder.Services, builder.Configuration);

GraphQLConfig.Configure(builder.Services);

builder.WebHost.UseSentry();

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

app.MapGraphQL();

app.UseSentryTracing();

app.Run();
