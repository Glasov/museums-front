using BlazorApp2.Managers;
using BlazorApp2.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorPages();
builder.Services.AddServerSideBlazor();
builder.Services.AddScoped<IExhibitionItemsProvider, ExhibitionItemProvider>();
builder.Services.AddScoped<IExhibitionsProvider, ExhibitionsProvider>();
builder.Services.AddScoped<IUsersProvider, UsersProvider>();
builder.Services.AddScoped<IOrdersProvider, OrdersProvider>();
builder.Services.AddScoped<IAuthService, AuthService>();
builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri("http://localhost:5073") });

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseStaticFiles();

app.UseRouting();

app.MapBlazorHub();
app.MapFallbackToPage("/_Host");

app.Run();
