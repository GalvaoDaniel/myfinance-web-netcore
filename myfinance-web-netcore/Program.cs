using myfinance_web_netcore.Infrastructure;
using myfinance_web_netcore.Mappers;
using myfinance_web_netcore.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();
builder.AddNpgsqlDbContext<MyFinanceDbContext>(
    "db",
    static settings => settings.ConnectionString = "Server=127.0.0.1;Port=5432;Database=myfinance;User Id=postgres;Password=2035;");
builder.Services.AddAutoMapper(typeof(PlanoContaMap));
builder.Services.AddAutoMapper(typeof(TransacaoMap));
builder.Services.AddTransient<IPlanoContaService, PlanoContaService>();
builder.Services.AddTransient<ITransacaoService, TransacaoService>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
