using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BankAccts.Models
{
    public class User
    {
        [Key]
        /////////////USER ID\\\\\\\\\\\\\\\
        public int UserId { get; set; }
        //////////////////////////////////

        //////////USER'S NAME\\\\\\\\\\\\
        [Required(ErrorMessage = "is required!")]
        [MinLength(2, ErrorMessage = "must be at least 2 characters!")]
        [MaxLength(45)]
        [Display(Name = "First Name:")]
        public string FirstName { get; set; }///FIRST NAME\\\
        //////////////////////////////////

        [Required(ErrorMessage = "is required!")]
        [MinLength(2, ErrorMessage = "must be at least 2 characters!")]
        [MaxLength(45)]
        [Display(Name = "Last Name:")]
        public string LastName { get; set; }///FIRST NAME\\\
        //////////////////////////////////

        //////////USER'S EMAIL\\\\\\\\\\\\
        [Required(ErrorMessage = "is required!")]
        [EmailAddress]
        [Display(Name = "Email:")]
        [MaxLength(45)]
        public string Email { get; set; }
        //////////////////////////////////

        //////////USER'S PASSWORD\\\\\\\\\\\\
        [Required(ErrorMessage = "is required!")]
        [MinLength(8, ErrorMessage = "must be at least 8 characters!")]
        [MaxLength(255)]
        [DataType(DataType.Password)]
        [Display(Name = "Password:")]
        public string Password { get; set; }
        //////////////////////////////////

        //////////USER'S CONFIRM PASSWORD\\\\\\\\\\\\
        [NotMapped]
        [Required(ErrorMessage = "is required!")]
        [Compare("Password", ErrorMessage = "please match password!")]
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

        //////RELATIONSHIP(navigation)PROPERTY FOR TRANSACTION MODEL||||||
        // 1 USER: many TRANSACTIONS.
        public List<Transaction> Transactions { get; set; }
        //////////////////////////////////
        public string FullName()//COMBINE FIRST AND LAST NAME OF USER\\\\\\\\\\\\\
        {
            return FirstName + " " + LastName;
        }
    }
}