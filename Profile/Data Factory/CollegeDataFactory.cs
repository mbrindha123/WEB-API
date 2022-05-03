using PROFILE.DataAccessLayer;
using PROFILE.Models;
using PROFILE.Services;
namespace PROFILE.DataFactory{
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