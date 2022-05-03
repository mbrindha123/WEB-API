using PROFILE.Models;
namespace PROFILE.DataAccessLayer
{
    public interface ICollegeDataAccessLayer
    
    {
        public bool AddCollege(College college);
        public bool RemoveCollege(int collegeId);
        public List<College> GetColleges();
    }
}