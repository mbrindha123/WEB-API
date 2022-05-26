using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace PMS_API{
     public class Domain
    {
        [Key]
        public int DomainId{get; set;}
        [Required]
        [StringLength(80)]
        public string ? DomainName{get;set;}
        [InverseProperty("domain")]
        public virtual ICollection<Skills>?  skills  {get;set;}
        public int TechnologyId { get; set; }
        [ForeignKey("TechnologyId")]
        [InverseProperty("domains")]
        public virtual Technology? technology { get; set; }

        public bool IsActive { get; set; } = true;
        

        
    }
}