namespace PMS_API{
    public interface ITechnologyServices
    {
        // public  bool CreateCollege(string collegeName);
        // public bool RemoveCollege(int collegeId);
        public IEnumerable<Technology> ViewTechnologies();

    }
}