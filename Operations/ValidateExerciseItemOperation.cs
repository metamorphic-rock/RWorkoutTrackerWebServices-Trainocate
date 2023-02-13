using System.Text.RegularExpressions;
namespace workoutTrackerServices.Operations
{
    public class ValidateExerciseItems
    {
        private Dictionary<string, object> payload;
        public Dictionary<string, List<string>> Errors { get; private set; }
        Regex stringRegex = new Regex(@"^[a-zA-Z][a-zA-Z\s-]{2,25}$");
        public ValidateExerciseItems(Dictionary<string, object> payload)
        {
            this.payload = payload;
            this.Errors = new Dictionary<string, List<string>>();
            Errors.Add("exerciseName", new List<string>());
            Errors.Add("muscleGroup",new List<string>());
        }
        public bool HasErrors()
        {
            bool ans = false;

            if (Errors["exerciseName"].Count > 0)
            {
                ans = true;
            }
            return ans;
        }
        public bool HasNoErrors()
        {
            return !HasErrors();
        }
        public void Execute()
        {
            if (payload.ContainsKey("id"))
            {
                int id = int.Parse(payload["id"].ToString());
            }
            if (!payload.ContainsKey("exerciseName"))
            {
                Errors["exerciseName"].Add("exercise name is required");
            }
            else if (!stringRegex.IsMatch(payload["exerciseName"].ToString()))
            {
                Errors["exerciseName"].Add("exercise name is invalid");
            }


            if (!payload.ContainsKey("muscleGroup"))
            {
                Errors["muscleGroup"].Add("muscle group is required");
            }
            else if (!stringRegex.IsMatch(payload["muscleGroup"].ToString()))
            {
                Errors["muscleGroup"].Add("exercise group is invalid");
            }
        }      
    }
}