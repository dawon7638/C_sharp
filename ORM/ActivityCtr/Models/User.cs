using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ActivityCtr.Models
{
    public class User
    {
        /////////////USER ID\\\\\\\\\\\\\\\
        public int UserId { get; set; }//KEY
        //////////////////////////////////

        //////////USER'S NAME\\\\\\\\\\\\
        [Required(ErrorMessage = "is required.")]
        [MinLength(2, ErrorMessage = "at least 2 characters.")]
        [Display(Name = "Name:")]///FIRST NAME\\\
        public string Name { get; set; }

        //////////////////////////////////

        //////////USER'S EMAIL\\\\\\\\\\\\
        [Required(ErrorMessage = "is required.")]
        [EmailAddress]
        [Display(Name = "Email:")]
        public string Email { get; set; }
        //////////////////////////////////

        //////////USER'S PASSWORD\\\\\\\\\\\\
        [Required(ErrorMessage = "is required.")]
        // [RegularExpression("[a-zA-Z]{1,}([@$!%*#?&]{1,})[0-9]{1,}", ErrorMessage="Must contain at least 1 number, 1 letter and a special character")]
        [MinLength(8, ErrorMessage = "at least 8 characters.")]
        [DataType(DataType.Password)]
        [Display(Name = "Password:")]
        public string Password { get; set; }
        //////////////////////////////////

        //////////USER'S CONFIRM PASSWORD\\\\\\\\\\\\
        [NotMapped]
        [Required(ErrorMessage = "is required.")]
        [Compare("Password", ErrorMessage = "please match password.")]
        [DataType(DataType.Password)]
        [Display(Name = "Confirm Password:")]
        public string PasswordConfirm { get; set; }
        //////////////////////////////////

        //////////CREATED AT DATE & TIME\\\\\\\\\\\\\\
        public DateTime CreatedAt { get; set; } = DateTime.Now;
        //////////////////////////////////

        //////////UPDATED AT DATE & TIME\\\\\\\\\\\\\\
        public DateTime UpdatedAt { get; set; } = DateTime.Now;
        //////////////////////////////////

        /**********************************************************************
        Relationship properties: foreign keys and navigation properties. 
        Navigation properties are null unless .Include is used. 
        "Object reference not set to an instance of an object"
        will be the error if accessed but not included. 
        **********************************************************************/

        //NAVIGATION PROPERTIES
        //Many to many relationship
        public List<Participant> People { get; set; }
        // One to many relationship:User can create Many weddings. 

        public List<Event> todos { get; set; }
        //////////////////////////////////


        public string FullName()
        {
            return Name;
        }
    }
}