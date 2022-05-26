using Microsoft.AspNetCore.Mvc;
using System;
using System.Net;
namespace PMS_API
{
   [ApiController]
    [Route("[controller]/[Action]")]
    public class UserController:Controller{
        
        private IUserServices _userServices;
        private ILogger _logger;
        public UserController(IUserServices userServices,ILogger<UserController> logger)
        {
            _userServices=userServices;
            _logger=logger;
           
        }
        //Calling all users 
        [HttpGet]
        public IActionResult Getallusers(){
            try{
                
                return Ok(_userServices.GetallUsers());
            }
           catch(Exception exception){
               _logger.LogInformation($"UserController :GetAllUsers()- exception occured while fetching record{exception.Message}{exception.StackTrace}");
               return BadRequest(exception.Message);
           }
            
            
        }
        [HttpGet]
        public IActionResult GetUserById(int id)
        {
            try{
                
                return Ok(_userServices.GetUser(id));
            }
            catch(Exception exception){
                _logger.LogInformation($"UserController :GetUserById()- exception occured while fetching record{exception.Message}{exception.StackTrace}");
               return BadRequest(exception.Message);
            }
        }
        
        [HttpPost]
        public IActionResult AddUser(User user){
            if(user==null){
                _logger.LogInformation("UserController :AddUser()-user tries to enter null values");
                return BadRequest("User values not be null");
            }
            
               
            try{

                //Adding user via userservice
                return _userServices.AddUser(user)?Ok("User Added"):Problem("Sorry internal error occured");
                
                
            }
            catch(Exception exception){
                 _logger.LogInformation($"UserController :AddUser()-{exception.Message}{exception.StackTrace}");
                
                 return BadRequest(exception.Message);
            }
            
            

            
           
        }
         [HttpPut]
         
         public IActionResult UpdateUser(User user,int id){
             
             if(user==null){
                _logger.LogInformation("UserController :UpdateUser()-user tries to enter null values");
                return BadRequest("User values not be null");
            }
            
            //updating user via userservices
             
             try{
                 
                return _userServices.UpdateUser(user)? Ok("User Updated Successfully"):BadRequest("Sorry internal error occured");

            }
             
             catch(Exception exception){
                 _logger.LogInformation($"UserController:UpdateUser()-{exception.Message}{exception.StackTrace}");
                 return BadRequest(exception.Message);
             }
            
           
            
            
             
         } 
         [HttpDelete(Name="Disable")]
         public IActionResult Disable(int id){
             if (id == 0) return BadRequest("User is required");
            try{
                
                return _userServices.Disable(id)?Ok("User Disabled Successfully"):BadRequest("Sorry internal error occured");
            }
             
             catch(Exception exception){
                 _logger.LogInformation($"UserController:DisableUser()-{exception.Message}{exception.StackTrace}");
                 return BadRequest(exception.StackTrace);
             }
        }
       
        

    }
}
