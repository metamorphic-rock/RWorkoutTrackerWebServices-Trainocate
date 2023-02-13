using System.Dynamic;
namespace workoutTrackerServices.Models;

public class ExerciseItem
{
    public int Id {get; set;}
    public string ExerciseName{get; set;}
    public string MuscleGroup{get; set;}
    public int WorkoutId{get; set;}  //fix this later add workout id to controller,builder,services
    public WorkoutItem Workout{get; set;}
    public List<SetItem>? SetItems{get; set;}

    public ExerciseItem()
    {
        
    }
}