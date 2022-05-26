using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PMS_API
{
    public class BreakDuration
    {
        [Key]
        public int BreakDuration_Id{get;set;}
        [NotMapped]
        public DateTime Starting_Month{get;set;}
        [NotMapped]
        public DateTime Starting_Year{get;set;}
        [NotMapped]
        public DateTime Ending_Month{get;set;}
        [NotMapped]
        public DateTime Ending_Year{get;set;}
        public string? StartingBreakMonth { get; set; }
        public int? StartingBreakYear { get; set; }
        public string? EndingBreakMonth { get; set; }
        public int? EndingBreakYear { get; set; }
        public int PersonalDetailsId{get;set;}
        [ForeignKey("PersonalDetailsId")]
        [InverseProperty("breakDuration")]
        public virtual PersonalDetails?  personalDetails {get;set;}
        public DateTime? CreatedOn { get; set; }

        public int? CreatedBy { get; set; }

        public DateTime? UpdatedOn { get; set; }

        public int? UpdatedBy { get; set; }
        public bool IsActive { get; set; }
    }
}