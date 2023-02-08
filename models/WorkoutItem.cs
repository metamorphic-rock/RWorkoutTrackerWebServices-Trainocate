namespace workoutTrackerServices.Models;
public class WorkoutItem
{
    public int Id{get; set;}
    public string WorkoutTitle{get; set;}
    public DateTime Date{get; set;} 
    public List<ExerciseItem>? ExerciseItems{get; set;}

}