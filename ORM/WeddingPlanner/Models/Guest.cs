using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WeddingPlanner.Models
{
    public class Guest
    {
        /////////////GUEST ID\\\\\\\\\\\\\\\
        public int GuestId { get; set; }
        //////////////////////////////////

        /**********************************************************************
        Relationship properties: foreign keys and navigation properties. 
        Navigation properties are null unless .Include is used. 
        "Object reference not set to an instance of an object"
        will be the error if accessed but not included. 
        **********************************************************************/

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