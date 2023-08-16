namespace PilotLogbook
{
    public class Certifications
    {
        public PilotID pilot { get; set; }
        public Grade RecievedGrade { get; set; }
        public string? CustomGrade { get; set; }
        public string Number { get; set; }
        public DateTime DateOfIssue { get; set; }
        public enum Grade
        {
            Student,
            Private,
            Recreational,
            Commercial,
            Certified_Flight_Instructor, //Certified Flight Instructor (CFI)
            Instrument_Flight_Instructor, //Instrument Flight Instructor (CFII)
            Multi_Engine_Flight_Instructor, //Multi-Engine Instructor (MEI)
            Airline_Transport_Pilot, //Airline Transport Pilot (ATP)
            Other
        }

        public Certifications()
        {

        }

        public Certifications(PilotID pilot, Grade recievedGrade, string customGrade, string number, DateTime dateOfIssue)
        {
            this.pilot = pilot;
            RecievedGrade = recievedGrade;
            CustomGrade = customGrade;
            Number = number;
            DateOfIssue = dateOfIssue;
        }
    }
}
