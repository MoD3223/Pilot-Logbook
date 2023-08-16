namespace PilotLogbook
{
    public class SyntheticLogbook
    {
        public uint SynthID{ get; set; }
        public PilotID pilot{ get; set; }
        public DateTime date{ get; set; }
        public SyntheticTrainingDevices type{ get; set; }
        public DateTime TotalTime{ get; set; }



        public enum SyntheticTrainingDevices
        {
            Simulator,
            FlightTrainingDevice,
            AviationTrainingDevice,
            FlightNavigationProceduresTrainers,
            BasicAviationTrainingDevices
        }
    }
}
