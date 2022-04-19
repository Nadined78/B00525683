using Microsoft.AspNetCore.Authentication.Cookies;
using SMS.Data.Services;
using SMS.Web;

var builder = WebApplication.CreateBuilder(args);

// ** Add CookieAuthentication service using Cookie Scheme via Extension method **
builder.Services.AddCookieAuthentication();

// ** configure the dependency injection system with implementation of IStudentService
builder.Services.AddScoped<IStudentService,StudentServiceDb>();

// Add services to the container.
builder.Services.AddControllersWithViews();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
} else {
    // ** in  development mode seed the database each time the application starts
    StudentServiceSeeder.Seed(new StudentServiceDb()); //app.Services.GetRequiredService<IStudentService>());
}

//app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

// ** Enable site Authentication/Authorization **
app.UseAuthentication();
app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
