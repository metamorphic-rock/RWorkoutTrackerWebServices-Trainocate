namespace workoutTrackerServices.Data;
using Microsoft.EntityFrameworkCore;
using workoutTrackerServices.Models;
public class DataContext: DbContext
{
    public DbSet<SetItem> SetItems{get; set;}
    public DataContext(DbContextOptions<DataContext> options): base(options)
    {

    }
}