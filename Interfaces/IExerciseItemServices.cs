namespace workoutTrackerServices.Interfaces;
using workoutTrackerServices.Models;
public interface IExerciseItemServices
{
    public List<ExerciseItem> GetAll();
    public ExerciseItem Save(ExerciseItem set);
    public ExerciseItem? FindById(int id);
    public ExerciseItem? Delete(int id);
}