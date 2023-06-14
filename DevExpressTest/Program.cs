
using BlazorPro.BlazorSize;
using DataAccessLibrary;
using DevExpress.Blazor.Reporting;
using DevExpressTest.Data;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorPages();
builder.Services.AddServerSideBlazor();
builder.Services.AddDevExpressBlazor();
builder.Services.AddSingleton<WeatherForecastService>();
builder.Services.AddTransient<ISqlDataAccess, SqlDataAccess>();
builder.Services.AddTransient<IDispositivoData, DispositivoData>();
builder.Services.AddTransient<IOrdineData, OrdineData>();
builder.Services.AddTransient<IOrdiniDataNoDapper, OrdiniDataNoDapper>();
builder.Services.AddScoped<BrowserService>();
builder.Services.AddMediaQueryService();
builder.Services.AddScoped<IResizeListener, ResizeListener>();
builder.Services.AddDevExpressBlazorReporting();
builder.Services.AddScoped<ReportStorageWebExtension, CustomReportStorageWebExtension>();
builder.Services.Configure<DevExpress.Blazor.Configuration.GlobalOptions>(options =>
{
    options.BootstrapVersion = DevExpress.Blazor.BootstrapVersion.v5;
});
builder.WebHost.UseWebRoot("wwwroot");
builder.WebHost.UseStaticWebAssets();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}
app.UseHttpsRedirection();



app.UseStaticFiles();

app.UseRouting();


app.MapBlazorHub();
app.MapFallbackToPage("/_Host");

app.UseEndpoints(endpoints =>
{
    endpoints.MapControllers();
});

app.Run();