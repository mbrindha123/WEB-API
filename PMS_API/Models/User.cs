using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace PMS_API{
    
    public class User{
       

        [Key]
        public int UserId{get;set;}
        // [Required]
        // [StringLength(30,MinimumLength =3)]
        // [RegularExpression(
        //     @"^(?!.*([ ])\1)(?!.*([A-Za-z])\2{2})\w[a-zA-Z\s]*$",
        //     ErrorMessage = "Enter a valid Name. Name must not contain any special character or numbers or no more repeated character more than 2times"
        //  )]
        public string Name { get; set; }
        // [Required]
        // [RegularExpression(
        //     @"^([0-9a-zA-Z.]){3,}@[a-zA-z]{3,}(.[a-zA-Z]{2,}[a-zA-Z]*){0,}$",
        //     ErrorMessage = "Enter a valid Email address"
        // )]
        public string Email { get; set; }
        // [Required]
        // [StringLength(30,MinimumLength =8)]
        // [RegularExpression(
        // @"^[A-z][A-z|\.|\s]+$",ErrorMessage ="Enter a valid UserName")]
        public string UserName { get; set; }
        // [Required]
        // [RegularExpression(
        //     @"^(?=.*[A-Za-z])(?=.*\d)(?=.*[@$!%*#?&])[A-Za-z\d@$!%*#?&]{8,}$",
        //     ErrorMessage = "Enter a valid Password. Password must contain Minimum eight characters, at least one letter, one number and one special character"
        //  )]
        public string Password { get; set; }
        //[Required]
        public string MobileNumber { get; set; }
        //[Required]
        public int DesignationId{ get; set; }
        //[Required]
        [ForeignKey("DesignationId")]
        [InverseProperty("users")]
        //[JsonIgnore]
        public virtual Designation? designation { get; set;}
        public string ReportingPerson { get; set; }

        public int OrganisationId{get;set;}
        [ForeignKey("OrganisationId")]
        [InverseProperty("users")]
        //[JsonIgnore]
        public virtual Organisation? organisation {get;set;}

        public int GenderId {get;set;}
        [ForeignKey("GenderId")]
        [InverseProperty("users")]
       //[JsonIgnore]
        public virtual Gender? gender{get;set;}

        [InverseProperty("users")]
        //[JsonIgnore]
        public virtual PersonalDetails? personalDetails { get; set; }
        
        public bool IsActive{get;set;}
        //audit fields
        //createdby  createdon updatedby updatedon\\
        
        public string? CreatedBy{get;set;}
        public DateTime? CreatedOn{get;set;}
        public int? UpdatedBy{get;set;}
        public DateTime? UpdatedOn{get;set;}
        
       


    }
}