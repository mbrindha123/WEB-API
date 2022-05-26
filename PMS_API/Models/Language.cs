using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PMS_API
{
    public class Language
    {
        [Key]
        public int LanguageId{get;set;}
        public string LanguageName{get;set;}
        public bool Read{get;set;}
        public bool Write{get;set;}
        public bool Speak{get;set;}
        public int PersonalDetailsId{get;set;}
        
        [ForeignKey("PersonalDetailsId")]
        [InverseProperty("language")]

         public virtual PersonalDetails?  personalDetails {get;set;}
        public DateTime? CreatedOn { get; set; }

        public int? CreatedBy { get; set; }

        public DateTime? UpdatedOn { get; set; }

        public int? UpdatedBy { get; set; }
        public bool IsActive { get; set; }

    }
}