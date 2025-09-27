using MyBlazorHybridApp.Shared.Services;
using MyBlazorHybridApp.Web.Components;
using MyBlazorHybridApp.Web.Services;
using Microsoft.EntityFrameworkCore;
using MyBlazorHybridApp.Web.Data;
using Microsoft.AspNetCore.Components;


var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorComponents()
    .AddInteractiveServerComponents()
    .AddInteractiveWebAssemblyComponents();

builder.Services.AddSingleton<IFormFactor, FormFactor>();

builder.Services.AddDbContext<PizzaStoreContext>(options =>
    options.UseSqlite("Data Source=pizza.db"));

builder.Services.AddControllers();
builder.Services.AddHttpClient();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseWebAssemblyDebugging();
}
else
{
    app.UseExceptionHandler("/Error", createScopeForErrors: true);
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();
app.UseAntiforgery();

app.MapRazorComponents<App>()
    .AddInteractiveServerRenderMode()
    .AddInteractiveWebAssemblyRenderMode()
    .AddAdditionalAssemblies(
        typeof(MyBlazorHybridApp.Shared._Imports).Assembly,
        typeof(MyBlazorHybridApp.Web.Client._Imports).Assembly);

app.MapControllers();

using (var scope = app.Services.CreateScope())
{
    var db = scope.ServiceProvider.GetRequiredService<PizzaStoreContext>();
    db.Database.EnsureCreated();
    SeedData.Initialize(db);
}

app.Run();
