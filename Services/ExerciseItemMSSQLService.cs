namespace workoutTrackerServices.Services;
using System.Collections.Generic;
using workoutTrackerServices.Interfaces;
using workoutTrackerServices.Models;
using workoutTrackerServices.Data;

public class ExerciseItemMSSQLServices : IExerciseItemServices
{
    private readonly DataContext _dataContext;
    public ExerciseItemMSSQLServices(DataContext dataContext)
    {
        _dataContext = dataContext;
    }
    public ExerciseItem? Delete(int id)
    {
        var exercise = _dataContext.ExerciseItems.SingleOrDefault(e => e.Id == id);
        _dataContext.Remove(exercise);
        return exercise;
    }

    public ExerciseItem? FindById(int id)
    {
        return _dataContext.ExerciseItems.FirstOrDefault(e => e.Id == id);
    }

    public List<ExerciseItem> GetAll()
    {
        return _dataContext.ExerciseItems.ToList<ExerciseItem>();
    }

    public ExerciseItem Save(ExerciseItem exercise)
    {
        if (exercise.Id == null || exercise.Id == 0)
        {
            _dataContext.ExerciseItems.Add(exercise);
        }
        else
        {
            ExerciseItem temp = this.FindById(exercise.Id);
            temp.ExerciseName = exercise.ExerciseName;
            
        }
        _dataContext.SaveChanges();
        return exercise;
    }
}