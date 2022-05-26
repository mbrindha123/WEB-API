namespace PMS_API
{
    public class TechnologyServices : ITechnologyServices
    {
        private ITechnologyDataAccessLayer _TechnologyDataAccessLayer = TechnologyDataFactory.GetTechnologyDataAccessLayerObject();
        private Technology _Technology = TechnologyDataFactory.GetTechnologyObject();
        private ILogger<TechnologyServices>?_logger;
       
        

       
        public IEnumerable<Technology> ViewTechnologies()
        {
            try
            {
                IEnumerable<Technology>technologys = new List<Technology>();
                return technologys = from technology in _TechnologyDataAccessLayer.GetTechnologies() where technology.IsActive == true select technology;
            }
            catch (Exception ex)
            {
                _logger.LogInformation($"{ex.Message}\n {ex.StackTrace}");
                 throw new Exception();
                
            }
        }

    }
}