using AT_C__2.Data;
using Microsoft.EntityFrameworkCore;

namespace AT_C__2
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            builder.Services.AddRazorPages();
            builder.Services.AddDbContext<AgenciaViagensDB>(options =>
                options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

            // Register services
            builder.Services.AddScoped<Services.Interfaces.IClienteService, Services.ClienteService>();
            builder.Services.AddScoped<Repositories.Interfaces.IClienteRepository, Repositories.ClienteRepository>();
            builder.Services.AddScoped<Services.Interfaces.IDestinoService, Services.DestinoService>();
            builder.Services.AddScoped<Repositories.Interfaces.IDestinoRepository, Repositories.DestinoRepository>();
            builder.Services.AddScoped<Services.Interfaces.IPacoteTuristicoService, Services.PacoteTuristicoService>();
            builder.Services.AddScoped<Repositories.Interfaces.IPacoteTuristicoRepository, Repositories.PacoteTuristicoRepository>();
            builder.Services.AddScoped<Services.Interfaces.IReservaService, Services.ReservaService>();
            builder.Services.AddScoped<Repositories.Interfaces.IReservaRepository, Repositories.ReservaRepository>();

            builder.Services.AddAuthentication("CookieAuth")
            .AddCookie("CookieAuth", options =>
            {
                options.Cookie.Name = "AuthCookie";
                options.LoginPath = "/Login";
                options.AccessDeniedPath = "/AccessDenied";
            });

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
            app.UseAuthentication();
            app.UseAuthorization();

            app.MapRazorPages();

            app.Run();
        }
    }
}
