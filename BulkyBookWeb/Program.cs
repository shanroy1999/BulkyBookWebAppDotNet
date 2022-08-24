// configure the application and create web application builder object
using BulkyBookWeb.Data;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// register anything using dependency injection container
// Add services to the container since using MVC application
// different service will be used for Razor pages
builder.Services.AddControllersWithViews();
builder.Services.AddRazorPages().AddRazorRuntimeCompilation();

// add service for Database using ApplicationDbContext class file in Data folder
builder.Services.AddDbContext<ApplicationDbContext>(options => options.UseSqlServer(
    // look for the connection string in the appsettings.json
    builder.Configuration.GetConnectionString("DefaultDbConnection")
    ));

var app = builder.Build();

// Configure the HTTP request pipeline.
// pipeline specifies how application responds to a web request
// pipeline is made of different middlewares, MVC - type of middleware itself
// when application receives a request from Browser - req goes back and forth through pipeline
// each middleware - can modify the request that goes through the pipeline
// last middleware in the pipeline - responds back to the server

// check whether the evironment is a Development environment

// If not development environment
if (!app.Environment.IsDevelopment())
{
    // redirect to error page
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}
else
{
    // adding the useDeveloperException page - show user friendly exception for debugging
    app.UseDeveloperExceptionPage();
}

// Https redirection
app.UseHttpsRedirection();

// user static files in wwwroot folder
app.UseStaticFiles();

// routing middleware
app.UseRouting();

// authentication middleware - always before authorization
app.UseAuthentication();

// authorization middleware
app.UseAuthorization();

// routing url => {{ Domain }}/{{ Controller }}/{{ action }}/{{ id }}
// Domain of url -> localhost: 5555 (Port number)
// Route of url -> /Category
// Action of url -> /Index
// Id -> /10 (optional field - Can be Null )
// URL => https://localhost:5555/Category/Index/10

// maps different pattern for MVC - redirect request to corresponding controllers and actions
// default - if nothing provided (i,e. - if no controller and no action is provided )
// default url => /home/Index
app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}"
);

app.Run();
