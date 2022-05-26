using Microsoft.AspNetCore.Mvc;
namespace PMS_API
{
    [ApiController]
    [Route("[controller]/[Action]")]
    public class PersonalServiceController : Controller
    {
        private IPersonalService _personalService;
        private ILogger _logger;
        public PersonalServiceController(IPersonalService personalService, ILogger<PersonalServiceController> logger)
        {
            _personalService = personalService;
            _logger = logger;
        }
        [HttpPost]
        public IActionResult AddProfile(Profile profile)
        {
            if (profile == null)
            {
                _logger.LogError("PersonalServiceController:AddProfile():User tries to enter null values");
                return BadRequest("PersonalDetails not be null");
            }
            try
            {
                return _personalService.AddProfile(profile) ? Ok("Profile added") : Problem("Some internal Error occured");
            }
            catch (Exception exception)
            {
                _logger.LogInformation($"PersonalServiceControllerController :AddProfile()-{exception.Message}{exception.StackTrace}");

                return BadRequest(exception.Message);
            }
        }
        
        [HttpPost]
        public IActionResult AddPersonalDetail(PersonalDetails personalDetails)
        {
            if (User == null)
            {
                _logger.LogError("PersonalServiceController:AddPersonalDetail():User tries to enter null values");
                return BadRequest("PersonalDetails not be null");
            }
            try
            {
                return _personalService.AddPersonalDetail(personalDetails) ? Ok("PersonalDetails added") : Problem("Some internal Error occured");
            }
            catch (Exception exception)
            {
                _logger.LogInformation($"PersonalServiceControllerController :AddPersonalDetail()-{exception.Message}{exception.StackTrace}");

                return BadRequest(exception.Message);
            }
        }
        [HttpGet]
        public IActionResult GetallPersonalDetails()
        {
            try
            {

                return Ok(_personalService.GetAllPersonalDetails());
            }
            catch (Exception exception)
            {
                _logger.LogInformation($"UserController :GetAllPersonalDetails()- exception occured while fetching record{exception.Message}{exception.StackTrace}");
                return BadRequest(exception.Message);
            }


        }
        [HttpGet]
        public IActionResult GetPersonalDetailsById(int Profileid)
        {
            try{
                
                return Ok(_personalService.GetPersonalDetailsById(Profileid));
            }
            catch(Exception exception){
                _logger.LogInformation($"PersonalServiceController :GetPersonalDetailsById()- exception occured while fetching record{exception.Message}{exception.StackTrace}");
               return BadRequest(exception.Message);
            }
        }

      
        [HttpPut]
        public IActionResult UpdatePersonalDetail(PersonalDetails personalDetails)

        {

            if (personalDetails == null)
            {
                _logger.LogInformation("PersonalServiceController :UpdatePersonalDetails()-Profile's personaldetails should not be null values");
                return BadRequest("Profile's personaldetails should not be null");
            }

            //updating user via userservices

            try
            {

                return _personalService.UpdatePersonalDetail(personalDetails) ? Ok("PersonalDetails Updated Successfully") : BadRequest("Sorry internal error occured");

            }

            catch (Exception exception)
            {
                _logger.LogInformation($"PersonalServiceController:UpdatePersonalDetail()-{exception.Message}{exception.StackTrace}");
                return BadRequest(exception.Message);
            }
        }

