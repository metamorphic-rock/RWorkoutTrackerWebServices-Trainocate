using System.Linq;
using System.Text.RegularExpressions;
namespace workoutTrackerServices.Operations;
public class ValidateWorkoutItems
{
    private Dictionary<string, object> payload;
    public Dictionary<string, List<string>> Errors { get; private set; }
    Regex stringRegex = new Regex(@"^[a-zA-Z][a-zA-Z\s-]{2,25}$");
    Regex dateRegex = new Regex(@"^20[2-3][3-9]/0[1-9]|1[0-2]/0[1-9]|[12][0-9]|3[01]$");
    public ValidateWorkoutItems(Dictionary<string, object> payload)
    {
        this.payload = payload;
        this.Errors = new Dictionary<string, List<string>>();
        Errors.Add("workoutTitle", new List<string>());
        Errors.Add("date",new List<string>());
    }
    public bool HasErrors()
    {
        bool ans = false;

        if (Errors["workoutTitle"].Count > 0)
        {
            ans = true;
        }
        if (Errors["date"].Count > 0)
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
        if (!payload.ContainsKey("workoutTitle"))
        {
            Errors["workoutTitle"].Add("workout title is required");
        }
        else if (!stringRegex.IsMatch(payload["workoutTitle"].ToString()))
        {
            Errors["workoutTitle"].Add("workout title is invalid");
        }
        if (!payload.ContainsKey("date"))
        {
            Errors["date"].Add("Date is required");
        }
        else if (!dateRegex.IsMatch((payload["date"]).ToString()))
        {
            Errors["date"].Add("date format is invalid");
        }
    }
}
