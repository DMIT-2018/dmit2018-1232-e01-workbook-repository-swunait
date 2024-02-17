using NorthwindBlazorApp.Components;

#region Namespaces for EF Core extension class
using NorthwindSystem;
using Microsoft.EntityFrameworkCore;
#endregion


var builder = WebApplication.CreateBuilder(args);

#region Register EF extension class
var northwindConnectionString = builder.Configuration.GetConnectionString("NorthindConnection");
builder.Services.AddBackendDependencies(options => options.UseSqlServer(northwindConnectionString));
#endregion

// Add services to the container.
builder.Services.AddRazorComponents()
    .AddInteractiveServerComponents();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error", createScopeForErrors: true);
}

app.UseStaticFiles();
app.UseAntiforgery();

app.MapRazorComponents<App>()
    .AddInteractiveServerRenderMode();

app.Run();
