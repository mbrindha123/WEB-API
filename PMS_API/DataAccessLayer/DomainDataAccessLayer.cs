using Microsoft.EntityFrameworkCore;
namespace PMS_API.DataAccessLayer
{
    public class DomainDataAccessLayer:IDomainDataAccessLayer
    {
       private Context _db =DbContextDataFactory.GetDbContextObject();  
       private ILogger<DomainDataAccessLayer> _logger;
        
         public List<Domain> GetDomains() // List of Domains
        {
            try
            {
                return _db.Domains.ToList();
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