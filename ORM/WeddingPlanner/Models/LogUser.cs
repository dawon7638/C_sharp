using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WeddingPlanner.Models
{
    [NotMapped]///DON'T ADD TO DATABASE\\\
    public class LogUser
    {
        //////////LOGGED IN USER'S EMAIL\\\\\\\\\\\\
        [Required(ErrorMessage = "is required.")]
        [EmailAddress]
        [Display(Name = "Email:")]
        public string LogEmail { get; set; }

        //////////LOGGED IN USER'S PASSWORD\\\\\\\\\\\\
        [Required(ErrorMessage = "is required.")]
        [MinLength(8, ErrorMessage = "at least 8 characters.")]
        [DataType(DataType.Password)]
        [Display(Name = "Password:")]
        public string LogPassword { get; set; }
    }
}