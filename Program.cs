using SwapiAPI.Components;
using SwapiAPI.Components.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorComponents()
    .AddInteractiveServerComponents();

// Adds an HttpClient instance to the container.
// This can be used to make HTTP requests to external APIs or services.
builder.Services.AddHttpClient();

// Registers the SwapiService class with the dependency injection container.
// The scope is set to Scoped, meaning a new instance will be created for each HTTP request.
builder.Services.AddScoped<ISwapiService, SwapiService>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error", createScopeForErrors: true);
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();

app.UseStaticFiles();
app.UseAntiforgery();

app.MapRazorComponents<App>()
    .AddInteractiveServerRenderMode();

app.Run();