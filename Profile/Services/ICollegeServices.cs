using PROFILE.Models;

namespace PROFILE.Services{
    public interface ICollegeServices
    {
        public  bool CreateCollege(string collegeName);
        public bool RemoveCollege(int collegeId);
        public IEnumerable<College> ViewColleges();

    }
}