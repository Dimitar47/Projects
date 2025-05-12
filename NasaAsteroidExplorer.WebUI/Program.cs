using NasaAsteroidExplorer.Application.Configurations;
using NasaAsteroidExplorer.Application.Interfaces;
using NasaAsteroidExplorer.Application.Services;
using NasaAsteroidExplorer.Infrastructure.Services;


namespace NasaAsteroidExplorer
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            builder.Services.AddControllersWithViews();
            builder.Services.AddHttpClient();
            builder.Services.AddScoped<INeoAsteroidService, NeoAsteroidService>();
            builder.Services.AddScoped<IApodService, ApodService>();
            builder.Services.AddScoped<AsteroidManager>();
            builder.Services.Configure<NasaSettings>(
                builder.Configuration.GetSection("NASA")
            );


            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (!app.Environment.IsDevelopment())
            {
                app.UseExceptionHandler("/Shared/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthorization();

            app.MapControllerRoute(
                name: "default",
                pattern: "{controller=Apod}/{action=Index}/{date?}");

            app.Run();
        }
    }
}
