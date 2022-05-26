using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations;
using Microsoft.EntityFrameworkCore;


namespace PMS_API
{
    public interface IPersonalDetails
    {

    }
    public class ProfileData
    {
        private Context _context;
        private ILogger<PersonalService> _logger;

        public ProfileData(Context context, ILogger<PersonalService> logger)
        {
            _context = context;
            _logger = logger;
        }
        public bool AddProfile(Profile Profile)
        {


            if (Profile == null)
                throw new ArgumentNullException("personalDetails object is not provided to DAL");

            try
            {

                _context.profile.Add(Profile);
                _context.SaveChanges();
                return true;
            }

            catch (Exception exception)
            {
                //log "unknown exception occured"
                _logger.LogError($"ProfileData.cs-AddProfile()-{exception.Message}");
                _logger.LogInformation($"ProfileData.cs-AddProfile()-{exception.StackTrace}");

                return false;
            }


        }
        public List<PersonalDetails> GetAllPersonalDetails()
        {

            try
            {

                return _context.personalDetails.Include("language").Include("breakDuration").Include("socialmedia").Include("education").Include("projects").Include("skills").ToList();

            }

            catch (Exception exception)
            {
                //log "if exception occures"
                _logger.LogError($"ProfileData.cs-GetallPersonalDetails()-{exception.Message}");
                _logger.LogInformation($"UserData.cs-GetallPersonalDetails()-{exception.StackTrace}");
                throw exception;
            }
        }
        public PersonalDetails GetPersonalDetailsById(int id)
        {
            if (id <= 0)

                throw new ValidationException("Profile Id is not provided to DAL");

            try
            {
                PersonalDetails personalDetails = GetAllPersonalDetails().Where(x => x.ProfileId == id).First();
                if (personalDetails == null) throw new NullReferenceException($"Id not found-{id}");
                return personalDetails;
            }
            catch (Exception exception)
            {
                _logger.LogError($"ProfileData.cs-GetPersonalDetailsById()-{exception.Message}");
                _logger.LogInformation($"ProfileData.cs-GetPersonalDetailsById()-{exception.StackTrace}");
                throw exception;
            }
        }

        public bool AddPersonalDetail(PersonalDetails personalDetails)
        {


            if (personalDetails == null)
                throw new ArgumentNullException("personalDetails object is not provided to DAL");

            try
            {

                _context.personalDetails.Add(personalDetails);
                _context.SaveChanges();
                return true;
            }

            catch (Exception exception)
            {
                //log "unknown exception occured"
                _logger.LogError($"ProfileData.cs-AddPersonalDetails()-{exception.Message}");
                _logger.LogInformation($"ProfileData.cs-AddPersonalDetails()-{exception.StackTrace}");

                return false;
            }


        }
        public bool UpdatePersonalDetail(PersonalDetails personalDetails)
        {
            if (personalDetails == null)
                throw new ValidationException("profile's personal detail is not provided to DAL");


            try
            {
                var Profile = _context.personalDetails.Find(personalDetails.PersonalDetailsId);
                if (Profile == null) throw new NullReferenceException($"Profile Id not found{personalDetails.PersonalDetailsId}");
                _context.Update(personalDetails);
                _context.SaveChanges();
                return true;
            }
            catch (Exception exception)
            {
                //log " exception occures"
                _logger.LogError($"ProfileData.cs-UpdatePersonalDetail)-{exception.Message}");
                _logger.LogInformation($"ProfileData.cs-UpdatePersonalDetail()-{exception.StackTrace}");
                return false;
            }

        }

