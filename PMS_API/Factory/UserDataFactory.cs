namespace PMS_API
{
    public class UserDataFactory{
        public static Context Getusercontext(){
            return new Context();
        }
        public static UserData GetUserObject(ILogger<UserServices> logger){
            return new UserData(Getusercontext(),logger);
        }
        public static User GetUserModelObject(){
            return new User();
        }
        public static UserValidation GetValidationObject(){
            return new UserValidation();
        }
        
    }
}