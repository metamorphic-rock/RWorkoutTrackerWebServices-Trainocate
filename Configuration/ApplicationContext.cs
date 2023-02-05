using workoutTrackerServices.Models;
namespace workoutTrackerServices.Configuration
{
    public class ApplicationContext
    {
        private List<SetItem> SetList;
        private static ApplicationContext instance = null;

        public static ApplicationContext Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new ApplicationContext();
                }
                return instance;
            }
        }
        public ApplicationContext()
        {   
            this.SetList=new List<SetItem>();
        }
        public List<SetItem> GetSetItems()
        {
            return this.SetList;
        }
    }
}
