
using APBDpk2.Entities;
using APBDpk2.Services;
using Microsoft.EntityFrameworkCore;

namespace APBDpk2
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.


            builder.Services.AddControllers();
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

            builder.Services.AddScoped<IMuzykDbService, MuzykDbService>();

            builder.Services.AddDbContext<MuzykaDbContext>(opt =>
            {
                string connString = builder.Configuration.GetConnectionString("DbConnString");
                opt.UseSqlServer(connString);
            });

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseAuthorization();


            app.MapControllers();

            app.Run();
        }
    }
}