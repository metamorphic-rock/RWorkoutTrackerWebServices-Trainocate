using workoutTrackerServices.Models;
namespace workoutTrackerServices.Interface
{
    public interface ISetItemsService
    {
        public List<SetItem> GetAll();
        public SetItem Save(SetItem set);
        public SetItem? Find(int id);
        public SetItem? Delete(int id);
    }
}