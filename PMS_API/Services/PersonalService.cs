using PMS_API;

namespace PMS_API
{
    public interface IPersonalService
    {
        bool AddProfile(Profile profile);
        bool AddPersonalDetail(PersonalDetails personalDetails);
        IEnumerable<PersonalDetails> GetAllPersonalDetails();
        object GetPersonalDetailsById(int Profileid);
        bool UpdatePersonalDetail(PersonalDetails personalDetails);
        bool DisablePersonalDetails(int PersonalDetailsid);
       
        bool AddEducation(Education education);
        IEnumerable<Education> GetallEducationDetails();
        object GetEducationDetailsById(int Profileid);
        bool UpdateEducation(Education education);
        bool DisableEducationalDetails(int Educationid);

        bool AddProjects(Projects project);
        IEnumerable<Projects> GetallProjectDetails();
        object GetProjectDetailsById(int Projectid);
        bool UpdateProjects(Projects projects);
         bool DisableProjectDetails(int Projectid);

        bool AddSkills(Skills skill);
        IEnumerable<Skills> GetallSkillDetails();
        object GetSkillDetailsById(int Skillid,int Technologyid);
        bool UpdateSkills(Skills skill);
        bool DisableSkillDetails(int Skillid);

        bool AddAchievements(Achievements achievements);
        IEnumerable<Achievements> GetallAchievements();

         bool DisableAchievement(int AchievementId);

        bool AddBreakDuration(BreakDuration duration,int userID);
        bool DisableBreakDuration(int BreakDurationid);

        bool AddLanguage(Language language);
        bool DisableLanguage(int Languageid);

        bool AddSocialMedia(SocialMedia media);
        bool DisableSocialMedia(int SocialMediaid);
        public object GetPersonalDetailsByProfileId(int Profileid);
        public IEnumerable<Object> GetAllEducationDetailsByProfileId(int Profileid);
        public IEnumerable<Object> GetAllProjectDetailsByProfileId(int Profileid);
        public IEnumerable<Object> GetAllSkillDetailsByProfileId(int PersonalDetailid);
        object GetTechnologyById(int Technologyid);
        IEnumerable<Technology> GetallTechnologies();

        object GetProfileById(int Profileid);
        public IEnumerable<Profile> GetallProfiles();
        
        public bool AddProfileHistory(ProfileHistory profilehistory);
        // public IEnumerable<ProfileHistory> GetProfileHistoryById(int ProfileId);
        // public IEnumerable<ProfileHistory> GetallProfileHistories();
        
        // public bool RequestToUpdate()
        // public bool Download(int ProfileId)

        //public bool Share(List<string> Tomail,string message);
          
    }

    public class PersonalService : IPersonalService
    {

        ProfileData profileData;
        private ILogger<PersonalService> _logger;

        public PersonalService(ILogger<PersonalService> logger)
        {
            _logger = logger;
            profileData = ProfileDataFactory.GetProfileData(logger);

        }
        public bool AddProfile(Profile profile)
        {
            if (profile == null) throw new ArgumentNullException($"Values cannot be null values are {profile}");
            try
            {
                return profileData.AddProfile(profile) ? true : false;
            }
            catch (Exception exception)
            {
                _logger.LogInformation($"PersonalServices:AddProfile()-{exception.Message}\n{exception.StackTrace}");
                return false;
            }

        }
        
