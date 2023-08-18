namespace PilotLogbook
{
    public class SyntheticLogbook
    {
        public uint SynthID{ get; set; }
        public PilotID pilot{ get; set; }
        public DateTime date{ get; set; }
        public SyntheticTrainingDevices type{ get; set; }
        public TimeSpan TotalTime{ get; set; }



        public enum SyntheticTrainingDevices
        {
            Simulator,
            Flight_Training_Device,
            Aviation_Training_Device,
            Flight_Navigation_Procedures_Trainers,
            Basic_Aviation_Training_Devices
        }

        public SyntheticLogbook()
        {

        }

        public SyntheticLogbook(PilotID pid, uint id, DateTime d, SyntheticTrainingDevices s, TimeSpan tt)
        {
            pilot = pid;
            SynthID = id;
            date = d;
            type = s;
            TotalTime = tt;
        }
    }
}
