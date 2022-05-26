namespace PMS_API{
    public interface IDesignationServices
    {
        // public  bool CreateCollege(string collegeName);
        // public bool RemoveCollege(int collegeId);
        public IEnumerable<Designation> ViewDesignations();

    }
}