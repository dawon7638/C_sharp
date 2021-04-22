using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WeddingPlanner.Models
{
    public class Guest
    {
        /////////////GUEST ID\\\\\\\\\\\\\\\
        public int GuestId { get; set; }
        //////////////////////////////////


        /////////////FOREIGN KEYS\\\\\\\\\\\\\\\
        /////////////USER ID\\\\\\\\\\\\\\\
        public int UserId { get; set; }
        /////////////WEDDING ID\\\\\\\\\\\\\\\
        public int WeddingId { get; set; }
        //////////////////////////////////

        //////////NAVIGATION PROPERTIES\\\\\\\\\\\\\
        //Associates with User and Wedding class.
        public User User { get; set; }

        public Wedding Wedding {get; set;}
        //////////////////////////////////
    }
}