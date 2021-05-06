using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace prodCat.Models
{
    public class Product
    {
        public int ProductId { get; set; }

        [Required]
        [MinLength(45)]
        [Display(Name = "Name:")]
        public string ProductName { get; set; }

        [Required]
        [MinLength(4)]
        [Display(Name = "Description:")]
        public string ProductDescription { get; set; }

        [Required]
        [Range(1, 999999)]
        [Display(Name = "Price:")]
        public int ProductPrice { get; set; }

        /////////CREATED AT DATE & TIME\\\\\\\\\\\\\\
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
        public List<Category> Types {get; set;}
        public List<Association> Relationships {get; set;}
        
    }
}