using Microsoft.EntityFrameworkCore;
using System.Text.Json.Serialization;

namespace RetroInventoryApi
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);


            builder.Services.AddControllers();
            builder.Services.AddControllers().AddJsonOptions(options =>
            {
                options.JsonSerializerOptions.Converters.Add(new JsonStringEnumConverter());
            });

            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen(c =>
                c.UseInlineDefinitionsForEnums()
            );

            builder.Services.AddDbContext<ApplicationDbContext>();

            var app = builder.Build();

            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();                
            }

            app.UseHttpsRedirection();

            app.UseAuthorization();


            app.MapControllers();

            app.Run();
        }
    }

    public class ApplicationDbContext : DbContext
    {
        string DbUsername = Environment.GetEnvironmentVariable("RETROINVENTORY_DB_USERNAME");
        string DbPassword = Environment.GetEnvironmentVariable("RETROINVENTORY_DB_PASSWORD");

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseNpgsql($"Host=localhost;Database=retroinventorydb;Username={DbUsername};Password={DbPassword}");
        }
    }
}
