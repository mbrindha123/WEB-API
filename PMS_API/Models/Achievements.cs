using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace PMS_API
{
    public class Achievements
    {
        [Key]
        public int AchievementId{get;set;}
        public int ProfileId{get;set;}
        public int AchievementTypeId{get;set;}
        
        public string base64header {get;set;}
        public byte[]? Image{get;set;}
        

        [ForeignKey("ProfileId")]
        [InverseProperty("achievements")]
       public virtual Profile? profile {get;set;}

        [ForeignKey("AchievementTypeId")]
        [InverseProperty("achievements")]
        public virtual AchievementType? achievementtype{get;set;}
        public bool IsActive{get;set;}
         public DateTime? CreatedOn { get; set; }

        public int? CreatedBy { get; set; }

        public DateTime? UpdatedOn { get; set; }

        public int? UpdatedBy { get; set; }
    }
}