        public bool AddPersonalDetail(PersonalDetails personalDetails)
        {
            if (personalDetails == null) throw new ArgumentNullException($"Values cannot be null values are {personalDetails}");
            try
            {
                
                personalDetails.CreatedBy = personalDetails.UserId;
                personalDetails.CreatedOn = DateTime.Now;
                //Imagedate = ImageService.Getbase64String(personalDetails.base64header);

                personalDetails.base64header =ImageService.Getbase64Header(personalDetails.base64header);

                //personalDetails.Image = System.Convert.FromBase64String(Imagedate);
                return profileData.AddPersonalDetail(personalDetails) ? true : false;
            }
            catch (Exception exception)
            {
                _logger.LogInformation($"PersonalServices:AddPersonalDetail()-{exception.Message}\n{exception.StackTrace}");
                return false;
            }

        }
        public IEnumerable<PersonalDetails> GetAllPersonalDetails()
        {
            try{
                // IEnumerable<User> userDetails = new List<User>();
             
                return from  personalDetails in profileData.GetAllPersonalDetails() where personalDetails.IsActive==true select personalDetails;
                
            
            
            }
            catch(Exception exception){
                // Log Exception occured in DAL while fetching users
                _logger.LogError($"PersonalServices:GetallPersonalDetails()-{exception.Message}\n{exception.StackTrace}");
                throw exception;
            }
        }
        public object GetPersonalDetailsById(int Profileid)
        {
            if(Profileid<=0)
                throw new ArgumentNullException($"ID is not provided{Profileid}");
            try
            {
                var getpersonaldetails= profileData. GetPersonalDetailsById(Profileid); 
                return new {
                    personaldetailsid=getpersonaldetails.PersonalDetailsId,
                    objective=getpersonaldetails.Objective,
                    dateofbirth=getpersonaldetails.DateOfBirth,
                    nationality=getpersonaldetails.Nationality,
                    dateofjoining=getpersonaldetails.DateOfJoining,
                    language=getpersonaldetails.language,
                    socialmedia=getpersonaldetails.socialmedia,
                    breakduration=getpersonaldetails.breakDuration
                };
            }
            catch(Exception exception){
                _logger.LogError($"UserServices:GetUser()-{exception.Message}\n{exception.StackTrace}");
                throw exception;
            }
        }
        public object GetPersonalDetailsByProfileId(int Profileid)
        {
            if(Profileid<=0)
                throw new ArgumentNullException($"ID is not provided{Profileid}");
            try
            {
                var getpersonaldetailsbyprofileid= profileData.GetAllPersonalDetails().Where(item=> item.ProfileId==Profileid).Select(item =>
                 new {
                     personaldetailsid=item.PersonalDetailsId,
                    objective=item.Objective,
                    dateofbirth=item.DateOfBirth,
                    nationality=item.Nationality,
                    dateofjoining=item.DateOfJoining,
                    language=item.language,
                    socialmedia=item.socialmedia,
                    breakduration=item.breakDuration

                });return getpersonaldetailsbyprofileid;
            }
            catch(Exception exception){
                _logger.LogError($"UserServices:GetEducationDetailsById()-{exception.Message}\n{exception.StackTrace}");
                throw exception;
            }
        }
        public bool UpdatePersonalDetail(PersonalDetails personalDetails)
        {
            if (personalDetails == null) throw new ArgumentNullException($" PersonalService:Update()-Personal values not be null{personalDetails}");

            try
            {
                personalDetails.UpdatedBy = personalDetails.CreatedBy;
                personalDetails.UpdatedOn = DateTime.Now;
                return profileData.UpdatePersonalDetail(personalDetails);
            }
            catch( Exception exception) 
            {
                _logger.LogInformation($"PersonalServices:Update()-{exception.Message}\n{exception.StackTrace}");
                return false;
            }
            
        }

        
        public bool DisablePersonalDetails(int PersonalDetailid)
        {
            if(PersonalDetailid<=0)
                throw new ArgumentNullException($"ID is not provided{PersonalDetailid}");

            
            try
            {

                return profileData.DisablePersonalDetails(PersonalDetailid)?true:false;
                
            }
            
            catch(Exception exception){
                _logger.LogInformation($"PersonalServices:Delete()-{exception.Message}\n{exception.StackTrace}");
                return false;
            }
        }
          
        public bool AddEducation(Education education)
        {
            if (education == null) throw new ArgumentNullException($"Values cannot be null values are {education}");
            try
            {
                education.Starting = education.Starting_Year.Year;
                education.Ending = education.Ending_Year.Year;
                education.CreatedBy = education.ProfileId;
                education.CreatedOn = DateTime.Now;
                return profileData.AddEducation(education) ? true : false;
            }
            catch (Exception exception)
            {
                _logger.LogInformation($"PersonalServices:AddEducation()-{exception.Message}\n{exception.StackTrace}");
                return false;
            }


        }
       
