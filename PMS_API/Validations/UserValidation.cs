using System.ComponentModel.DataAnnotations;
using System.Text.RegularExpressions;

namespace PMS_API
{
    public class UserValidation
    {
        public bool userValidate(User user){
            if(string.IsNullOrEmpty(user.Name))
                throw new ValidationException($"UserName not be null and user supplied name is {user.Name}");
            if(!Regex.IsMatch(user.Name, @"^(?!.*([ ])\1)(?!.*([A-Za-z])\2{2})\w[a-zA-Z\s]*$"))
                throw new ValidationException($"Name must not contain any special character or numbers or no more repeated character more than 2times and user supplied name is {user.Name}");
            if(user.Name.Length<4)
                throw new ValidationException($"Length cannot less than 4 and user supplied name is {user.Name}");
            if(user.Name.Length>30)
                throw new ValidationException($"Length cannot greater than 30 and user supplied name is {user.Name}");
            if(string.IsNullOrEmpty(user.Email))
                throw new ValidationException($"Email not be null and user supplied Email is {user.Email}");
            if(!Regex.IsMatch(user.Email,@"^([0-9a-zA-Z.]){3,}@[a-zA-z]{3,}(.[a-zA-Z]{2,}[a-zA-Z]*){0,}$"))
                throw new ValidationException($"Enter valid Email address and user supplied Email is {user.Email}");
            if(string.IsNullOrEmpty(user.UserName))
                throw new ValidationException($"UserName not be null and user supplied UserName is {user.UserName}");
            if(!Regex.IsMatch(user.UserName, @"^[A-z][A-z|\.|\s]+$"))
                throw new ValidationException($"Enter valid UserName and user supplied UserName is {user.UserName}");
            if(string.IsNullOrEmpty(user.Password))
                throw new ValidationException($"Password not be null and user supplied Password is {user.Password}");
            if(!Regex.IsMatch(user.Password, @"^(?=.*[A-Za-z])(?=.*\d)(?=.*[@$!%*#?&])[A-Za-z\d@$!%*#?&]{8,}$"))
                throw new ValidationException($"Enter a valid Password. Password must contain Minimum eight characters, at least one letter, one number and one special character and user supplied Password is {user.Password}");
            // if(string.IsNullOrEmpty(user.Gender))
            //     throw new ValidationException($"Gender not be null and user supplied Gender is{user.Gender}");
            if(string.IsNullOrEmpty(user.MobileNumber))
                throw new ValidationException($"Mobile Number not be null and user supplied Mobile number is {user.MobileNumber}");
            if(!Regex.IsMatch(user.MobileNumber,@"^(\+\d{1,3}[- ]?)?\d{10}$"))
                throw new ValidationException($"Enter a valid Mobile number and user supplied Mobile number is  {user.MobileNumber}");
            // if(user.OrganisationName==0)
            //     throw new ValidationException($"Organization not be null and user supplied Organization is {user.OrganisationId}");
            // if(user.DesignationId==0)
            //     throw new ValidationException($"Designation not be null and user supplied Designation is {user.DesignationId}");
            if(string.IsNullOrEmpty(user.ReportingPerson))
                throw new ValidationException($"Reporting_Person not be null and user supplied Reporting_Person is {user.ReportingPerson}");
            return true;

        }
    }
}