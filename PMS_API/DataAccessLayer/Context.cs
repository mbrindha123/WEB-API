using Microsoft.EntityFrameworkCore;


namespace PMS_API{
    public class Context:DbContext{
        public Context(){}
        public Context(DbContextOptions<Context> options):base(options){

        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
{
        optionsBuilder.UseSqlServer("server=.;database=PMS_Service;trusted_connection=true;");
}
        public DbSet<User> users {get;set;}
        public DbSet<Profile> profile{get;set;}
        public DbSet<PersonalDetails> personalDetails{get;set;}
        public DbSet<Education> educations{get;set;}
        public DbSet<Language> languages{get;set;}
        public DbSet<BreakDuration> breakDurations{get;set;}
        public DbSet<Projects> projects{get;set;}
        public DbSet<Skills> skills{get;set;}
        public DbSet<SocialMedia> SocialMedias{get;set;}
        public DbSet<College> Colleges {get; set;} 
        public DbSet<Designation> Designations {get; set;} 
        public DbSet<Domain> Domains {get; set;} 
        public DbSet<Technology> Technologies {get; set;}
        public DbSet<ProfileStatus> ProfileStatuss {get; set;} 
        public DbSet<Achievements> achievements{get;set;}
        public DbSet<ProfileHistory> profilehistory{get;set;}
        

        
    }

}