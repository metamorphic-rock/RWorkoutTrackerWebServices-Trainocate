namespace workoutTrackerServices.Interfaces;
using workoutTrackerServices.Models;
public interface IWorkoutItemServices
{
    public List<WorkoutItem> GetAll();
    public void Save(WorkoutItem workout);
    public WorkoutItem? FindById(int id);
    public WorkoutItem GetLastAdded();
    public WorkoutItem? Delete(int id);
}