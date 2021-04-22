using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WeddingPlanner.Models
{
    public class Wedding
    {
        /////////////WEDDING ID\\\\\\\\\\\\\\\
        public int WeddingId { get; set; }
        //////////////////////////////////

        //////////WEDDERS NAMES\\\\\\\\\\\\
        [Required(ErrorMessage = "is required.")]
        [MinLength(2, ErrorMessage = "at least 2 characters.")]
        [Display(Name = "Wedder One:")]///WEDDER 1\\\
        public string WedderName1 { get; set; }

        [Required(ErrorMessage = "is required.")]
        [MinLength(2, ErrorMessage = "at least 2 characters.")]
        [Display(Name = "Wedder Two:")]///WEDDER 2\\\
        public string WedderName2 { get; set; }
        //////////////////////////////////

        //////////WEDDING DATE\\\\\\\\\\\\
        [Required(ErrorMessage = "is required.")]
        [DataType(DataType.Date)]
        [Display(Name = "Date:")]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:yyyy/MM/dd}")] 
        public DateTime Date { get; set; }
        //////////////////////////////////

        //////////WEDDING ADDRESS\\\\\\\\\\\\
        [Required(ErrorMessage = "is required.")]
        [Display(Name = "Wedding Address:")]
        public string Address { get; set; }
        //////////////////////////////////



        //////////CREATED AT DATE & TIME\\\\\\\\\\\\\\
        public DateTime CreatedAt { get; set; } = DateTime.Now;
        //////////////////////////////////

        //////////UPDATED AT DATE & TIME\\\\\\\\\\\\\\
        public DateTime UpdatedAt { get; set; } = DateTime.Now;
        //////////////////////////////////

        /////////////FOREIGN KEYS\\\\\\\\\\\\\\\
        public int UserId { get; set; }
        //////////////////////////////////


        //////////NAVIGATION PROPERTIES\\\\\\\\\\\\\
        //One to many relationship
        public User CreatedBy { get; set; }
        //Many to many relationship
        public List<Guest> RSVPs { get; set; }
        //////////////////////////////////

        public string CouplesName()//COMBINE FIRST AND SECOND NAME OF WEDDERS\\\\\\\\\\\\\
        {
            return WedderName1 + " & " + WedderName2;
        }
    }
}