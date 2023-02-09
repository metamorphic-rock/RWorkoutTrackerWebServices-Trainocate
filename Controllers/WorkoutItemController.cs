using Microsoft.AspNetCore.Mvc;
using workoutTrackerServices.Models;
using workoutTrackerServices.Operations;
using System.Text.Json;
using workoutTrackerServices.Interfaces;

namespace workoutTrackerServices.Controllers
{
    namespace workoutTrackerServices.Controllers
    {
        [ApiController]
        [Route("workout_items")]
        public class WorkoutItemController : ControllerBase
        {
            private readonly IWorkoutItemServices _workoutItemServices;
            public WorkoutItemController(IWorkoutItemServices workoutItemServices)
            {
                _workoutItemServices = workoutItemServices;
            }
            [HttpGet("")]
            public IActionResult Index()
            {
                List<WorkoutItem> workoutList =_workoutItemServices.GetAll();
                return Ok(workoutList);
            }
            public IActionResult Show(int id)
            {
                var workout = _workoutItemServices.FindById(id);
                return Ok(workout);
            }
            [HttpPost("")]
            public IActionResult Save([FromBody] object payload)
            {
                Dictionary<string, object> hash = JsonSerializer.Deserialize<Dictionary<string, object>>(payload.ToString());
                ValidateWorkoutItems validator = new ValidateWorkoutItems(hash);
                validator.Execute();
                if (validator.HasErrors())
                {
                    return UnprocessableEntity(validator.Errors);
                }
                else
                {
                    BuildWorkoutItemFromDictionary builder = new BuildWorkoutItemFromDictionary(hash);
                    WorkoutItem workout = builder.Execute();
                    _workoutItemServices.Save(workout);
                    Console.WriteLine(workout.WorkoutTitle);
                    Dictionary<string, object> message = new Dictionary<string, object>();
                    message.Add("message", "Ok, added an workout");
                    return Ok(message);
                }
            }
            [HttpDelete("{id}")]
            public IActionResult Delete(int id)
            {
                WorkoutItem workout = _workoutItemServices.Delete(id);
                if (workout == null)
                {
                    return Ok("That exercise is not found");
                }
                return Ok("Workout deleted");
            }
        }
    }
}
