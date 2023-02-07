using System.Dynamic;
namespace workoutTrackerServices.Models;

public class ExerciseItem
{
    public int Id {get; set;}
    public string ExerciseName{get; set;}
    public List<SetItem>? SetItems{get; set;}

    public ExerciseItem()
    {
        
    }
}