using System.Text.RegularExpressions;
namespace workoutTrackerServices.Operations
{
    public class ValidateSetItems
    {   //build a regex for exerciseName, muscleGroup and decimal places regex for weight and int limit to reps
        private Dictionary<string, object> payload;
        public Dictionary<string, List<string>> Errors { get; private set; }
        Regex stringRegex = new Regex(@"^[a-zA-Z][a-zA-Z\s-]{2,25}$");
        Regex floatRegex = new Regex(@"^\d{0,3}(\.\d{0,2})?$");
        Regex intRegex = new Regex(@"^[0-9]{0,3}$");
        public ValidateSetItems(Dictionary<string, object> payload)
        {
            this.payload = payload;
            this.Errors = new Dictionary<string, List<string>>();
            Errors.Add("exerciseName", new List<string>());
            Errors.Add("muscleGroup", new List<string>());
            Errors.Add("weight", new List<string>());
            Errors.Add("reps", new List<string>());

        }
        public bool HasErrors()
        {
            bool ans = false;

            if (Errors["exerciseName"].Count > 0)
            {
                ans = true;
            }

            if (Errors["muscleGroup"].Count > 0)
            {
                ans = true;
            }
            if (Errors["weight"].Count > 0)
            {
                ans = true;
            }
            if (Errors["reps"].Count > 0)
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
            // Name validation
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
                Errors["muscleGroup"].Add("muscle group is invalid");
            }

            if (!payload.ContainsKey("weight"))
            {
                Errors["weight"].Add("weight is required");
            }
            else if (!floatRegex.IsMatch(payload["weight"].ToString()))
            {
                Errors["weight"].Add("weight is invalid");
            }

            else
            {
                try
                {
                    float weight = float.Parse(payload["weight"].ToString());
                    if (weight < 0)
                    {
                        Errors["weight"].Add("weight should not be negative");
                    }
                }
                catch (FormatException e)
                {
                    Errors["weight"].Add("invalid format for weight" + payload["weight"].ToString());
                }
            }

            if (!payload.ContainsKey("reps"))
            {
                Errors["reps"].Add("reps is required");
            }
            else if (!intRegex.IsMatch(payload["reps"].ToString()))
            {
                Errors["reps"].Add("reps is invalid");
            }
            else
            {
                try
                {
                    int reps = int.Parse(payload["reps"].ToString());
                    if (reps <= 0)
                    {
                        Errors["reps"].Add("reps should be positive");
                    }
                }
                catch (FormatException e)
                {
                    Errors["reps"].Add("invalid format for reps" + payload["reps"].ToString());
                }
            }
        }
    }
}