namespace workoutTrackerServices.Services;
using System.Collections.Generic;
using workoutTrackerServices.Interfaces;
using workoutTrackerServices.Models;
using workoutTrackerServices.Data;
public class WorkoutItemMSSQLServices : IWorkoutItemServices
{
    private readonly DataContext _dataContext;
    public WorkoutItemMSSQLServices(DataContext dataContext)
    {
        _dataContext=dataContext;
    }
    public WorkoutItem? Delete(int id)
    {
        var workout =_dataContext.WorkoutItems.SingleOrDefault(w => w.Id ==id);
        _dataContext.Remove(workout);
        return workout;
    }

    public WorkoutItem? FindById(int id)
    {
        return _dataContext.WorkoutItems.FirstOrDefault(w=> w.Id==id);
    }

    public List<WorkoutItem> GetAll()
    {
        return _dataContext.WorkoutItems.ToList<WorkoutItem>();
    }

    public void Save(WorkoutItem workout)
    {
        if (workout.Id == null || workout.Id == 0)
        {
            _dataContext.WorkoutItems.Add(workout);
        }
        else
        {
            WorkoutItem temp = this.FindById(workout.Id);
            temp.WorkoutTitle = workout.WorkoutTitle;
            
        }
        _dataContext.SaveChanges();
    }
}