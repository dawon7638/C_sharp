namespace ActivityCtr.Models
{
    public class Participant
    {
        
        /////////////Participant ID\\\\\\\\\\\\\\\
        public int ParticipantId { get; set; }
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
        public int EventId { get; set; }
        //////////////////////////////////

        //////////NAVIGATION PROPERTIES\\\\\\\\\\\\\
        //Associates with User and Activity class.
        public User User { get; set; }

        public Event Event {get; set;}
        //////////////////////////////////
    }
}