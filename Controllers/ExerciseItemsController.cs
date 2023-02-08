using Microsoft.AspNetCore.Mvc;
using workoutTrackerServices.Models;
using workoutTrackerServices.Operations;
using System.Text.Json;
using workoutTrackerServices.Interfaces;

namespace workoutTrackerServices.Controllers
{
    [ApiController]
    [Route("exercise_items")]
    public class ExerciseItemController: ControllerBase
    {
        private readonly IExerciseItemServices _exerciseItemService;
        public ExerciseItemController(IExerciseItemServices exerciseItemServices)
        {
            _exerciseItemService=exerciseItemServices;
        }
        [HttpGet("")]
        public IActionResult Index()
        {
            Dictionary<string, List<ExerciseItem>> exerciseList = new Dictionary<string, List<ExerciseItem>>();
            exerciseList.Add("Exercises", _exerciseItemService.GetAll());
            return Ok(exerciseList);
        }
        [HttpGet("{id}")]
        public IActionResult Show(int id)
        {
            var exercise =_exerciseItemService.FindById(id);
            return Ok(exercise);
        }
        [HttpPost("")]
        public IActionResult Save([FromBody] object payload)
        {
             Dictionary<string, object> hash = JsonSerializer.Deserialize<Dictionary<string, object>>(payload.ToString());
            ValidateExerciseItems validator = new ValidateExerciseItems(hash);
            validator.Execute();
            if (validator.HasErrors())
            {
                return UnprocessableEntity(validator.Errors);
            }
            else
            {
                BuildExerciseItemFromDictionary builder = new BuildExerciseItemFromDictionary(hash);
                ExerciseItem exercise = builder.Execute();
                _exerciseItemService.Save(exercise);
                Console.WriteLine(exercise.ExerciseName);
                Dictionary<string, object> message = new Dictionary<string, object>();
                message.Add("message", "Ok, added an exercise");
                return Ok(message);
            }
        }
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            ExerciseItem exercise = _exerciseItemService.Delete(id);
            if (exercise == null)
            {
                return Ok("That exercise is not found");
            }
            return Ok("Exercise deleted");
        }
    }
}

