using PROFILE.DataAccessLayer;
namespace PROFILE.DataFactory{
    public static class DbContextDataFactory{
        public static CollegeContext GetDbContextObject()
        {
            return new CollegeContext();
        }
    }
}