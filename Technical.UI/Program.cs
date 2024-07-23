using Microsoft.AspNetCore.Authentication.Cookies;
using Technical.UI.Services;
using Technical.UI.Services.IService;
using Technical.UI.Utility;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

//configure httpclient
builder.Services.AddHttpContextAccessor();
builder.Services.AddHttpClient();
builder.Services.AddHttpClient<ILocationService, LocationService>();
builder.Services.AddHttpClient<IAuthService, AuthService>();
SD.LocationAPIBase = builder.Configuration["ServiceUrls:LocationAPI"];
SD.BpkpAPIBase = builder.Configuration["ServiceUrls:BpkpAPI"];
SD.AuthAPIBase = builder.Configuration["ServiceUrls:AuthAPI"];

// register service and base service
builder.Services.AddScoped<IBaseService, BaseService>();
builder.Services.AddScoped<IAuthService, AuthService>();
builder.Services.AddScoped<ITokenProvider, TokenProvider>();
builder.Services.AddScoped<ILocationService, LocationService>();
builder.Services.AddScoped<IBpkpService, BpkpService>();
builder.Services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme)
    .AddCookie(options =>
    {
        options.ExpireTimeSpan = TimeSpan.FromHours(10);
        options.LoginPath = "/Auth/Login";
        options.AccessDeniedPath = "/Auth/AccessDenied";
    });

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();
app.UseAuthentication();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
