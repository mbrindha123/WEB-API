using PMS_API.DataAccessLayer;

using System.Linq;
namespace PMS_API
{
    public class DomainServices : IDomainServices
    {
        private IDomainDataAccessLayer _domainDataAccessLayer = DomainDataFactory.GetDomainDataAccessLayerObject();
        private Domain _domain = DomainDataFactory.GetDomainObject();
        private ILogger<DomainServices>?_logger;
       
        

       
        public IEnumerable<Domain> ViewDomains()
        {
            try
            {
                IEnumerable<Domain> domains = new List<Domain>();
                return domains = from domain in _domainDataAccessLayer.GetDomains() where domain.IsActive == true select domain;
            }
            catch (Exception ex)
            {
                _logger.LogInformation($"{ex.Message}\n {ex.StackTrace}");
                 throw new Exception();
                
            }
        }

    }
}