namespace PMS_API{
    public interface IDomainServices
    {
        // public  bool CreateCollege(string collegeName);
        // public bool RemoveCollege(int collegeId);
        public IEnumerable<Domain> ViewDomains();

    }
}