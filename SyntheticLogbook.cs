using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PilotLogbook
{
    public class SyntheticLogbook
    {
        public uint SynthID;
        public PilotID pilot;
        public DateTime date;
        public SyntheticTrainingDevices type;
        public DateTime TotalTime;



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
