namespace workoutTrackerServices.Models
{
    public class SetItem
    {
        public int Id{get; set;}
        public string ExerciseName{get; set;}
        public string MuscleGroup{get; set;}
        public float Weight{get; set;}
        public int Reps{get; set;}
        public ExerciseItem Exercise {get; set;}
        public int ExerciseId{get; set;}

        public SetItem(int id,string exerciseName,string muscleGroup,float weight,int reps)
        {
            Id=id;
            ExerciseName=exerciseName;
            MuscleGroup=muscleGroup;
            Weight=weight;
            Reps=reps;
        }
        public SetItem()
        {
          
            ExerciseName="";
            MuscleGroup="";
              
        }
    }
}