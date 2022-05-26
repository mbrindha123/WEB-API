namespace PMS_API{
    public interface IProfileStatusServices
    {
        // public  bool CreateCollege(string collegeName);
        // public bool RemoveCollege(int collegeId);
        public IEnumerable<ProfileStatus> ViewProfileStatuss();

    }
}