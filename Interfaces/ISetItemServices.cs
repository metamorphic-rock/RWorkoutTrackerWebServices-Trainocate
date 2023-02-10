using workoutTrackerServices.Models;
namespace workoutTrackerServices.Interfaces
{
    public interface ISetItemsService
    {
        public List<SetItem> GetAll();
        public SetItem Save(SetItem set);
        public SetItem? FindById(int id);
        public SetItem GetLastAdded();
        public SetItem? Delete(int id);
    }
}