using System.Text.Json;
using workoutTrackerServices.Models;
namespace workoutTrackerServices.Operations
{
    public class BuildExerciseItemFromDictionary
    {
        private Dictionary<string, object> data;
        public BuildExerciseItemFromDictionary(Dictionary<string, object> data)
        {
            this.data = data;
            this.CleanUp();
        }
        public ExerciseItem Execute()
        {
            ExerciseItem exercise =new ExerciseItem();
            if (this.data.ContainsKey("id"))
            {
                exercise.Id = (int)this.data["id"];
            }
            exercise.ExerciseName = (string)this.data["exerciseName"];
            exercise.WorkoutId=int.Parse((this.data["workoutId"]).ToString());
            exercise.MuscleGroup = (string)this.data["muscleGroup"];

            return exercise;
        }
        public void CleanUp()
        {
            if (this.data.ContainsKey("id"))
            {
                if (this.data["id"] is JsonElement)
                {
                    this.data["id"] = int.Parse(((JsonElement)this.data["id"]).ToString());
                }
            }
            if (this.data["exerciseName"] is JsonElement)
            {
                this.data["exerciseName"] = ((JsonElement)this.data["exerciseName"]).ToString();
            }
            if (this.data["muscleGroup"] is JsonElement)
            {
                this.data["muscleGroup"] = ((JsonElement)this.data["muscleGroup"]).ToString();
            }
            if (this.data["workoutId"] is JsonElement)
            {
                this.data["workoutId"] = int.Parse(((JsonElement)this.data["workoutId"]).ToString());
            }
        }
    }
}