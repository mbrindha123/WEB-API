using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PMS_API
{
    public class SocialMedia
    {
        [Key]
        public int SocialMedia_Id{get;set;}
        public string SocialMedia_Name{get;set;}
        public string SocialMedia_Link{get;set;}
        
        public int PersonalDetailsId{get;set;}
         [ForeignKey("PersonalDetailsId")]
        
        [InverseProperty("socialmedia")]
        public virtual PersonalDetails?  personalDetails {get;set;}
        public DateTime? CreatedOn { get; set; }

        public int? CreatedBy { get; set; }

        public DateTime? UpdatedOn { get; set; }

        public int? UpdatedBy { get; set; }
        public bool IsActive { get; set; }
    }
}