        public bool DisablePersonalDetails(int PersonalDetailsId)
        {
            if (PersonalDetailsId <= 0)
                throw new ValidationException("PersonalDetails Id is not provided to DAL");

            try
            {
                var personalDetails = _context.personalDetails.Find(PersonalDetailsId);

                //do null validation for personaldetails
                if (personalDetails == null) throw new NullReferenceException($"PersonalDetails Id not found{PersonalDetailsId}");
                personalDetails.IsActive = false;
                _context.personalDetails.Update(personalDetails);
                _context.SaveChanges();
                return true;

            }


            catch (Exception exception)
            {
                //log "if exception occures"
                _logger.LogError($"ProfileData.cs-DisablePersonalDetails()-{exception.Message}");
                _logger.LogInformation($"ProfileData.cs-DisablePersonalDetails()-{exception.StackTrace}");
                return false;
            }

        }
        public List<Education> GetallEducationDetails()
        {

            try
            {

                return _context.educations.Include("college").ToList();

            }

            catch (Exception exception)
            {
                //log "if exception occures"
                _logger.LogError($"ProfileData.cs-GetallEducationDetails()-{exception.Message}");
                _logger.LogInformation($"ProfileData.cs-GetallEducationDetails()-{exception.StackTrace}");
                throw exception;
            }
        }
        public Education GetEducationDetailsById(int Profileid)
        {
            if (Profileid <= 0)

                throw new ValidationException("Education Id is not provided to DAL");

            try
            {
                Education education = GetallEducationDetails().Where(x => x.ProfileId == Profileid).First();
                if (education == null) throw new NullReferenceException($"Id not found-{Profileid}");
                return education;
            }
            catch (Exception exception)
            {
                _logger.LogError($"ProfileData.cs-GetEducationDetailsById()-{exception.Message}");
                _logger.LogInformation($"ProfileData.cs-GetEducationDetailsById()-{exception.StackTrace}");
                throw exception;
            }
        }

        public bool AddEducation(Education education)
        {


            if (education == null)
                throw new ArgumentNullException("Education detail object is not provided to DAL");

            try
            {

                _context.educations.Add(education);
                _context.SaveChanges();
                return true;
            }

            catch (Exception exception)
            {
                //log "unknown exception occured"
                _logger.LogError($"ProfileData.cs-AddEducation()-{exception.Message}");
                _logger.LogInformation($"ProfileData.cs-AddEducation()-{exception.StackTrace}");

                return false;
            }


        }
        public bool UpdateEducation(Education education)
        {
            if (education == null)
                throw new ValidationException("Profile's education details are not provided to DAL");
            try
            {
                var Profile = _context.educations.Find(education.EducationId);

                if (Profile == null) throw new NullReferenceException($"Profile's EducationId not found{education.EducationId}");
                _context.Update(education);
                _context.SaveChanges();
                return true;
            }
            catch (Exception exception)
            {
                //log " exception occures"
                _logger.LogError($"ProfileData.cs-UpdateEducation)-{exception.Message}");
                _logger.LogInformation($"ProfileData.cs-UpdateEducaion()-{exception.StackTrace}");
                return false;
            }

        }


        public bool DisableEducationalDetails(int Education_Id)
        {
            if (Education_Id <= 0)

                throw new ValidationException("Education Id is not provided to DAL");

            try
            {
                var educations = _context.educations.Find(Education_Id);

                //do null validation for education
                if (educations == null) throw new NullReferenceException($"Education Id not found{Education_Id}");
                educations.IsActive = false;
                _context.educations.Update(educations);
                _context.SaveChanges();
                return true;

            }


            catch (Exception exception)
            {
                //log "if exception occures"
                _logger.LogError($"ProfileData.cs-DisableEducationDetails()-{exception.Message}");
                _logger.LogInformation($"ProfileDate.cs-DisableEducationDetails()-{exception.StackTrace}");
                return false;
            }

        }
        public bool AddProjects(Projects projects)
        {


            if (projects == null)
                throw new ArgumentNullException("project detail object is not provided to DAL");

            try
            {

                _context.projects.Add(projects);
                _context.SaveChanges();
                return true;
            }

            catch (Exception exception)
            {
                //log "unknown exception occured"
                _logger.LogError($"ProfileData.cs-AddProjects()-{exception.Message}");
                _logger.LogInformation($"ProfileData.cs-AddProjects()-{exception.StackTrace}");

                return false;
            }


        }
        public List<Projects> GetallProjectDetails()
        {

            try
            {

                return _context.projects.ToList();

            }

            catch (Exception exception)
            {
                //log "if exception occures"
                _logger.LogError($"ProfileData.cs-GetallProjectDetails()-{exception.Message}");
                _logger.LogInformation($"ProfileData.cs-GetallProjectDetails()-{exception.StackTrace}");
                throw exception;
            }
        }
        public Projects GetProjectDetailsById(int Projectid)
        {
            if (Projectid <= 0)

                throw new ValidationException("Project Id is not provided to DAL");

            try
            {
                Projects project = GetallProjectDetails().Where(x => x.ProjectId == Projectid).First();
                if (project == null) throw new NullReferenceException($"Id not found-{Projectid}");
                return project;
            }
            catch (Exception exception)
            {
                _logger.LogError($"ProfileData.cs-GetProjectDetailsById()-{exception.Message}");
                _logger.LogInformation($"ProfileData.cs-GetProjectDetailsById()-{exception.StackTrace}");
                throw exception;
            }
        }
        public bool UpdateProjects(Projects projects)
        {
            if (projects == null)
                throw new ValidationException("Profile's Project details are not provided to DAL");


            try
            {
                var Profile = _context.projects.Find(projects.ProjectId);
                if (Profile == null) throw new NullReferenceException($"Profile's projectId not found{projects.ProjectId}");
                _context.Update(projects);
                _context.SaveChanges();
                return true;
            }
            catch (Exception exception)
            {
                //log " exception occures"
                _logger.LogError($"ProfileData.cs-UpdatePersonalDetail)-{exception.Message}");
                _logger.LogInformation($"ProfileData.cs-UpdatePersonalDetail()-{exception.StackTrace}");
                return false;
            }

        }
        public bool DisableProjectDetails(int Project_Id)
        {
            if (Project_Id <= 0)

                throw new ValidationException("Project Id is not provided to DAL");

            try
            {
                var projects = _context.projects.Find(Project_Id);

                //do null validation for 
                if (projects == null)
                    throw new NullReferenceException($"Project Id not found{Project_Id}");

                projects.IsActive = false;
                _context.projects.Update(projects);
                _context.SaveChanges();
                return true;

            }


            catch (Exception exception)
            {
                //log "if exception occures"
                _logger.LogError($"ProfileData.cs-DisableProjectDetails()-{exception.Message}");
                _logger.LogInformation($"ProfileData.cs-DisableProjectDetails()-{exception.StackTrace}");
                return false;
            }

        }
        public bool AddBreakDuration(BreakDuration duration)
        {


            if (duration == null)
                throw new ArgumentNullException("Break duration detail object is not provided to DAL");

            try
            {

                _context.breakDurations.Add(duration);
                _context.SaveChanges();
                return true;
            }

            catch (Exception exception)
            {
                //log "unknown exception occured"
                _logger.LogError($"ProfileData.cs-AddBreakDuration()-{exception.Message}");
                _logger.LogInformation($"ProfileData.cs-AddSBreakDuration()-{exception.StackTrace}");

                return false;
            }


        }


