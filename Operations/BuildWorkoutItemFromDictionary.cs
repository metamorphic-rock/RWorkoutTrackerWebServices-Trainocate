using System.Text.Json;
using workoutTrackerServices.Models;
namespace workoutTrackerServices.Operations;
public class BuildWorkoutItemFromDictionary
{
    private Dictionary<string, object> data;
    public BuildWorkoutItemFromDictionary(Dictionary<string, object> data)
    {
        this.data = data;
        this.CleanUp();
    }
    public WorkoutItem Execute()
    {
        WorkoutItem workout = new WorkoutItem();
        if (this.data.ContainsKey("id"))
        {
            workout.Id = (int)this.data["id"];
        }
        workout.WorkoutTitle = (string)this.data["workoutTitle"];
        workout.Date = (DateTime)(this.data["date"]); //Check this later

        return workout;
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
        if (this.data["workoutTitle"] is JsonElement)
        {
            this.data["workoutTitle"] = ((JsonElement)this.data["workoutTitle"]).ToString();
        }
        if (this.data["date"] is JsonElement)
        {
            this.data["date"] = DateTime.Parse(((JsonElement)this.data["date"]).ToString());
        }
    }
}