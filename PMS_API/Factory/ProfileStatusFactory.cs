using PMS_API.DataAccessLayer;

namespace PMS_API{
    public static class ProfileStatusDataFactory
    {
        public static IProfileStatusDataAccessLayer GetProfileStatusDataAccessLayerObject()
        {
            return new ProfileStatusDataAccessLayer();
        }
      
         public static ProfileStatus GetProfileStatusObject()
        {
            return new ProfileStatus();
        }
       public static IProfileStatusServices GetProfileStatusServiceObject()
        {
        return new ProfileStatusServices();
        }
    }
}