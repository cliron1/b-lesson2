using Microsoft.EntityFrameworkCore;
using Website.Data;
using Website.Models;
using Website.Services;

internal class Program {
    private static void Main(string[] args) {
        var builder = WebApplication.CreateBuilder(args);

        builder.Services.Configure<CustomSettings>(
            builder.Configuration.GetSection("Custom")
        );


        // Add services to the container.
        builder.Services.AddControllersWithViews();

        var connectionString =
            builder.Configuration.GetConnectionString("Database");

        builder.Services.AddDbContext<MyContext>(options => {
            options.UseSqlServer(connectionString);
        });

        if(builder.Environment.IsProduction())
            builder.Services.AddSingleton<IMyService, MyService>();
        else
            builder.Services.AddSingleton<IMyService, MyServiceMock>();







        // ******************************************************

        var app = builder.Build();

        // Configure the HTTP request pipeline.
        if(!app.Environment.IsDevelopment()) {
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
    }
}