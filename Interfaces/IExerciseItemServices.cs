namespace workoutTrackerServices.Interfaces;
using workoutTrackerServices.Models;
public interface IExerciseItemServices
{
    public List<ExerciseItem> GetAll();
    public ExerciseItem Save(ExerciseItem exercise);
    public ExerciseItem? FindById(int id);
    public ExerciseItem? Delete(int id);
}