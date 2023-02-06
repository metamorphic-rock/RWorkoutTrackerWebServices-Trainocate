using workoutTrackerServices.Models;
namespace workoutTrackerServices.Interface
{
    public interface ISetItemsService
    {
        public List<SetItem> GetAll();
        public SetItem Save(SetItem set);
        public SetItem? FindById(int id);
        public SetItem? Delete(int id);
    }
}