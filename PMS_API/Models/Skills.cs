using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PMS_API
{
    public class Skills
    {
        [Key]
        public int SkillId{get;set;}
        public int ProfileId{get;set;}
        public int DomainId{get;set;}
        [ForeignKey("DomainId")]
        [InverseProperty("skills")]
        public virtual Domain? domain { get; set; }

        // public string Technology{get;set;}
        
        
        [ForeignKey("ProfileId")]
        [InverseProperty("skills")]
        public virtual Profile? profile{get;set;}
        public DateTime? CreatedOn { get; set; }

        public int? CreatedBy { get; set; }

        public DateTime? UpdatedOn { get; set; }

        public int? UpdatedBy { get; set; }
        public bool IsActive { get; set; }
    }
}