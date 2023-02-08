using System;
using Microsoft.EntityFrameworkCore;
using workoutTrackerServices.Interfaces;
using workoutTrackerServices.Services;
using workoutTrackerServices.Data;
using System.Text.Json.Serialization;

namespace workoutTrackerServices
{
    class Program
    {
        static void Main(string[] args)
        {
            WebApplicationBuilder builder = WebApplication.CreateBuilder(args);
            var corsConfigName="CORS-Config";

            // Add services to the container.
            builder.Services.AddCors(options=>{
                options.AddPolicy(name: corsConfigName, policy=>{
                    policy.WithOrigins("*").AllowAnyHeader().AllowAnyMethod();
                });
            });

            builder.Services.AddControllers().AddJsonOptions(options=>{
                options.JsonSerializerOptions.ReferenceHandler=ReferenceHandler.IgnoreCycles;
                options.JsonSerializerOptions.WriteIndented=true;
            });
            builder.Services.AddDbContext<DataContext>(options=>{
                options.UseSqlServer(builder.Configuration.GetConnectionString("MSSqlConnection"));
            });
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();
            //added additional services
            builder.Services.AddScoped<ISetItemsService, SetItemMSSQLServices>();
            builder.Services.AddScoped<IExerciseItemServices,ExerciseItemMSSQLServices>();
            builder.Services.AddScoped<IWorkoutItemServices,WorkoutItemMSSQLServices>();

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }
            app.UseCors(corsConfigName);
            app.UseHttpsRedirection();

            app.UseAuthorization();

            app.MapControllers();

            app.Run();

        }
    }


}
