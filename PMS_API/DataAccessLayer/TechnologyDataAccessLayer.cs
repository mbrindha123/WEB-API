using Microsoft.EntityFrameworkCore;
namespace PMS_API
{
    public class TechnologyDataAccessLayer:ITechnologyDataAccessLayer
    {
       private Context _db = DbContextDataFactory.GetDbContextObject();  
       private ILogger<TechnologyDataAccessLayer> _logger;
        
         public List<Technology> GetTechnologies() // List of Technologies
        {
            try
            {
                return _db.Technologies.ToList();
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