        [HttpDelete]
        public IActionResult DisablePersonalDetails(int PersonalDetails_Id)
        {
            if (PersonalDetails_Id == 0)
                return BadRequest("PersonalDetails_Id can't be null");


            try
            {
                return _personalService.DisablePersonalDetails(PersonalDetails_Id) ? Ok("PersonalDetails_ Removed Successfully") : Problem("Sorry internal error occured");
            }

            catch (Exception exception)
            {
                _logger.LogInformation($"PersonalService : DisablePersonalDetails throwed an exception : {exception}");
                return BadRequest("Sorry some internal error occured");
            }

        }
        [HttpPost]
        public IActionResult AddEducation(Education education)
        {
            if (education == null)
            {
                _logger.LogError("PersonalServiceController:AddEducation():user tries to enter null values");
                return BadRequest("Education details not be null");
            }
            try
            {
                return _personalService.AddEducation(education) ? Ok("Education details added") : Problem("Some internal Error occured");
            }
            catch (Exception exception)
            {
                _logger.LogInformation($"PersonalServiceController :AddEducation()-{exception.Message}{exception.StackTrace}");

                return BadRequest(exception.Message);
            }


        }
        [HttpGet]
        public IActionResult GetallEducationDetails()
        {
            try
            {

                return Ok(_personalService.GetallEducationDetails());
            }
            catch (Exception exception)
            {
                _logger.LogInformation($"PersonalServiceController :GetallEducationDetails()- exception occured while fetching record{exception.Message}{exception.StackTrace}");
                return BadRequest(exception.Message);
            }


        }
        [HttpGet]
        public IActionResult GetEducationDetailsById(int Educationid)
        {
            try{
                
                return Ok(_personalService.GetEducationDetailsById(Educationid));
            }
            catch(Exception exception){
                _logger.LogInformation($"PersonalServiceController :GetEducationById()- exception occured while fetching record{exception.Message}{exception.StackTrace}");
               return BadRequest(exception.Message);
            }
        }
        [HttpPut]
        public IActionResult UpdateEducation(Education education)

        {

            if (education == null)
            {
                _logger.LogInformation("PersonalServiceController :UpdateEducation()-Profile's Eucationdetails should not enter null values");
                return BadRequest("Educationdetails shhould not be null");
            }

            //updating user via userservices

            try
            {

                return _personalService.UpdateEducation(education) ? Ok("Education Updated Successfully") : BadRequest("Sorry internal error occured");

            }

            catch (Exception exception)
            {
                _logger.LogInformation($"PersonalServiceController:UpdateEducation()-{exception.Message}{exception.StackTrace}");
                return BadRequest(exception.Message);
            }
        }
        [HttpDelete]
        public IActionResult DisableEducationalDetails(int EducationId)
        {
            if (EducationId == 0)
                return BadRequest("Education_Id can't be null");


            try
            {
                return _personalService.DisableEducationalDetails(EducationId) ? Ok("Education_ Removed Successfully") : Problem("Sorry internal error occured");
            }

            catch (Exception exception)
            {
                _logger.LogInformation($"PersonalService : DisableEducationalDetails throwed an exception : {exception}");
                return BadRequest("Sorry some internal error occured");
            }

        }
        [HttpPost]
        public IActionResult AddProjects(Projects projects)
        {
            if (projects == null)
            {
                _logger.LogError("PersonalServiceController:AddProjects():user tries to enter null values");
                return BadRequest("Education details not be null");
            }
            try
            {
                return _personalService.AddProjects(projects) ? Ok("project details added") : Problem("Some internal Error occured");
            }
            catch (Exception exception)
            {
                _logger.LogInformation($"PersonalServiceControllerController :AddProjects()-{exception.Message}{exception.StackTrace}");

                return BadRequest(exception.Message);
            }

        }


        [HttpGet]
        public IActionResult GetallProjectDetails()
        {
            try
            {

                return Ok(_personalService.GetallProjectDetails());
            }
            catch (Exception exception)
            {
                _logger.LogInformation($"PersonalServiceController :GetallProjectDetails()- exception occured while fetching record{exception.Message}{exception.StackTrace}");
                return BadRequest(exception.Message);
            }


        }
        [HttpGet]
        public IActionResult GetProjectDetailsById(int Projectid)
        {
            try{
                
                return Ok(_personalService.GetProjectDetailsById(Projectid));
            }
            catch(Exception exception){
                _logger.LogInformation($"PersonalServiceController :GetallProjectDetails()- exception occured while fetching record{exception.Message}{exception.StackTrace}");
               return BadRequest(exception.Message);
            }
        }
        
