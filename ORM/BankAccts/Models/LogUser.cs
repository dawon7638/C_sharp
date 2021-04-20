using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BankAccts.Models
{
    [NotMapped]//Don't add table to db
    public class LogUser
    {    //////////LOGGED IN USER'S EMAIL\\\\\\\\\\\\
        [Required(ErrorMessage = "is required!")]
        [EmailAddress]
        [Display(Name = "Email Address:")]
        public string LoginEmail { get; set; }

        //////////LOGGED IN USER'S PASSWORD\\\\\\\\\\\\
        [Required(ErrorMessage = "is required!")]
        [MinLength(8, ErrorMessage = "Please enter a valid password!")]
        [DataType(DataType.Password)]
        [Display(Name = "Password:")]
        public string LoginPassword { get; set; }

    }
}