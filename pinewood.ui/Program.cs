using pinewood.ui.services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorPages();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
}
app.UseStaticFiles();

app.UseRouting();

//app.UseAuthorization();

builder.Services.AddHttpClient<ICustomerDataService, CustomerDataService>(
    client => {
        client.BaseAddress = new Uri("http://localhost:5105");
    });

app.MapRazorPages();

app.Run();

