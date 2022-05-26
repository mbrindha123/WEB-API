using PMS_API.DataAccessLayer;

namespace PMS_API{
    public static class DesignationDataFactory
    {
        public static IDesignationDataAccessLayer GetDesignationDataAccessLayerObject()
        {
            return new DesignationDataAccessLayer();
        }
      
         public static Designation GetDesignationObject()
        {
            return new Designation();
        }
       public static IDesignationServices GetDesignationServiceObject()
        {
        return new DesignationServices();
        }
    }
}