namespace PMS_API
{
    public class ProfileDataFactory
    {
        public static Context GetProfileContext()
        {
            return new Context();
        }
        public static ProfileData GetProfileData(ILogger<PersonalService> logger)
        {
            return new ProfileData(GetProfileContext(),logger);
        }
    }
}