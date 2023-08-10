using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