        [HttpPut]
        public IActionResult UpdateProjects(Projects projects)

        {

            if (projects == null)
            {
                _logger.LogInformation("PersonalServiceController :UpdateProjects()-Profile's Projects should not be null");
                return BadRequest("project values not be null");
            }

            //updating user via userservices

            try
            {

                return _personalService.UpdateProjects(projects) ? Ok("Projects Updated Successfully") : BadRequest("Sorry internal error occured");

            }

            catch (Exception exception)
            {
                // _logger.LogInformation($"UserController:UpdateUser()-{exception.Message}{exception.StackTrace}");
                return BadRequest(exception.Message);
            }
        }
        [HttpDelete]
        public IActionResult DisableProjectDetails(int Projects_Id)
        {
            if (Projects_Id == 0)
                return BadRequest("Projects_Id can't be null");


            try
            {
                return _personalService.DisableProjectDetails(Projects_Id) ? Ok("Projects_ Removed Successfully") : Problem("Sorry internal error occured");
            }

            catch (Exception exception)
            {
                _logger.LogInformation($"PersonalService : DisableProjectDetails throwed an exception : {exception}");
                return BadRequest("Sorry some internal error occured");
            }

        }
         [HttpPost]
        public IActionResult AddSkills(Skills skill)
        {
            if (skill == null)
            {
                _logger.LogError("PersonalServiceController:AddSkills():user tries to enter null values");
                return BadRequest("Education details not be null");
            }
            try
            {
                return _personalService.AddSkills(skill) ? Ok("Skill details added") : Problem("Some internal Error occured");
            }
            catch (Exception exception)
            {
                _logger.LogInformation($"PersonalServiceControllerController :AddSkills()-{exception.Message}{exception.StackTrace}");

                return BadRequest(exception.Message);
            }

        }
        [HttpGet]
        public IActionResult GetallSkillDetails()
        {
            try
            {

                return Ok(_personalService.GetallSkillDetails());
            }
            catch (Exception exception)
            {
                _logger.LogInformation($"PersonalServiceController : GetallSkillDetails()- exception occured while fetching record{exception.Message}{exception.StackTrace}");
                return BadRequest(exception.Message);
            }


        }
        [HttpGet]
        public IActionResult GetSkillDetailsById(int Skillid,int Technologyid)
        {
            try{
                
                return Ok(_personalService.GetSkillDetailsById(Skillid,Technologyid));
            }
            catch(Exception exception){
                _logger.LogInformation($"PersonalServiceController : GetallSkillDetails()- exception occured while fetching record{exception.Message}{exception.StackTrace}");
               return BadRequest(exception.Message);
            }
        }
       
        [HttpPut]
        public IActionResult UpdateSkills(Skills skill)

        {

            if (skill == null)
            {
                _logger.LogInformation("PersonalServiceController :UpdateSkills()-Profiles Skill values not be null");
                return BadRequest("Skills values not be null");
            }

            //updating user via userservices

            try
            {

                return _personalService.UpdateSkills(skill) ? Ok("Skills Updated Successfully") : BadRequest("Sorry internal error occured");

            }

            catch (Exception exception)
            {
                _logger.LogInformation($"PersonalServicesController:UpdateSkills()-{exception.Message}{exception.StackTrace}");
                return BadRequest(exception.Message);
            }
        }
        [HttpDelete]
        public IActionResult DisableSkillDetails(int Skill_Id)
        {
            if (Skill_Id == 0)
                return BadRequest("Skill_Id can't be null");


            try
            {
                return _personalService.DisableSkillDetails(Skill_Id) ? Ok("Skills_ Removed Successfully") : Problem("Sorry internal error occured");
            }

            catch (Exception exception)
            {
                _logger.LogInformation($"Skills_ Service : DisableSkillDetails throwed an exception : {exception}");
                return BadRequest("Sorry some internal error occured");
            }

        }
        [HttpPost]
        public IActionResult AddBreakDuration(BreakDuration duration,int userID)
        {
            if (duration == null)
            {
                _logger.LogError("PersonalServiceController:AddBreakDuration():user tries to enter null values");
                return BadRequest("BreakDuration details not be null");
            }
            try
            {
                return _personalService.AddBreakDuration(duration,userID) ? Ok("BreakDuration details added") : Problem("Some internal Error occured");
            }
            catch (Exception exception)
            {
                _logger.LogInformation($"PersonalServiceControllerController :AddBreakDuration()-{exception.Message}{exception.StackTrace}");

                return BadRequest(exception.Message);
            }

        }
        
