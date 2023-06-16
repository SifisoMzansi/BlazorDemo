using System.ComponentModel.DataAnnotations;

namespace BlazorDemo.Model
{
    public class DisplayUserModel
    {
        [Required]
        [StringLength(50, ErrorMessage ="First Name is too long")]
        [MinLength(5,ErrorMessage ="First name is too short")]
        public string FirstName { get; set; }
        [Required]
        [StringLength(50, ErrorMessage = "Last Name is too long")]
        [MinLength(5, ErrorMessage = "Last name is too short")]
        public string LastName { get; set; }
        [Required]
        public string EmailAddress { get; set; }
        public DateTime DateOfBitrh { get; set; }
    }
}
