using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using ProiectPAW__MVC_.Data;
using ProiectPAW__MVC_.Repositories;
using ProiectPAW__MVC_.Services;
using Microsoft.Extensions.DependencyInjection;

var builder = WebApplication.CreateBuilder(args);


builder.Services.AddTransient<CategoryRepository>();
builder.Services.AddTransient<ProductRepository>();
builder.Services.AddTransient<OrderRepository>();
builder.Services.AddTransient<OrderItemRepository>();
builder.Services.AddTransient<CustomerRepository>();
builder.Services.AddTransient<AddressRepository>();
builder.Services.AddTransient<CardRepository>();
builder.Services.AddTransient<AdminRepository>();

builder.Services.AddTransient<InternetService>();
builder.Services.AddTransient<MobileService>();
builder.Services.AddTransient<TelevisionService>();
builder.Services.AddTransient<PhonesService>();
builder.Services.AddTransient<CartService>();
builder.Services.AddTransient<CreateAccountService>();
builder.Services.AddTransient<AccountDetailsService>();
builder.Services.AddTransient<HomepageService>();

builder.Services.AddDefaultIdentity<IdentityUser>(options => options.SignIn.RequireConfirmedAccount = true)
    .AddRoles<IdentityRole>()
    .AddEntityFrameworkStores<ProiectPAWDbContext>();builder.Services.AddDbContext<ProiectPAWDbContext>(options => 
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

builder.Services.AddSession(options =>
{
    options.IdleTimeout = TimeSpan.FromSeconds(18000);
    options.Cookie.HttpOnly = true;
    options.Cookie.IsEssential = true;
});

// Add services to the container.
builder.Services.AddControllersWithViews();
builder.Services.AddHttpContextAccessor();
var app = builder.Build();


// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}
app.UseSession();

app.UseHttpsRedirection();
app.UseStaticFiles();
app.UseAuthentication();
app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
