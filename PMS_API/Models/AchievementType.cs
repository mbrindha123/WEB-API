using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace PMS_API
{
    public class AchievementType
    {
        [Key]
        public int AchievementTypeId{get;set;}
        public string AchievementTypeName{get;set;}

        [InverseProperty("achievementtype")]
        public virtual ICollection<Achievements>? achievements{get;set;}


    }
}
     