         public Object GetEducationDetailsById(int Profileid)
        {
            if(Profileid<=0)
                throw new ArgumentNullException($"ID is not provided{Profileid}");
            try
            {
                var geteducationdetails= profileData.GetEducationDetailsById(Profileid); 
                return new {
                    educationid=geteducationdetails.EducationId,
                    degree =geteducationdetails.Degree,
                    course=geteducationdetails.Course,
                    college=geteducationdetails.college.CollegeName,
                    startingyear=geteducationdetails.Starting,
                    endingyear=geteducationdetails.Ending,
                    percentage=geteducationdetails.Percentage

                };
            }
            catch(Exception exception){
                _logger.LogError($"UserServices:GetEducationDetailsById()-{exception.Message}\n{exception.StackTrace}");
                throw exception;
            }
        }
         public IEnumerable<Education> GetallEducationDetails()
        {
            try{
                // IEnumerable<User> userDetails = new List<User>();
             
                return from educations in profileData.GetallEducationDetails() where educations.IsActive==true select educations;
                
            
            
            }
            catch(Exception exception){
                // Log Exception occured in DAL while fetching users
                _logger.LogError($"PersonalServices:GetallPersonalDetails()-{exception.Message}\n{exception.StackTrace}");
                throw exception;
            }
        }
        public IEnumerable<Object> GetAllEducationDetailsByProfileId(int Profileid)        {
            if(Profileid<=0)
                throw new ArgumentNullException($"ID is not provided{Profileid}");
            try
            {
                var geteducationdetailsbyprofileid= profileData.GetallEducationDetails().Where(item=> item.ProfileId==Profileid).Select(item =>
                 new {
                    educationid=item.EducationId,
                    degree =item.Degree,
                    course=item.Course,
                    college=item.college?.CollegeName,
                    startingyear=item.Starting,
                    endingyear=item.Ending,
                    percentage=item.Percentage

                });return geteducationdetailsbyprofileid;
            }
            catch(Exception exception){
                _logger.LogError($"UserServices:GetEducationDetailsById()-{exception.Message}\n{exception.StackTrace}");
                throw exception;
            }
        }
        public bool UpdateEducation(Education education)
        {
            if (education == null) throw new ArgumentNullException($" PersonalServices:UpdateEducation()-Education values not be null{education}");

            try
            {
                education.UpdatedBy = education.CreatedBy;
                education.UpdatedOn = DateTime.Now;
                return profileData.UpdateEducation(education);

            }

            catch (Exception exception)
            {
                _logger.LogInformation($"PersonalServices:UpdateEduaction()-{exception.Message}\n{exception.StackTrace}");
                return false;

            }
        }
        public bool DisableEducationalDetails(int EducationalDetailid)
        {
            if(EducationalDetailid<=0)
                throw new ArgumentNullException($"ID is not provided{EducationalDetailid}");

            
            try
            {

                return profileData.DisableEducationalDetails(EducationalDetailid)?true:false;
                
            }
            
            catch(Exception exception){
                _logger.LogInformation($"PersonalServices:Delete()-{exception.Message}\n{exception.StackTrace}");
                return false;
            }
        }    

        public bool AddProjects(Projects project)
        {
            if (project == null) throw new ArgumentNullException($"Values cannot be null values are {project}");
            try
            {
                project.StartingMonth=project.ProjectStartingMonth.Month.ToString("MMM");
                project.StartingYear=project.ProjectStartingYear.Year;
                project.EndingMonth=project.ProjectEndingMonth.Month.ToString("MMM");
                project.EndingYear=project.ProjectEndingYear.Year;
                project.CreatedBy = project.ProfileId;
                project.CreatedOn = DateTime.Now;
                return profileData.AddProjects(project) ? true : false;
            }
            catch (Exception exception)
            {
                _logger.LogInformation($"PersonalServices:AddProjects()-{exception.Message}\n{exception.StackTrace}");
                return false;
            }


        }
         
