using System.ComponentModel.DataAnnotations;

namespace Dojo_Survey_With_Validation.Models
{
    public class UserModel
    {
        // [x] The following fields are required: Name, Location, Favorite Language


        // [x] Name should be no less than two characters
        [Required]
        [MinLength(2)]
        [Display(Name = "Your Name:")]
        public string Name { get; set; }

        // [x] Location Required field
        [Required]
        [Display(Name = "Dojo Location:")]
        public string Location { get; set; }

        // [x] Language Required field
        [Required]
        [Display(Name = "Favorite Language:")]
        public string Language { get; set; }

        // [x] Comment isn't required, but if included, should be more than 20 characters
        [MinLength(20, ErrorMessage="Comment must be at least 20 characters.")]
        [Display(Name = "Comment (optional):")]
        public string Comment { get; set; }

    }
}