namespace PilotLogbook
{
    public class Ratings
    {
        public uint RatingID { get; set; }
        public PilotID pilot { get; set; }
        public DateTime DateOfIssue { get; set; }
        public string CustomRating { get; set; }


        public Ratings()
        {

        }

        public Ratings(uint id, PilotID pilotid, DateTime date, string rating)
        {
            RatingID = id;
            pilot = pilotid;
            DateOfIssue = date;
            CustomRating = rating;
        }

    }
}
