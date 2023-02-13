namespace workoutTrackerServices.Models
{
    public class SetItem
    {
        public int Id{get; set;}
        public string ExerciseName{get; set;}
        
        public float Weight{get; set;}
        public int Reps{get; set;}
        public ExerciseItem Exercise {get; set;}
        public int ExerciseId{get; set;}
        public WorkoutItem workout{get; set;}
        public int WorkoutId{get; set;}

        public SetItem(int id,string exerciseName,float weight,int reps)
        {
            Id=id;
            ExerciseName=exerciseName;      
            Weight=weight;
            Reps=reps;
        }
        public SetItem()
        {
          
            ExerciseName="";
              
        }
    }
}