        [HttpDelete]
        public IActionResult DisableBreakDuration(int BreakDuration_Id)
        {
            if (BreakDuration_Id == 0)
                return BadRequest("BreakDuration_Id can't be null");


            try
            {
                return _personalService.DisableBreakDuration(BreakDuration_Id) ? Ok("BreakDuration_ Removed Successfully") : Problem("Sorry internal error occured");
            }

            catch (Exception exception)
            {
                _logger.LogInformation($"BreakDuration_ Service : DisableBreakDuration throwed an exception : {exception}");
                return BadRequest("Sorry some internal error occured");
            }

        }
        [HttpPost]
        public IActionResult AddLanguage(Language language)
        {
            if (language == null)
            {
                _logger.LogError("PersonalServiceController:AddLanguage():user tries to enter null values");
                return BadRequest("Language details not be null");
            }
            try
            {
                return _personalService.AddLanguage(language) ? Ok("Language details added") : Problem("Some internal Error occured");
            }
            catch (Exception exception)
            {
                _logger.LogInformation($"PersonalServiceControllerController :AddSkills()-{exception.Message}{exception.StackTrace}");

                return BadRequest(exception.Message);
            }

        }
        [HttpDelete]
        public IActionResult DisableLanguage(int Language_Id)
        {
            if (Language_Id == 0)
                return BadRequest("Language_Id can't be null");


            try
            {
                return _personalService.DisableLanguage(Language_Id) ? Ok("Language_ Removed Successfully") : Problem("Sorry internal error occured");
            }

            catch (Exception exception)
            {
                _logger.LogInformation($"SocialMedia_ Service : DisableLanguage throwed an exception : {exception}");
                return BadRequest("Sorry some internal error occured");
            }
        }
        [HttpPost]
        public IActionResult AddSocialMedia(SocialMedia media)
        {
            if (media == null)
            {
                _logger.LogError("PersonalServiceController:AddSocialMedia():user tries to enter null values");
                return BadRequest("social media details not be null");
            }
            try
            {
                return _personalService.AddSocialMedia(media) ? Ok("Social media details added") : Problem("Some internal Error occured");
            }
            catch (Exception exception)
            {
                _logger.LogInformation($"PersonalServiceControllerController :AddSocialMedia()-{exception.Message}{exception.StackTrace}");

                return BadRequest(exception.Message);
            }

        }
        [HttpDelete]
        public IActionResult DisableSocialMedia(int SocialMedia_Id)
        {
            if (SocialMedia_Id == 0)
                return BadRequest("SocialMedia_Id can't be null");


            try
            {
                return _personalService.DisableSocialMedia(SocialMedia_Id) ? Ok("SocialMedia_ Removed Successfully") : Problem("Sorry internal error occured");
            }

            catch (Exception exception)
            {
                _logger.LogInformation($"SocialMedia_ Service : DisableSocialMedia throwed an exception : {exception}");
                return BadRequest("Sorry some internal error occured");
            }

        }
        [HttpPost]
        public IActionResult AddAchievement(Achievements achievement)
        {
            if(achievement==null)
            {
                _logger.LogError("PersonalServiceController:AddAchievement():user tries to enter null values");
                return BadRequest("achievement details not be null");
            }
            try
            {
                return _personalService.AddAchievements(achievement) ? Ok("Achievements details added") : Problem("Some internal Error occured");
            }
            catch (Exception exception)
            {
                _logger.LogInformation($"PersonalServiceControllerController :AddAchievement()-{exception.Message}{exception.StackTrace}");

                return BadRequest(exception.Message);
            }
        }
          [HttpGet]
        public IActionResult GetallAchievements()
        {
            try
            {

                return Ok(_personalService.GetallAchievements());
            }
            catch (Exception exception)
            {
                _logger.LogInformation($"PersonalServiceController :GetallAchievements()- exception occured while fetching record{exception.Message}{exception.StackTrace}");
                return BadRequest(exception.Message);
            }


        }
        [HttpDelete]
        public IActionResult DisableAchievements(int achievementId)
        {
            if (achievementId <= 0)
                return BadRequest($"Achievement id can't be zero or less than 0 achievementId is supplied as {achievementId}");


            try
            {
                return _personalService.DisableAchievement(achievementId) ? Ok("Achievement Removed Successfully") : Problem("Sorry internal error occured");
            }

            catch (Exception exception)
            {
                _logger.LogInformation($" PersonalServiceController: DisableAchievements() : {exception.Message}{exception.StackTrace}");
                return BadRequest(exception.Message);
            }
        }
        [HttpGet]
        public IActionResult GetallProfiles()
        {
            try
            {

                return Ok(_personalService.GetallProfiles());
            }
            catch (Exception exception)
            {
                _logger.LogInformation($"PersonalServiceController :GetallProfiles()- exception occured while fetching record{exception.Message}{exception.StackTrace}");
                return BadRequest(exception.Message);
            }
        }


