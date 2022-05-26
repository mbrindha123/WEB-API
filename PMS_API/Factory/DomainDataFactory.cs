
using PMS_API.DataAccessLayer;

namespace PMS_API{
    public static class DomainDataFactory
    {
        public static IDomainDataAccessLayer GetDomainDataAccessLayerObject()
        {
            return new DomainDataAccessLayer();
        }
      
         public static Domain GetDomainObject()
        {
            return new Domain();
        }
       public static IDomainServices GetDomainServiceObject()
        {
        return new DomainServices();
        }
    }
}