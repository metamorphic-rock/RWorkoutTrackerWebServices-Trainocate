namespace workoutTrackerServices.Services;

using System.Collections.Generic;
using workoutTrackerServices.Interface;
using workoutTrackerServices.Models;
using Microsoft.EntityFrameworkCore;
using workoutTrackerServices.Data;

public class SetItemMSSQLServices : ISetItemsService
{
    private readonly DataContext _dataContext;
    public SetItemMSSQLServices(DataContext dataContext)
    {
        _dataContext=dataContext;
    }
    public SetItem? Delete(int id)
    {
        throw new NotImplementedException();
    }

    public SetItem? Find(int id)
    {
        throw new NotImplementedException();
    }

    public List<SetItem> GetAll()
    {
        throw new NotImplementedException();
    }

    public SetItem Save(SetItem set)
    {
        throw new NotImplementedException();
        _dataContext.SaveChanges();
    }
}