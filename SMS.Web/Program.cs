using SMS.Data.Services;
using SMS.Data.Security;
using SMS.Web;

var builder = WebApplication.CreateBuilder(args);

// ** Add Authentication service using Cookie Scheme **
builder.Services.AddCookieAuthentication();
       
// Add services to the container.
builder.Services.AddControllersWithViews();
//configure services via builder i.e. DI system
builder.Services.AddScoped<IFoodService, FoodServiceDb>(); //interface (IFleetService)-implementation(FleetServiceDB)
//we use a scoped- for a single request we have one same service but we could use singleton or transient


var app = builder.Build();

// // Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
} else {
    // in  development mode seed the database each time the application starts
    FoodServiceSeeder.Seed(new FoodServiceDb());
}

//app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthentication();
app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