         public object GetProjectDetailsById(int Profileid)
        {
            if(Profileid<=0)
                throw new ArgumentNullException($"ID is not provided{Profileid}");
            try
            {
                var getprojectdetails= profileData. GetProjectDetailsById(Profileid); 
                return new {
                    projectid=getprojectdetails.ProjectId,
                    projectname=getprojectdetails.ProjectName,
                    projectdescription=getprojectdetails.ProjectDescription,
                    startingMonth=getprojectdetails.StartingMonth,
                    startingYear=getprojectdetails.StartingYear,
                    endingMonth=getprojectdetails.EndingMonth,
                    endingYear=getprojectdetails.EndingYear,
                    role=getprojectdetails.Designation,
                    toolsused=getprojectdetails.ToolsUsed,

                };
            }
            catch(Exception exception){
                _logger.LogError($"UserServices:GetEducationDetailsById()-{exception.Message}\n{exception.StackTrace}");
                throw exception;
            }
        }
        public IEnumerable<Projects> GetallProjectDetails()
        {
            try{
                // IEnumerable<User> userDetails = new List<User>();
             
                return from projects in profileData.GetallProjectDetails() where projects.IsActive==true select projects;
                
            
            
            }
            catch(Exception exception){
                // Log Exception occured in DAL while fetching users
                _logger.LogError($"PersonalServices:GetallProjectDetails()-{exception.Message}\n{exception.StackTrace}");
                throw exception;
            }
        }
        public IEnumerable<Object> GetAllProjectDetailsByProfileId(int Profileid)
        {
            if(Profileid<=0)
                throw new ArgumentNullException($"ID is not provided{Profileid}");
            try
            {
                var getallprojectdetailsbyprofileid= profileData.GetallProjectDetails().Where(item=> item.ProfileId==Profileid).Select(item =>
                 new {
                     projectid=item.ProjectId,
                     projectname=item.ProjectName,
                     projectdescription=item.ProjectDescription,
                    startingMonth=item.StartingMonth,
                    startingYear=item.StartingYear,
                    endingMonth=item.EndingMonth,
                    endingYear=item.EndingYear,
                    role=item.Designation,
                    toolsused=item.ToolsUsed

                    

                });return  getallprojectdetailsbyprofileid;
            }
            catch(Exception exception){
                _logger.LogError($"UserServices:GetEducationDetailsById()-{exception.Message}\n{exception.StackTrace}");
                throw exception;
            }
        }
        public bool UpdateProjects(Projects projects)
        {
            if (projects == null) throw new ArgumentNullException($" PersonalServices:UpdateProjcts()-Project values not be null{projects}");

            try
            {
                projects.UpdatedBy = projects.CreatedBy;
                projects.UpdatedOn = DateTime.Now;
                return profileData.UpdateProjects(projects);

            }

            catch (Exception exception)
            {
                _logger.LogInformation($"PersonalServices:UpdateProject()-{exception.Message}\n{exception.StackTrace}");
                return false;

            }
        }
        public bool DisableProjectDetails(int ProjectDetailid)
        {
            if(ProjectDetailid<=0)
                throw new ArgumentNullException($"ID is not provided{ProjectDetailid}");

            
            try
            {

                return profileData.DisableProjectDetails(ProjectDetailid)?true:false;
                
            }
            
            catch(Exception exception){
                _logger.LogInformation($"PersonalServices:Delete()-{exception.Message}\n{exception.StackTrace}");
                return false;
            }
        }   

        public bool AddSkills(Skills skill)
        {
            if (skill == null) throw new ArgumentNullException($"Values cannot be null values are {skill}");
            try
            {
                skill.CreatedBy = skill.ProfileId;
                skill.CreatedOn = DateTime.Now;
                return profileData.AddSkills(skill) ? true : false;
            }
            catch (Exception exception)
            {
                _logger.LogInformation($"PersonalServices:AddSkills()-{exception.Message}\n{exception.StackTrace}");
                return false;
            }


        }
       
