using BikeClassLibrary;
using BikeClassLibrary.DBL;
using BikeLibrary.BLL;
using BikeLibrary.BLL.Interfaces;
using BikeLibrary.DBL;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Connections;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorPages();
builder.Services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme).AddCookie(
    options =>
    {
        options.LoginPath = new PathString("/Login");
        options.AccessDeniedPath = new PathString("/Index");
    }
);
builder.Services.AddDistributedMemoryCache();
builder.Services.AddSession(options =>
{
    options.Cookie.HttpOnly = true;
    options.Cookie.IsEssential = true;
});

var connString = builder.Configuration.GetConnectionString("DefaultConnection");
builder.Services.AddTransient<IAccountRepository>(s => new DBAccounts(connString));
builder.Services.AddTransient<IBikeRepository>(s => new DBBikes(connString));
builder.Services.AddTransient<IOrderRepository>(s => new DBOrders(connString));
builder.Services.AddTransient<IOrderService, OrderService>();
builder.Services.AddTransient<IInventory, Inventory>();
builder.Services.AddTransient<IAccountService, AccountService>();


var app = builder.Build();


// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
	app.UseExceptionHandler("/Error");
	// The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
	app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseSession();
app.UseAuthentication();
app.UseAuthorization();

app.MapRazorPages();

app.Run();
