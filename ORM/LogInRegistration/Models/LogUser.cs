using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace LogInRegistration.Models
{
    [NotMapped]//Don't add table to db
    public class LogUser
    {
        public int LogId { get; set; }
        
        [Required(ErrorMessage = "is required!")]
        [EmailAddress]
        [Display(Name = "Email:")]
        public string LoginEmail { get; set; }

        [Required(ErrorMessage = "is required!")]
        [MinLength(8, ErrorMessage = "Please enter a valid password!")]
        [DataType(DataType.Password)]
        [Display(Name = "Password:")]
        public string LoginPassword { get; set; }

        public DateTime CreatedAt { get; set; } = DateTime.Now;
        public DateTime UpdatedAt { get; set; } = DateTime.Now;
    }
}