using workoutTrackerServices.Models;
using workoutTrackerServices.Configuration;
using workoutTrackerServices.Interfaces;

namespace workoutTrackerServices.Services
{
    public class SetItemServicesApplicationContext : ISetItemsService
    {
        private ApplicationContext Context;
        private List<SetItem> setList;
        public SetItemServicesApplicationContext()
        {
            Context=ApplicationContext.Instance;
            setList=Context.GetSetItems();
        }
        public List<SetItem> GetAll()
        {
            return setList;
        }
        public SetItem Save(SetItem set)
        {   
            setList.Add(set);
            return set;
        }
        public SetItem? FindById(int id)
        {
            var set = setList.Find(s =>s.Id == id);
            if(set != null){
                return set;
            }
            return null;
            
        }

        public SetItem? Delete(int id)
        {
            var set = setList.Find(s =>s.Id == id);
            if(set!=null){
                setList.Remove(set);
                return set;
            } 
            return null;    
        }
    }//regex in integer only in decimal palces
}