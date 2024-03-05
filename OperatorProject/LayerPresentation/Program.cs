using FluentAssertions.Common;
using LayerAccess;
using LayerBusiness;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace YourNamespace
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            builder.Services.AddDbContext<Baglanti>(options =>
        options.UseSqlServer("Server=DESKTOP-2PGSHUI\\SQLEXPRESS;Database=OperatorDb;User Id=sa;Password=1234;Encrypt=true;TrustServerCertificate=true;"));

            
            ConfigureServices(builder.Services,builder.Configuration);

            var app = builder.Build();

            if (!app.Environment.IsDevelopment())
            {
                app.UseExceptionHandler("/Home/Error");
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthorization();

            app.MapControllerRoute(
                name: "default",
                pattern: "{controller=Musteri}/{action=MusteriIdAl}/{id?}");

            app.Run();
        }

        public static void ConfigureServices(IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<Baglanti>(options =>
       options.UseSqlServer(configuration.GetConnectionString("Server=DESKTOP-2PGSHUI\\SQLEXPRESS;Database=OperatorDb;Uid=sa;Pwd=1234;Encrypt=true;TrustServerCertificate=true;")));
            services.AddScoped<KimlikBilgileriDal>();
            services.AddScoped<MusteriPaketTutarDal>();
            services.AddScoped<TalepKaydiDal>();
            services.AddScoped<KimlikBilgileriBL>();
            services.AddScoped<MusteriPaketTutarBL>();
            services.AddScoped<TalepKaydiBL>();
            services.AddScoped<MusteriBL>();
            services.AddScoped<MusteriDal>();
            services.AddScoped<TarifeBL>();
            services.AddScoped<TarifeDal>();
            services.AddScoped<KullaniciBL>();
            services.AddScoped<KullaniciDal>();
            
            services.AddAuthorization();
            services.AddControllers();
            services.AddControllersWithViews();
            // Diðer hizmet kayýtlarý...
        }
    }
}