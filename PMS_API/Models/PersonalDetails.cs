using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PMS_API
{
    public class PersonalDetails
    {
        [Key]
        public int PersonalDetailsId{get;set;}
        public int ProfileId{get;set;}
        public string Objective{get;set;}
        public DateTime DateOfBirth{get;set;}
        public string Nationality{get;set;}
        public DateTime DateOfJoining{get;set;}
        public string base64header {get;set;}

        public byte[]? Image{get;set;}
        public DateTime? CreatedOn { get; set; }
        

        public int? CreatedBy { get; set; }

        public DateTime? UpdatedOn { get; set; }
        
        public int? UpdatedBy { get; set; }
        public int UserId { get; set; }
        

        
        [InverseProperty("personalDetails")]
        public virtual ICollection<Language>? language { get; set; }
        
        [InverseProperty("personalDetails")]
        public virtual ICollection<BreakDuration>? breakDuration { get; set; }
 
        [InverseProperty("personalDetails")]
        public virtual ICollection<SocialMedia>? socialmedia { get; set; }
        [ForeignKey("UserId")]
         [InverseProperty("personalDetails")]
        public virtual User? users { get; set; }
        [ForeignKey("ProfileId")]
        [InverseProperty("personalDetails")]
        public virtual Profile? profile{get;set;}
        public bool IsActive{ get; set;}
    }
}
