using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace PMS_API{
     public class Organisation
    {
        [Key]
        public int OrganisationId{get; set;}
        public string OrganisationName{get;set;}
        [InverseProperty("organisation")]
        public virtual ICollection<User>? users{get;set;}
        public bool IsActive { get; set; } = true;
        

        
    }
}