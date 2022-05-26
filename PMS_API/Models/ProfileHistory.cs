using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PMS_API
{
    public class ProfileHistory
    {
        [Key]
        public int ProfileHistoryId{ get;set;}
        public int ProfileId{get;set;}
        public DateTime ApprovedDate{get;set;}
        [ForeignKey("ProfileId")]
        public virtual Profile? profile{get;set;}
        
    }
}