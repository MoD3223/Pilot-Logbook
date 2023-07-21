using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PilotLogbook
{
    internal class SyntheticLogbook
    {
        //TODO: Add SyntheticLogbook to database
        DateTime date;
        SyntheticTrainingDevices type;
        DateTime TotalTime;



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
