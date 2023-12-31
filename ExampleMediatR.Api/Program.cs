using ExampleMediatR.Api.Persistence;
using ExampleMediatR.Api.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
//using Microsoft.Extensions.Configuration;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddControllers();
builder.Services.AddScoped<ICustomersRepository, CustomersRepository>();
builder.Services.AddScoped<IOrdersRepository, OrdersRepository>();

//builder.Services.AddSingleton<IMapper, Mapper>();
//builder.Services.AddMediatR(cfg=>cfg.RegisterServicesFromAssemblies(typeof(GetMakesQueryHandler).GetTypeInfo().Assembly));
//builder.Services.AddMediatR(typeof(Program)); // <- auto scan for handlers and register them in DI.
builder.Services.AddDbContext<ShopDbContext>(options => 
        options.UseSqlServer(builder.Configuration.GetConnectionString("ShopDb")));

//builder.Services.AddDbContext<ShopDbContext>(o =>
//{
//    var connectionString = builder.Configuration.GetConnectionString("ShopDb");
//    o.UseSqlServer(connectionString, s =>
//    {
//        s.CommandTimeout(180);
//        s.MigrationsAssembly(Assembly.GetExecutingAssembly().ToString());
//    });
//});

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseAuthorization();
app.MapControllers();
app.Run();