         public object GetSkillDetailsById(int Skillid,int Technologyid)
        {
            if(Skillid<=0)
                throw new ArgumentNullException($"ID is not provided{Skillid}");
            try
            {
                var getskilldetails= profileData.GetSkillDetailsById(Skillid); 
                return new {
                    skillid=getskilldetails.SkillId,
                    domainname=getskilldetails.domain.DomainName,
                    technology = profileData.GetTechnologyById(Technologyid).TechnologyName
                };
            }
            catch(Exception exception){
                _logger.LogError($"UserServices:GetEducationDetailsById()-{exception.Message}\n{exception.StackTrace}");
                throw exception;
            }
        }
         public IEnumerable<Skills> GetallSkillDetails()
        {
            try{
                // IEnumerable<User> userDetails = new List<User>();
             
                return from skills in profileData.GetallSkillDetails() where skills.IsActive==true select skills;
                
            
            
            }
            catch(Exception exception){
                // Log Exception occured in DAL while fetching users
                _logger.LogError($"PersonalServices:GetallSkillDetails()-{exception.Message}\n{exception.StackTrace}");
                throw exception;
            }
        }
         public IEnumerable<Object> GetAllSkillDetailsByProfileId(int Profileid)
         {
             if(Profileid<=0)
                 throw new ArgumentNullException($"ID is not provided{Profileid}");
             try
             {
                 var getallskilldetailsbyprofileid= profileData.GetallSkillDetails().Where(item=> item.ProfileId==Profileid).Select(item =>
                 new {
                  skillid=item.SkillId,
                     domainname=item.domain.DomainName
                });return  getallskilldetailsbyprofileid;
            }
             catch(Exception exception){
                 _logger.LogError($"UserServices:GetEducationDetailsById()-{exception.Message}\n{exception.StackTrace}");
                 throw exception;
             }
         }
        public bool UpdateSkills(Skills skill)
        {
            if (skill == null) throw new ArgumentNullException($" PersonalServices:Update()-skill values not be null{skill}");

            try
            {
                skill.UpdatedBy = skill.CreatedBy;
                skill.UpdatedOn = DateTime.Now;
                return profileData.UpdateSkills(skill);

            }

            catch (Exception exception)
            {
                _logger.LogInformation($"PersonalServices:Update()-{exception.Message}\n{exception.StackTrace}");
                return false;

            }
        }
         public bool DisableSkillDetails(int SkillDetailid)
        {
            if(SkillDetailid<=0)
                throw new ArgumentNullException($"ID is not provided{SkillDetailid}");

            
            try
            {

                return profileData.DisableSkillDetails(SkillDetailid)?true:false;
                
            }
            
            catch(Exception exception){
                _logger.LogInformation($"PersonalServices:Delete()-{exception.Message}\n{exception.StackTrace}");
                return false;
            }
        }   
        public bool AddBreakDuration(BreakDuration duration,int userID)
        {
            if (duration == null) throw new ArgumentNullException($"Values cannot be null values are {duration}");
            try
            {
                duration.CreatedBy = userID;
                duration.CreatedOn = DateTime.Now;
                return profileData.AddBreakDuration(duration) ? true : false;
            }
            catch (Exception exception)
            {
                _logger.LogInformation($"PersonalServices:AddSkills()-{exception.Message}\n{exception.StackTrace}");
                return false;
            }


        }
         public bool DisableBreakDuration(int BreakDurationid)
        {
            if(BreakDurationid<=0)
                throw new ArgumentNullException($"ID is not provided{BreakDurationid}");

            
            try
            {

                return profileData.DisableBreakDuration(BreakDurationid)?true:false;
                
            }
            
            catch(Exception exception){
                _logger.LogInformation($"PersonalServices:Delete()-{exception.Message}\n{exception.StackTrace}");
                return false;
            }
        }    
        public bool AddLanguage(Language language,int userId)
        {
            if (language == null) throw new ArgumentNullException($"Values cannot be null values are {language}");
            try
            {
                language.CreatedBy = userId; 
                language.CreatedOn = DateTime.Now;
                return profileData.AddLanguage(language) ? true : false;
            }
            catch (Exception exception)
            {
                _logger.LogInformation($"PersonalServices:AddSkills()-{exception.Message}\n{exception.StackTrace}");
                return false;
            }


        }
         
        
         public bool DisableLanguage(int Languageid)
        {
            if(Languageid<=0)
                throw new ArgumentNullException($"ID is not provided{Languageid}");

            
            try
            {

                return profileData.DisableLanguage(Languageid)?true:false;
                
            }
            
            catch(Exception exception){
                _logger.LogInformation($"PersonalServices:Delete()-{exception.Message}\n{exception.StackTrace}");
                return false;
            }
        }    
        public bool AddSocialMedia(SocialMedia media,int userId)
        {
            if (media == null) throw new ArgumentNullException($"Values cannot be null values are {media}");
            try
            {
                media.CreatedBy = userId;
                media.CreatedOn = DateTime.Now;
                return profileData.AddSocialMedia(media) ? true : false;
            }
            catch (Exception exception)
            {
                _logger.LogInformation($"PersonalServices:AddSkills()-{exception.Message}\n{exception.StackTrace}");
                return false;
            }


        }
          public bool DisableSocialMedia(int SocialMediaid)
        {
            if(SocialMediaid<=0)
                throw new ArgumentNullException($"ID is not provided{SocialMediaid}");

            
            try
            {

                return profileData.DisableSocialMedia(SocialMediaid)?true:false;
                
            }
            
            catch(Exception exception){
                _logger.LogInformation($"PersonalServices:Delete()-{exception.Message}\n{exception.StackTrace}");
                return false;
            }
        }

        
        public object GetTechnologyById(int Technologyid)
        {
            if(Technologyid<=0)
                throw new ArgumentNullException($"ID is not provided{Technologyid}");
            try
            {
                var gettechnologydetails= profileData.GetTechnologyById(Technologyid); 
                return new {
                   technologyname=gettechnologydetails.TechnologyName
                };
            }
            catch(Exception exception){
                _logger.LogError($"UserServices:GetEducationDetailsById()-{exception.Message}\n{exception.StackTrace}");
                throw exception;
            }
        }
        public IEnumerable<Technology> GetallTechnologies()
        {
            try{
                // IEnumerable<User> userDetails = new List<User>();
             
                return from Technologies in profileData.GetallTechnologies() where Technologies.IsActive==true select Technologies;
                
            
            
            }
            catch(Exception exception){
                // Log Exception occured in DAL while fetching users
                _logger.LogError($"PersonalServices:GetallPersonalDetails()-{exception.Message}\n{exception.StackTrace}");
                throw exception;
            }
        }

