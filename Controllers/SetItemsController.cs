using Microsoft.AspNetCore.Mvc;
using workoutTrackerServices.Models;
using workoutTrackerServices.Operations;
using workoutTrackerServices.Interfaces;
using System.Text.Json;

namespace workoutTrackerServices.AddControllers
{
    [ApiController]
    [Route("set_items")]
    public class SetItemController : ControllerBase
    {

        private readonly ISetItemsService _setItemService;
        //Requirements: Endpoint to return all set items
        // URL: Get /set_items
        public SetItemController(ISetItemsService setItemsService)
        {
            _setItemService = setItemsService;
        }


        [HttpGet("")]

        public IActionResult Index()

        {
            Dictionary<string, List<SetItem>> setList = new Dictionary<string, List<SetItem>>();
            setList.Add("Sets", _setItemService.GetAll());
            return Ok(setList); //use jsonserializer if you want to concatenate a string and setList
        }

        //Requirement: Endpoint to return a single set item based on id
        // URL: Get /set_items/{id}<-- Path Parameter
        [HttpGet("{id}")]
        public IActionResult Show(int id)
        {
            var set = _setItemService.FindById(id);
            return Ok(set);
        }

        [HttpPost("")]
        public IActionResult Save([FromBody] object payload)
        {
            Dictionary<string, object> hash = JsonSerializer.Deserialize<Dictionary<string, object>>(payload.ToString());
            ValidateSetItems validator = new ValidateSetItems(hash);
            validator.Execute();
            if (validator.HasErrors())
            {
                return UnprocessableEntity(validator.Errors);
            }
            else
            {
                BuildSetItemFromDictionary builder = new BuildSetItemFromDictionary(hash);
                SetItem set = builder.Execute();
                _setItemService.Save(set);
                Console.WriteLine(set.ExerciseName);
                Dictionary<string, object> message = new Dictionary<string, object>();
                message.Add("message", "Ok,Added a set");
                return Ok(message);
            }

        }
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            SetItem set = _setItemService.Delete(id);
            if (set == null)
            {
                return Ok("That set is not found");
            }
            return Ok("Set deleted");
        }

    }
}