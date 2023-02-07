using System;
using Microsoft.EntityFrameworkCore;
using workoutTrackerServices.Interfaces;
using workoutTrackerServices.Services;
using workoutTrackerServices.Data;
namespace workoutTrackerServices
{
    class Program
    {
        static void Main(string[] args)
        {
            WebApplicationBuilder builder = WebApplication.CreateBuilder(args);

            // Add services to the container.

            builder.Services.AddControllers();
            builder.Services.AddDbContext<DataContext>(options=>{
                options.UseSqlServer(builder.Configuration.GetConnectionString("MSSqlConnection"));
            });
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();
            //added additional services
            builder.Services.AddScoped<ISetItemsService, SetItemMSSQLServices>();
            builder.Services.AddScoped<IExerciseItemServices,ExerciseItemMSSQLServices>();

            var app = builder.Build();

            // Configure the HTTP request pipeline.
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


}
