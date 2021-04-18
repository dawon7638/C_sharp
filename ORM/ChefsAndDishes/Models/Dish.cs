using System;
using System.ComponentModel.DataAnnotations;

namespace ChefsAndDishes.Models
{
    public class Dish
    {
        [Key]//Required for all assignments
        /////////////DISH ID\\\\\\\\\\\\\\\
        public int DishId { get; set; }

        //////////////////////////////////

        ///////////DISH NAME\\\\\\\\\\\\
        [Required(ErrorMessage = "Please name your dish!")]
        [Display(Name = "Name of Dish:")]
        [MaxLength(45)]
        public string Name { get; set; }
        //////////////////////////////////

        //////////TASTINESS\\\\\\\\\\\\\\
        [Required]
        [Display(Name = "Tastiness:")]
        [Range(1, 5, ErrorMessage = "Tastiness must be between 1 and 5!")]
        public int Tastiness { get; set; }
        //////////////////////////////////

        //////////CALORIES\\\\\\\\\\\\\\
        [Required]
        [Display(Name = "# of Calories:")]
        [Range(1, 9999, ErrorMessage = "Calories must be greater than 0!")]
        public int Calories { get; set; }
        //////////////////////////////////

        //////////DESCRIPTION\\\\\\\\\\\\\
        [Required(ErrorMessage = "Please describe the dish!")]
        [Display(Name = "Description:")]
        public string Description { get; set; }
        //////////////////////////////////

        //////////CREATED AT DATE & TIME\\\\\\\\\\\\\\
        public DateTime CreatedAt { get; set; } = DateTime.Now;
        //////////////////////////////////

        //////////UPDATED AT DATE & TIME\\\\\\\\\\\\\\
        public DateTime UpdatedAt { get; set; } = DateTime.Now;
        //////////////////////////////////

        //////RELATIONSHIP(navigation) PROPERTY AND *FOREIGN KEY FOR CHEF MODEL||||||
        // 1 Chef: many Dish.
        [Display(Name = "Chef")]
        public int ChefId { get; set; }//Foreign Key
        public Chef Cooker { get; set; }//Navigation Property
        //////////////////////////////////

    }
}