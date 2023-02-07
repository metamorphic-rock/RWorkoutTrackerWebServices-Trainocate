namespace workoutTrackerServices.Data;
using Microsoft.EntityFrameworkCore;
using workoutTrackerServices.Models;
public class DataContext: DbContext
{
    public DbSet<SetItem> SetItems{get; set;}
    public DbSet<ExerciseItem> ExerciseItems{get;set;}
    // public DbSet<WorkoutItem> WorkoutItems{get; set;} // do not comment this out until i said it
    public DataContext(DbContextOptions<DataContext> options): base(options)
    {

    }
}