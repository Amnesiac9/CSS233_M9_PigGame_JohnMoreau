/*
* John Moreau
* CSS233
* 11/29/2023
*/

var builder = WebApplication.CreateBuilder(args);

// Enable Session State
builder.Services.AddMemoryCache();
builder.Services.AddSession();

// Add services to the container. // Add Json Serializer
builder.Services.AddControllersWithViews().AddNewtonsoftJson(); // This is weird, why not make it simple and just be builder.Services.AddNewtonsoftJson();

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

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
