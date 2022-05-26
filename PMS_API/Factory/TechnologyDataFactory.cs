namespace PMS_API{
    public static class TechnologyDataFactory
    {
        public static ITechnologyDataAccessLayer GetTechnologyDataAccessLayerObject()
        {
            return new TechnologyDataAccessLayer();
        }
      
         public static Technology GetTechnologyObject()
        {
            return new Technology();
        }
       public static ITechnologyServices GetTechnologyServiceObject()
        {
        return new TechnologyServices();
        }
    }
}