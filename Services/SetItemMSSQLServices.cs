namespace workoutTrackerServices.Services;
using System.Collections.Generic;
using workoutTrackerServices.Interfaces;
using workoutTrackerServices.Models;
using Microsoft.EntityFrameworkCore;
using workoutTrackerServices.Data;

public class SetItemMSSQLServices : ISetItemsService
{
    private readonly DataContext _dataContext;
    public SetItemMSSQLServices(DataContext dataContext)
    {
        _dataContext = dataContext;
    }
    public SetItem? Delete(int id)
    {
        var set =_dataContext.SetItems.SingleOrDefault(s => s.Id == id);
        _dataContext.Remove(set); //find the command for delete
        return set;
    }

    public SetItem? FindById(int id)
    {
        return _dataContext.SetItems.SingleOrDefault(s => s.Id == id);
    }

    public List<SetItem> GetAll()
    {
        return _dataContext.SetItems.ToList<SetItem>();
    }

    public SetItem Save(SetItem set)
    {
        if (set.Id == null || set.Id == 0)
        {
            _dataContext.SetItems.Add(set);
        }
        else
        {
            SetItem temp=this.FindById(set.Id);
            temp.ExerciseName=set.ExerciseName;
            temp.MuscleGroup=set.MuscleGroup;
            temp.Weight=set.Weight;
            temp.Reps=set.Reps;
        }
        _dataContext.SaveChanges();
        return set;
    }
}