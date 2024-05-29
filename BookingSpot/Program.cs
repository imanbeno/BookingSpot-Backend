// Program.cs
using BookingSpot.Data;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;

namespace BookingSpot
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            builder.Services.AddControllers();
            builder.Services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("2024", new OpenApiInfo { Title = "Bookingspot", Version = "2024" });
            });
            builder.Services.AddSingleton<IDataContext, DataBase>();
            builder.Services.AddCors(options =>
            {
                options.AddPolicy("MyPolicy",
                    builder => builder.AllowAnyOrigin()
                                      .AllowAnyMethod()
                                      .AllowAnyHeader());
            });

            var app = builder.Build();
            app.UseCors("MyPolicy");
            app.UseHttpsRedirection();
            app.UseSwagger();
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/2024/swagger.json", "BookingSpots");
            });

            app.UseAuthorization();
            app.MapControllers();

            app.Run();
        }
    }
}