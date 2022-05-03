using PROFILE.Models;
using PROFILE.DataAccessLayer;
using PROFILE.DataFactory;
using System.Linq;
namespace PROFILE.Services
{
    public class CollegeServices : ICollegeServices
    {
        private ICollegeDataAccessLayer _collegeDataAccessLayer = DataFactory.CollegeDataFactory.GetCollegeDataAccessLayerObject();
        private College _college = DataFactory.CollegeDataFactory.GetCollegeObject();

        /*  
            Returns False when Exception occured in Data Access Layer
            
            Throws ArgumentNullException when Role Name is not passed to this service method
        */
        public bool CreateCollege(string collegeName)
        {
            if (collegeName == null)
                throw new ArgumentNullException("College Name is not provided");

            try
            {
                _college.CollegeName = collegeName;
                return _collegeDataAccessLayer.AddCollege(_college) ? true : false; // LOG Error in DAL;
            }
            catch (Exception)
            {
                // Log "Exception Occured in Data Access Layer"
                return false;
            }
        }

        /*  
            Returns False when Exception occured in Data Access Layer
            
            Throws ArgumentNullException when Role Id is not passed to this service method
        */

        public bool RemoveCollege(int collegeId)
        {
            if (collegeId == null)
                throw new ArgumentNullException("College Id is not provided");

            try
            {
                return _collegeDataAccessLayer.RemoveCollege(collegeId) ? true :false; // LOG Error in DAL;
            }
            catch (Exception)
            {
                // Log "Exception Occured in Data Access Layer"
                return false;
            }
        }

        /*  
            Throws Exception when Exception occured in DAL while fetching roles
        */
        public IEnumerable<College> ViewColleges()
        {
            try
            {
                IEnumerable<College> colleges = new List<College>();
                return colleges = from college in _collegeDataAccessLayer.GetColleges() where college.IsActive == true select college;
            }
            catch (Exception)
            {
                //Log "Exception occured in DAL while fetching roles"
                throw new Exception();
            }
        }

    }
}