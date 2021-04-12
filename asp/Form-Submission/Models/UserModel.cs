using System.ComponentModel.DataAnnotations;
namespace Form_Submission.Models
{
    /*
        [x] Create a User model with the properties as shown
        [x] Add validations to the model
    */
    // [x] All fields are required

    public class UserModel
    {

        // [x] First Name must be at least 4 characters long
        [Required(ErrorMessage="First Name is Required.")]
        [MinLength(4, ErrorMessage="First Name must be at least 4 characters long.")]
        [Display(Name="Your First Name:")]
        public string FirstName { get; set; }

        // [x] Last Name must be at least 4 characters long
        [Required(ErrorMessage="Last Name is Required.")]
        [MinLength(4, ErrorMessage="Last Name must be at least 4 characters long.")]
        [Display(Name="Your Last Name:")]
        public string LastName { get; set; }

        // [x] Age must be a positive number
        [Required(ErrorMessage="Age is Required.")]
        [Range(18,100, ErrorMessage="You must be at least 18")]
        [Display(Name="Enter Your Age:")]
        public int Age { get; set; }

        // [x] Email must be in valid email format
        [Required(ErrorMessage="Valid email is Required.")]
        [EmailAddress]
        [Display(Name="Your Email:")]
        public string Email { get; set; }

        // [x] Password must be at least 8 characters long
        [Required(ErrorMessage="Valid password is Required.")]
        [MinLength(8, ErrorMessage="Password entered is weak and must be at least 8 characters long.")]
        [DataType(DataType.Password)]
        [Display(Name="Create A Password:")]
        public string Password { get; set; }
    }

}