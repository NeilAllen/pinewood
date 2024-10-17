using pinewood.api;
using Microsoft.EntityFrameworkCore;
using pinewood.api.Customers;

var builder = WebApplication.CreateBuilder(args);
//builder.Services.AddDbContext<CustomerDb>(opt => opt.UseInMemoryDatabase("Customers"));
builder.Services.AddDbContext<CustomerDb>(options =>
    options.UseSqlite(builder.Configuration.GetConnectionString("CustomerDbContext")));

builder.Services.AddDatabaseDeveloperPageExceptionFilter();
builder.Services.AddEndpointsApiExplorer();

var app = builder.Build();

app.RegisterCustomersEndpoints();
app.Run();
