using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace LogInRegistration.Models
{
    public class RegUser
    {
        [Key]
        public int UserId { get; set; }

        [Required(ErrorMessage = "is required!")]
        [MinLength(2, ErrorMessage = "must be at least 2 characters!")]
        [Display(Name = "First Name:")]
        public string FirstName { get; set; }

        [Required(ErrorMessage = "is required!")]
        [MinLength(2, ErrorMessage = "must be at least 2 characters!")]
        [Display(Name = "Last Name:")]
        public string LastName { get; set; }

        [Required(ErrorMessage = "is required!")]
        [EmailAddress]
        [Display(Name = "Email:")]
        public string Email { get; set; }

        [Required(ErrorMessage = "is required!")]
        [MinLength(8, ErrorMessage = "must be at least 8 characters!")]
        [DataType(DataType.Password)]
        [Display(Name = "Password:")]
        public string Password { get; set; }

        [NotMapped]
        [Required(ErrorMessage = "is required!")]
        [Compare("Password",ErrorMessage = "please match password!")]
        [DataType(DataType.Password)]
        [Display(Name = "Confirm Password:")]
        public string PasswordConfirm { get; set; }
        public DateTime CreatedAt { get; set; } = DateTime.Now;
        public DateTime UpdatedAt { get; set; } = DateTime.Now;
    }
}