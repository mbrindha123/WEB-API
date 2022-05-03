using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace PROFILE.Models{
     public class College
    {
        [Key]
        public int CollegeId{get; set;}
        [Required]
        [StringLength(80)]
        public string CollegeName{get;set;}
        public bool IsActive { get; set; } = true;
        

        
    }
}