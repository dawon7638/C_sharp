using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace ChefsAndDishes.Models
{
    public class Chef
    {
        [Key]//Required for all assignments
        /////////////Chef ID\\\\\\\\\\\\\\\
        public int ChefId { get; set; }
        //////////////////////////////////

        //////////CHEF'S NAME\\\\\\\\\\\\
        [Required(ErrorMessage = "Please enter the Chef's first name!")]
        [Display(Name = "Chef's First Name:")]
        [MaxLength(45)]
        [MinLength(1)]
        public string FirstName { get; set; }///FIRST NAME\\\

        [Required(ErrorMessage = "Please enter the Chef's last name!")]
        [Display(Name = "Chef's Last Name:")]
        [MaxLength(45)]
        [MinLength(1)]
        public string LastName { get; set; }//LAST NAME\\\
        //////////////////////////////////

        //////////CHEF'S DOB\\\\\\\\\\\\
        [Required(ErrorMessage = "Please enter the Chefs birthday!")]
        [Display(Name = "Date of Birth:")]
        [DataType(DataType.Date)]
        public DateTime DOB {get; set;}//DATE OF BIRTH

        //////////CREATED AT DATE & TIME\\\\\\\\\\\\\\
        public DateTime CreatedAt { get; set; } = DateTime.Now;
        //////////////////////////////////

        //////////UPDATED AT DATE & TIME\\\\\\\\\\\\\\
        public DateTime UpdatedAt { get; set; } = DateTime.Now;
        //////////////////////////////////

        //////RELATIONSHIP(navigation)PROPERTY FOR DISH MODEL||||||
        //1 Chef: many Dish.
        public List<Dish> Dishes { get; set; }
        //////////////////////////////////

        //METHODS
        public string FullName()//COMBINE FIRST AND LAST NAME OF CHEF\\\\\\\\\\\\\
        {
            return FirstName + " " + LastName;
        }

    }
}