        public bool DisableBreakDuration(int BreakDuration_Id)
        {
            if (BreakDuration_Id <= 0)

                throw new ValidationException("BreakDuration Id is not provided to DAL");

            try
            {
                var breakDurations = _context.breakDurations.Find(BreakDuration_Id);

                //do null validation for user
                if (breakDurations == null) throw new NullReferenceException($"Project Id not found{BreakDuration_Id}");
                breakDurations.IsActive = false;
                _context.breakDurations.Update(breakDurations);
                _context.SaveChanges();
                return true;

            }


            catch (Exception exception)
            {
                //log "if exception occures"
                _logger.LogError($"ProfileData.cs-DisableBreakDuration()-{exception.Message}");
                _logger.LogInformation($"ProfileData.cs-DisableBreakDuration()-{exception.StackTrace}");
                return false;
            }

        }
        public bool AddSkills(Skills skill)
        {


            if (skill == null)
                throw new ArgumentNullException("Education detail object is not provided to DAL");

            try
            {

                _context.skills.Add(skill);
                _context.SaveChanges();
                return true;
            }

            catch (Exception exception)
            {
                //log "unknown exception occured"
                _logger.LogError($"ProfileData.cs-AddSkills()-{exception.Message}");
                _logger.LogInformation($"ProfileData.cs-AddSkills()-{exception.StackTrace}");

                return false;
            }


        }
        public List<Skills> GetallSkillDetails()
        {

            try
            {

                return _context.skills.Include("domain").ToList();

            }

            catch (Exception exception)
            {
                //log "if exception occures"
                _logger.LogError($"ProfileData.cs-GetallSkillDetails()-{exception.Message}");
                _logger.LogInformation($"ProfileData.cs-GetallSkillDetails()-{exception.StackTrace}");
                throw exception;
            }
        }
        public Skills GetSkillDetailsById(int skillid)
        {
            if (skillid <= 0)

                throw new ValidationException("Skill Id is not provided to DAL");

            try
            {
                Skills skills = GetallSkillDetails().Where(x => x.SkillId == skillid).First();
                if (skills == null) throw new NullReferenceException($"Id not found-{skillid}");
                return skills;
            }
            catch (Exception exception)
            {
                _logger.LogError($"ProfileData.cs-GetSkillDetailsById()-{exception.Message}");
                _logger.LogInformation($"ProfileData.cs-GetSkillDetailsById()-{exception.StackTrace}");
                throw exception;
            }
        }
        public bool UpdateSkills(Skills skill)
        {
            if (skill == null)
                throw new ValidationException("Profile's skilldetails are not provided to DAL");


            try
            {
                var Profile = _context.skills.Find(skill.SkillId);
                if (Profile == null) throw new NullReferenceException($"Profile's SkillId not found{skill.SkillId}");
                _context.Update(skill);
                _context.SaveChanges();
                return true;
            }
            catch (Exception exception)
            {
                //log " exception occures"
                _logger.LogError($"ProfileData.cs-UpdatePersonalDetail)-{exception.Message}");
                _logger.LogInformation($"ProfileData.cs-UpdatePersonalDetail()-{exception.StackTrace}");
                return false;
            }
        }
        public bool DisableSkillDetails(int Skill_Id)
        {
            if (Skill_Id <= 0)

                throw new ValidationException("Skill Id is not provided to DAL");

            try
            {
                var skills = _context.skills.Find(Skill_Id);

                //do null validation for user
                if (skills == null) throw new NullReferenceException($"Skill Id not found{Skill_Id}");
                skills.IsActive = false;
                _context.skills.Update(skills);
                _context.SaveChanges();
                return true;

            }


            catch (Exception exception)
            {
                //log "if exception occures"
                _logger.LogError($"ProfileData.cs-DisableSkillDetails()-{exception.Message}");
                _logger.LogInformation($"ProfileData.cs-DisableSkillDetails()-{exception.StackTrace}");
                return false;
            }

        }
        public bool AddLanguage(Language language)
        {


            if (language == null)
                throw new ArgumentNullException("Language details object is not provided to DAL");

            try
            {

                _context.languages.Add(language);
                _context.SaveChanges();
                return true;
            }

            catch (Exception exception)
            {
                //log "unknown exception occured"
                _logger.LogError($"ProfileData.cs-AddLanguage()-{exception.Message}");
                _logger.LogInformation($"ProfileData.cs-AddLanguage()-{exception.StackTrace}");

                return false;
            }


        }
        public bool DisableLanguage(int Language_Id)
        {
            if (Language_Id <= 0)

                throw new ValidationException("Language Id is not provided to DAL");

            try
            {
                var languages = _context.languages.Find(Language_Id);

                //do null validation for user
                if (languages == null) throw new NullReferenceException($"Language Id not found{Language_Id}");
                languages.IsActive = false;
                _context.languages.Update(languages);
                _context.SaveChanges();
                return true;

            }


            catch (Exception exception)
            {
                //log "if exception occures"
                _logger.LogError($"ProfileData.cs-DisableLanguage()-{exception.Message}");
                _logger.LogInformation($"ProfileData.cs-DisableLanguage()-{exception.StackTrace}");
                return false;
            }

        }
        public bool AddSocialMedia(SocialMedia media)
        {
            if (media == null)
                throw new ArgumentNullException("social media details object is not provided to DAL");
            try
            {

                _context.SocialMedias.Add(media);
                _context.SaveChanges();
                return true;
            }

            catch (Exception exception)
            {
                //log "unknown exception occured"
                _logger.LogError($"ProfileData.cs-AddSocialMedia()-{exception.Message}");
                _logger.LogInformation($"ProfileData.cs-AddSocialMedia()-{exception.StackTrace}");

                return false;
            }
        }
        public bool DisableSocialMedia(int SocialMedia_Id)
        {
            if (SocialMedia_Id <= 0)

                throw new ValidationException("SocialMedia Id is not provided to DAL");

            try
            {
                var SocialMedias = _context.SocialMedias.Find(SocialMedia_Id);

                //do null validation for user
                if (SocialMedias == null) throw new NullReferenceException($"SocialMedia Id not found{SocialMedia_Id}");
                SocialMedias.IsActive = false;
                _context.SocialMedias.Update(SocialMedias);
                _context.SaveChanges();
                return true;

            }


            catch (Exception exception)
            {
                //log "if exception occures"
                _logger.LogError($"ProfileData.cs-DisableSocialMedia()-{exception.Message}");
                _logger.LogInformation($"ProfileData.cs-DisableSocialMedia()-{exception.StackTrace}");
                return false;
            }

        }
        public List<Technology> GetallTechnologies()
        {

            try
            {

                return _context.Technologies.ToList();

            }

            catch (Exception exception)
            {
                //log "if exception occures"
                _logger.LogError($"ProfileData.cs-GetallTechnologies()-{exception.Message}");
                _logger.LogInformation($"ProfileData.cs-GetallTechnologies()-{exception.StackTrace}");
                throw exception;
            }
        }

