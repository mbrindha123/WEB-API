using PMS_API.DataAccessLayer;

namespace PMS_API{
    public static class CollegeDataFactory
    {
        public static ICollegeDataAccessLayer GetCollegeDataAccessLayerObject()
        {
            return new CollegeDataAccessLayer();
        }
      
         public static College GetCollegeObject()
        {
            return new College();
        }
       public static ICollegeServices GetCollegeServiceObject()
        {
        return new CollegeServices();
        }
    }
}