       [HttpGet]
        public IActionResult GetProfileById(int id)
        {
            try{
                
                return Ok(_personalService.GetProfileById(id));
            }
            catch(Exception exception){
                _logger.LogInformation($"PersonalServiceController :GetProfileById()- exception occured while fetching record{exception.Message}{exception.StackTrace}");
               return BadRequest(exception.Message);
            }
        }
       [HttpPost]
        public IActionResult AddProfileHistory(ProfileHistory profilehistory)
        {
            if (profilehistory == null)
            {
                _logger.LogError("PersonalServiceController:AddProfileHistory():User tries to enter null values");
                return BadRequest("ProfileHistory not be null");
            }
            //if(profilehistory.profile.ProfileStatus!="Approved")throw new Exception("Status should be Approved by Reporting Person");
            try
            {
                return _personalService.AddProfileHistory(profilehistory) ? Ok("ProfileHistory added") : Problem("Some internal Error occured");
            }
            catch (Exception exception)
            {
                _logger.LogInformation($"PersonalServiceController :AddProfileHistory()-{exception.Message}{exception.StackTrace}");

                return BadRequest(exception.Message);
            }
        }
        // [HttpGet]
        // public IActionResult GetallProfileHistories()
        // {
        //     try
        //     {

        //         return Ok(_personalService.GetallProfileHistories());
        //     }
        //     catch (Exception exception)
        //     {
        //         _logger.LogInformation($"PersonalServiceController :GetallProfileHistories()- exception occured while fetching record{exception.Message}{exception.StackTrace}");
        //         return BadRequest(exception.Message);
        //     }
        // }
        // [HttpGet]
        // public IActionResult GetProfileHistoryById(int Profileid)
        // {
        //     try{
                
        //         return Ok(_personalService.GetProfileById(Profileid));
        //     }
        //     catch(Exception exception){
        //         _logger.LogInformation($"PersonalServiceController :GetProfileHistoryById()- exception occured while fetching record{exception.Message}{exception.StackTrace}");
        //        return BadRequest(exception.Message);
        //     }
        // }

    }
}