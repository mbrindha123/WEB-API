using PMS_API.DataAccessLayer;
using System.Linq;
namespace PMS_API
{
    public class DesignationServices : IDesignationServices
    {
        private IDesignationDataAccessLayer _designationDataAccessLayer = DesignationDataFactory.GetDesignationDataAccessLayerObject();
        private Designation _designation = DesignationDataFactory.GetDesignationObject();
        private ILogger<DesignationServices>?_logger;
       
        

       
        public IEnumerable<Designation> ViewDesignations()
        {
            try
            {
                IEnumerable<Designation>designations = new List<Designation>();
                return designations = from designation in _designationDataAccessLayer.GetDesignations() where designation.IsActive == true select designation;
            }
            catch (Exception ex)
            {
                _logger.LogInformation($"{ex.Message}\n {ex.StackTrace}");
                 throw new Exception();
                
            }
        }

    }
}