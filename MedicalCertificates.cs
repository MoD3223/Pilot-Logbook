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

    }
}