        bool IPersonalService.AddLanguage(Language language)
        {
            throw new NotImplementedException();
        }

        bool IPersonalService.AddSocialMedia(SocialMedia media)
        {
            throw new NotImplementedException();
        }

        public bool AddAchievements(Achievements achievement)
        {
            if (achievement == null) throw new ArgumentNullException($"Values cannot be null values are {achievement}");
            try
            {
                string Imagedate="";
                Imagedate = ImageService.Getbase64String(achievement.base64header);
                achievement.base64header =ImageService.Getbase64Header(achievement.base64header);
                achievement.Image = System.Convert.FromBase64String(Imagedate);

                
                achievement.CreatedOn = DateTime.Now;
                return profileData.AddAchievements(achievement) ? true : false;
            }
            catch (Exception exception)
            {
                _logger.LogInformation($"PersonalServices:AddAchievements()-{exception.Message}\n{exception.StackTrace}");
                return false;
            }


        }
        public IEnumerable<Achievements> GetallAchievements()
        {
            try{
                // IEnumerable<User> userDetails = new List<User>();
             
                return from achievements in profileData.GetallAchievements() where achievements.IsActive==true select achievements;
                
            
            
            }
            catch(Exception exception){
                // Log Exception occured in DAL while fetching users
                _logger.LogError($"PersonalServices:GetallSkillDetails()-{exception.Message}\n{exception.StackTrace}");
                throw exception;
            }
        }
         public IEnumerable<Object> GetAchievementsById(int Profileid)
        {
            if(Profileid<=0)
                throw new ArgumentNullException($"ID is not provided{Profileid}");
            try
            {
                var getachievementsbypersonalid= profileData.GetallAchievements().Where(item=> item.ProfileId==Profileid).Select(item =>
                 new {
                    achievementid=item.AchievementId,
                    achievementtype=item.achievementtype.AchievementTypeName,
                    achievementimage=item.Image

                });return getachievementsbypersonalid;
            }
            catch(Exception exception){
                _logger.LogError($"UserServices:GetEducationDetailsById()-{exception.Message}\n{exception.StackTrace}");
                throw exception;
            }
        }
         public bool DisableAchievement(int achievementId)
        {
            if(achievementId<=0)
                throw new ArgumentNullException($"Achievement ID is not provided{achievementId}");

            
            try
            {

                return profileData.DisableAchievement(achievementId)?true:false;
                
            }
            
            catch(Exception exception){
                _logger.LogInformation($"PersonalServices:RemoveAchievemen()-{exception.Message}\n{exception.StackTrace}");
                return false;
            }
        }
        public IEnumerable<Profile> GetallProfiles()
        {
            try{
                // IEnumerable<User> userDetails = new List<User>();
             
                return from profile in profileData.GetallProfiles() where profile.IsActive==true select profile;
                
            
            
            }
            catch(Exception exception){
                // Log Exception occured in DAL while fetching users
                _logger.LogError($"PersonalServices:GetallProfiles()-{exception.Message}\n{exception.StackTrace}");
                throw exception;
            }
        }
        public object GetProfileById(int Profileid)
        {
            if(Profileid<=0)
                throw new ArgumentNullException($"ID is not provided{Profileid}");
            try
            {
                var getviewdetails= profileData.GetProfileById(Profileid); 
                return new {
                    personaldetails=GetPersonalDetailsByProfileId(getviewdetails.ProfileId),
                    educationdetails=GetAllEducationDetailsByProfileId(getviewdetails.ProfileId),
                    projectdetails=GetAllProjectDetailsByProfileId(getviewdetails.ProfileId),
                    skilldetails=GetAllSkillDetailsByProfileId(getviewdetails.ProfileId),
                    achievementdetails=GetAchievementsById(getviewdetails.ProfileId)
                };
            }
            catch(Exception exception){
                _logger.LogError($"UserServices:GetUser()-{exception.Message}\n{exception.StackTrace}");
                throw exception;
            }
        }
         public bool AddProfileHistory(Profile profile)
        {
            if (profile == null) throw new ArgumentNullException($"Values cannot be null values are {profile}");
            try
            {
                return profileData.AddProfile(profile) ? true : false;
            }
            catch (Exception exception)
            {
                _logger.LogInformation($"PersonalServices:AddProfile()-{exception.Message}\n{exception.StackTrace}");
                return false;
            }

        }
        
