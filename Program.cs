using Microsoft.EntityFrameworkCore;
using POSApplication.Models;
using POSApplication.Services;

var builder = WebApplication.CreateBuilder(args);

// Tambahkan DbContext dengan string koneksi dari konfigurasi
builder.Services.AddDbContext<PboPosContext>(options =>
    options.UseNpgsql(builder.Configuration.GetConnectionString("POSConnection")));


// Add services to the container.
builder.Services.AddControllersWithViews();

builder.Services.AddScoped<IBarangService, BarangService>();
builder.Services.AddScoped<IKategoriService, KategoriService>();
// builder.Services.AddScoped<IPenjualanService, PenjualanService>();


// Tambahkan layanan untuk MVC
builder.Services.AddControllersWithViews()
    .AddViewOptions(options =>
    {
        options.HtmlHelperOptions.ClientValidationEnabled = true;
    });


// Tambahkan layanan untuk controller API
builder.Services.AddControllers();
// Mengaktifkan CORS
builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowAll", policy =>
    {
        policy.AllowAnyOrigin().AllowAnyMethod().AllowAnyHeader();
    });
});

var app = builder.Build();

// Gunakan routing untuk API
app.MapControllers();

// Menggunakan CORS
app.UseCors("AllowAll");

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
