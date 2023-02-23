using UserService.GraphQL.IOC;
using GraphQL;
using System.Web.Http.Dependencies;
using GraphQL.MicrosoftDI;
using GraphQL.Types;
using UserService.GraphQL.GraphQL;
using Microsoft.AspNetCore.Server.Kestrel.Core;
using UserService.Data.EF;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

DataInjection.ConfigureServices(builder.Services, builder.Configuration);
ServiceInjection.ConfigureServices(builder.Services, builder.Configuration);

builder.Services.AddScoped<ISchema, UserSchema>(services => new UserSchema(new SelfActivatingServiceProvider(services)));
builder.Services.AddGraphQL(options =>
                    options.ConfigureExecution((opt, next) =>
                    {
                        opt.EnableMetrics = true;
                        return next(opt);
                    }).AddSystemTextJson().AddErrorInfoProvider(opt => opt.ExposeExceptionDetails = true).AddNewtonsoftJson()
                );
builder.Services.Configure<KestrelServerOptions>(options =>
{
    options.AllowSynchronousIO = true;
});
builder.Services.Configure<IISServerOptions>(options =>
{
    options.AllowSynchronousIO = true;
});
var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
    app.UseGraphQLAltair();

    await using var scope = app.Services.CreateAsyncScope();
    using var db = scope.ServiceProvider.GetService<ApplicationDbContext>();
    await db.Database.MigrateAsync();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.UseGraphQL();

app.Run();
