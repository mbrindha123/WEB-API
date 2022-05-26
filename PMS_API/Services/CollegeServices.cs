using PMS_API.DataAccessLayer;
using System.Linq;
namespace PMS_API
{
    public class CollegeServices : ICollegeServices
    {
        private ICollegeDataAccessLayer _collegeDataAccessLayer = CollegeDataFactory.GetCollegeDataAccessLayerObject();
        private College _college = CollegeDataFactory.GetCollegeObject();
        private ILogger<CollegeServices>?_logger;
       
        

       
        public IEnumerable<College> ViewColleges() //Getting List of Colleges
        {
            try
            {
                IEnumerable<College> colleges = new List<College>();
                return colleges = from college in _collegeDataAccessLayer.GetColleges() where college.IsActive == true select college; 
            }
            catch (Exception ex)
            {
                _logger.LogInformation($"{ex.Message}\n {ex.StackTrace}");
                 throw new Exception();
                
            }
        }

    }
}