var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
}
app.UseStaticFiles();

app.UseRouting();

//app.UseAuthorization();

builder.Services.AddHttpClient<ICustomerDataService, CustomerDataService>(
    client => {
        //client.BaseAddress = new Uri("http://localhost:5002/corporate.api"); // ApiProxy
        client.BaseAddress = new Uri("http://gbno-allennv1.kerridgecs.local:8084");
    });

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();

