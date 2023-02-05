using System.Net.Mime;
using workoutTrackerServices.Models;
using System.Text.Json;
namespace workoutTrackerServices.Operations
{
    public class BuildSetItemFromDictionary
    {
        private Dictionary<string,object> data;
        public BuildSetItemFromDictionary(Dictionary<string,object> data)
        {
            this.data=data;
            this.CleanUp();
        }
        public SetItem Execute()
        {
            SetItem set=new SetItem();

            set.Id=(int)this.data["id"];
            set.ExerciseName=(string)this.data["exerciseName"];
            set.MuscleGroup=(string)this.data["muscleGroup"];
            set.Weight=(float)this.data["weight"];
            set.Weight=(int)this.data["reps"];

            return set;
        }
        public void CleanUp()
        {
            if (this.data["id"] is JsonElement)
            {
                this.data["id"] = int.Parse(((JsonElement)this.data["id"]).ToString());
            }
            if (this.data["exerciseName"] is JsonElement)
            {
                this.data["exerciseName"] = ((JsonElement)this.data["exerciseName"]).ToString();
            }
            if (this.data["muscleGroup"] is JsonElement)
            {
                this.data["muscleGroup"] = ((JsonElement)this.data["muscleGroup"]).ToString();
            }
            if (this.data["weight"] is JsonElement)
            {
                this.data["weight"] = float.Parse(((JsonElement)this.data["weight"]).ToString());
            }
            if (this.data["reps"] is JsonElement)
            {
                this.data["reps"] = int.Parse(((JsonElement)this.data["reps"]).ToString());
            }
        }

    }
}