        public bool AddProfileHistory(ProfileHistory profilehistory)
        {
            if (profilehistory == null) throw new ArgumentNullException($"Values cannot be null values are {profilehistory}");
            //if(profilehistory.profile.ProfileStatus!="Approved")throw new Exception("Status should be Approved by Reporting Person");
            try
            {
                return profileData.AddProfileHistory(profilehistory) ? true : false;
            }
            catch (Exception exception)
            {
                _logger.LogInformation($"PersonalServices:AddProfileHistory()-{exception.Message}\n{exception.StackTrace}");
                return false;
            }

        }
        // public IEnumerable<Profile> GetallProfileHistories()
        // {
        //     try{
        //         // IEnumerable<User> userDetails = new List<User>();
             
        //         return from profilehistory in profileData.GetallProfileHistories() where profilehistory.IsActive==true select profilehistory;
                
            
            
        //     }
        //     catch(Exception exception){
        //         // Log Exception occured in DAL while fetching users
        //         _logger.LogError($"PersonalServices:GetallProfiles()-{exception.Message}\n{exception.StackTrace}");
        //         throw exception;
        //     }
        // }
        // public IEnumerable<ProfileHistory> GetProfileHistoryById(int Profileid)
        // {
        //     if(Profileid<=0)
        //         throw new ArgumentNullException($"ID is not provided{Profileid}");
        //     try
        //     {
        //         var getprofilehistorybyid= profileData.GetallProfile().Where(item=> item.ProfileId==Profileid).Select(item =>
        //          new {
        //              profilehistory=GetProfileById();

        //         });
        //     }
        //     catch(Exception exception){
        //         _logger.LogError($"UserServices:GetEducationDetailsById()-{exception.Message}\n{exception.StackTrace}");
        //         throw exception;
        //     }
        // }

    }
}
