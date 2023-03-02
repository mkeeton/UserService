using GraphQL.MicrosoftDI;
using GraphQL.Types;
using GraphQL;
using Microsoft.AspNetCore.Server.Kestrel.Core;
using UserService.GraphQL.Custom.IOC;
using UserService.GraphQL.Custom.GraphQL;

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

builder.WebHost.UseSentry();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
    app.UseGraphQLAltair();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.UseGraphQL();

app.UseSentryTracing();

app.Run();
