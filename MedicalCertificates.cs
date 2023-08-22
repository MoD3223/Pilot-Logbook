namespace PilotLogbook
{
    public class MedicalCertificates
    {
        public uint MedicalID{ get; set; }
        public PilotID pilot{ get; set; }
        public DateTime MedicalDate{ get; set; }
        public string MedicalClass{ get; set; }
        public DateTime FlightDate{ get; set; }
        public DateTime InstrumentDate{ get; set; }



        public MedicalCertificates()
        {
        }

        public MedicalCertificates(uint medID,PilotID pid,DateTime medDate, string medClass, DateTime fliDate, DateTime insDate)
        {
            MedicalID = medID;
            pilot = pid;
            MedicalDate = medDate;
            MedicalClass = medClass;
            FlightDate = fliDate;
            InstrumentDate = insDate;
        }
        
    }
}
