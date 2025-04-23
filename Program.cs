using myapp.Components;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorComponents()
    .AddInteractiveServerComponents();

var app = builder.Build();

// 👇 Add this if you're hosting under a sub-path like "/pawalert"
app.UsePathBase("/pawalert");

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error", createScopeForErrors: true);
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();
app.UseRouting();
app.UseAntiforgery();

// 👇 Fallback route for deep linking
app.MapFallbackToPage("/_Host");

// Razor components mapping
app.MapRazorComponents<App>()
    .AddInteractiveServerRenderMode();

app.Run();
