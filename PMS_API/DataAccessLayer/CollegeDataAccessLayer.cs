using Microsoft.EntityFrameworkCore;
namespace PMS_API.DataAccessLayer
{
    public class CollegeDataAccessLayer:ICollegeDataAccessLayer
    {
       private Context _db = DbContextDataFactory.GetDbContextObject();  
       private ILogger<CollegeDataAccessLayer> _logger;
        
         public List<College> GetColleges() //List Of Colleges
        {
            try
            {
                return _db.Colleges.ToList();
            }
            catch (DbUpdateException ex)              //DB Update Exception Occured
            {
                  _logger.LogInformation($"{ex.Message}\n {ex.StackTrace}");
                throw new DbUpdateException();
              
            }
            catch (OperationCanceledException ex)    //Operation cancelled exception
            {
                  _logger.LogInformation($"{ex.Message}\n {ex.StackTrace}");
                throw new OperationCanceledException();
              
            }
            catch (Exception ex)                      //unknown exception occured
            {
                _logger.LogInformation($"{ex.Message}\n {ex.StackTrace}");
                throw ex;
            }
        }


        
    }
}