namespace workoutTrackerServices.Interfaces;
using workoutTrackerServices.Models;
public interface IExerciseItemServices
{
    public List<ExerciseItem> GetAll();
    public void Save(ExerciseItem exercise);
    public ExerciseItem? FindById(int id);
    public ExerciseItem GetLastAdded();
    public ExerciseItem? Delete(int id);
}