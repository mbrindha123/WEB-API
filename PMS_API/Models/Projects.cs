using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PMS_API
{
    public class Projects
    {
        [Key]
        public int ProjectId{get;set;}
        public int ProfileId{get;set;}
        public string ProjectName{get;set;}
        public string ProjectDescription{get;set;}
        [NotMapped]
         public DateTime ProjectStartingMonth{get;set;}
        [NotMapped]
        public DateTime ProjectStartingYear{get;set;}
        [NotMapped]
        public DateTime ProjectEndingMonth{get;set;}
        [NotMapped]
        public DateTime ProjectEndingYear{get;set;}
        public string? StartingMonth { get; set; }
        public int? StartingYear { get; set; }
        public string? EndingMonth { get; set; }
        public int? EndingYear { get; set; }
         
        
        
        public string Designation { get; set; }
        public string ToolsUsed { get; set; }
        public DateTime? CreatedOn { get; set; }

        public int? CreatedBy { get; set; }

        public DateTime? UpdatedOn { get; set; }

        public int? UpdatedBy { get; set; }
        [ForeignKey("ProfileId")]
        [InverseProperty("projects")]
        public virtual Profile? profile{get;set;}
        public bool IsActive { get; set; }
    }
}