using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace prodCat.Models
{
    public class Category
    {
        public int CategoryId { get; set; }

        [Required]
        [MinLength(45)]
        [Display(Name = "Name:")]
        public string CategoryName { get; set; }

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
        public int ProductId { get; set; }
        public Product Product {get; set;}
        public List<Association> Relationships {get; set;}
    }
}