using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using SecureMvcApp.Data;

var builder = WebApplication.CreateBuilder(args);

// ---------------- SERVICES ----------------
builder.Services.AddControllersWithViews();
builder.Services.AddRazorPages();

// Database
builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

// Identity (ONLY ONCE)
builder.Services.AddDefaultIdentity<IdentityUser>(options =>
{
    options.SignIn.RequireConfirmedAccount = false;

    options.Password.RequireDigit = true;
    options.Password.RequiredLength = 6;
    options.Password.RequireUppercase = false;
    options.Password.RequireLowercase = true;
    options.Password.RequireNonAlphanumeric = false;
})
.AddRoles<IdentityRole>()
.AddEntityFrameworkStores<ApplicationDbContext>();

// External login
builder.Services.AddAuthentication()
.AddGoogle(options =>
{
    options.ClientId = builder.Configuration["Authentication:Google:ClientId"]!;
    options.ClientSecret = builder.Configuration["Authentication:Google:ClientSecret"]!;
})
.AddFacebook(options =>
{
options.AppId = builder.Configuration["Authentication:Facebook:AppId"]!;
options.AppSecret = builder.Configuration["Authentication:Facebook:AppSecret"]!;
});

builder.Services.AddDefaultIdentity<IdentityUser>(options =>
{
    options.SignIn.RequireConfirmedAccount = false;
})
.AddRoles<IdentityRole>()
.AddEntityFrameworkStores<ApplicationDbContext>();
// ---------------- BUILD ----------------
var app = builder.Build();

// ---------------- SEED DATA ----------------
using (var scope = app.Services.CreateScope())
{
    var services = scope.ServiceProvider;
    await RoleSeeder.SeedRolesAndAdminAsync(services);
}

// ---------------- PIPELINE ----------------
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
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

app.MapRazorPages();

app.Run();