        public Technology GetTechnologyById(int Technologyid)
        {
            if (Technologyid <= 0)

                throw new ValidationException("Technology Id is not provided to DAL");

            try
            {
                Technology technology = GetallTechnologies().Where(x => x.TechnologyId == Technologyid).First();
                if (technology == null) throw new NullReferenceException($"Id not found-{technology}");
                return technology;
            }
            catch (Exception exception)
            {
                _logger.LogError($"ProfileData.cs-GetGetTechnologyById()-{exception.Message}");
                _logger.LogInformation($"ProfileData.cs-GetGetTechnologyById()-{exception.StackTrace}");
                throw exception;
            }
        }
        public bool AddAchievements(Achievements achievement)
        {
            if (achievement == null)
                throw new ArgumentNullException("social media details object is not provided to DAL");
            try
            {

                _context.achievements.Add(achievement);
                _context.SaveChanges();
                return true;
            }

            catch (Exception exception)
            {

                _logger.LogError($"ProfileData.cs-AddAchievements()-{exception.Message}");
                _logger.LogInformation($"ProfileData.cs-AddAchievements()-{exception.StackTrace}");

                return false;
            }
        }

        public List<Achievements> GetallAchievements()
        {

            try
            {

                return _context.achievements.ToList();

            }

            catch (Exception exception)
            {
                //log "if exception occures"
                _logger.LogError($"ProfileData.cs-GetallAchievemets()-{exception.Message}");
                _logger.LogInformation($"ProfileData.cs-GetallAchievemets()-{exception.StackTrace}");
                throw exception;
            }
        }
        public bool DisableAchievement(int achievementId)
        {
            if (achievementId <= 0)

                throw new ValidationException("achievement Id is not provided to DAL");

            try
            {
                var achievement = _context.achievements.Find(achievementId);

                //do null validation for user
                if (achievement == null) throw new NullReferenceException($"SocialMedia Id not found{achievementId}");
                achievement.IsActive = false;
                _context.achievements.Update(achievement);
                _context.SaveChanges();
                return true;

            }


            catch (Exception exception)
            {
                //log "if exception occures"
                _logger.LogError($"ProfileData.cs-RemoveAchievemen()-{exception.Message}");
                _logger.LogInformation($"ProfileData.cs-RemoveAchievemen()-{exception.StackTrace}");
                return false;
            }

        }
        public List<Profile> GetallProfiles()
        {

            try
            {

                return _context.profile.ToList();

            }

            catch (Exception exception)
            {
                //log "if exception occures"
                _logger.LogError($"ProfileData.cs-GetallProfile()-{exception.Message}");
                _logger.LogInformation($"ProfileData.cs-GetallProfile()-{exception.StackTrace}");
                throw exception;
            }
        }
        public Profile GetProfileById(int Profileid)
        {
            if (Profileid <= 0)

                throw new ValidationException("Profile id is not provided to DAL");

            try
            {
                Profile profile = GetallProfiles().Where(x => x.ProfileId == Profileid).First();
                if (profile == null) throw new NullReferenceException($"Id not found-{Profileid}");
                return profile;
            }
            catch (Exception exception)
            {
                _logger.LogError($"ProfileData.cs-GetprofileById()-{exception.Message}");
                _logger.LogInformation($"ProfileData.cs-GetprofileId()-{exception.StackTrace}");
                throw exception;
            }
        }
         public bool AddProfileHistory(ProfileHistory profilehistory)
        {
            if (profilehistory == null)
                throw new ArgumentNullException("profilehistory object is not provided to DAL");
            //if(profilehistory.profile.ProfileStatus!="Approved")throw new Exception("Status should be Approved by Reporting Person");
            try
            {

                _context.profilehistory.Add(profilehistory);
                _context.SaveChanges();
                return true;
            }

            catch (Exception exception)
            {
                //log "unknown exception occured"
                _logger.LogError($"ProfileData.cs-AddProfileHistory()-{exception.Message}");
                _logger.LogInformation($"ProfileData.cs-AddProfileHistory()-{exception.StackTrace}");

                return false;
            }


        }







    }

}