using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace ActivityCtr.Models
{
    public class Event
    {
        public int EventId { get; set; }

        [Required(ErrorMessage = "is required.")]
        [MinLength(2, ErrorMessage = "at least 2 characters.")]
        [Display(Name = "Title:")]
        public string Todo { get; set; }

        [Required(ErrorMessage = "is required.")]
        [DataType(DataType.Date)]
        [Display(Name = "Date:")]
        public DateTime Date { get; set; }

        [Required(ErrorMessage = "is required.")]
        [DataType(DataType.Time)]
        [Display(Name = "Time:")]
        public DateTime Time { get; set; }

        [Required(ErrorMessage = "is required.")]
        [Display(Name = "Duration:")]
        public string  Duration { get; set; }

        [Required(ErrorMessage = "is required.")]
        [MinLength(2, ErrorMessage = "at least 2 characters.")]
        [Display(Name = "Description:")]
        public string Description { get; set; }

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

         /////////////FOREIGN KEYS\\\\\\\\\\\\\\\
        public int UserId { get; set; }
        //////////////////////////////////

         //////////NAVIGATION PROPERTIES\\\\\\\\\\\\\
        //One to many relationship
        public User CreatedBy { get; set; }
        //Many to many relationship
        public List<Participant> People { get; set; }
        //////////////////////////////////


    }
}