using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
            FlightInstructor, //Certified Flight Instructor (CFI)
            InstrumentFlightInstructor, //Instrument Flight Instructor (CFII)
            MultiEngineFlightInstructor, //Multi-Engine Instructor (MEI)
            AirlineTransport, //Airline Transport Pilot (ATP)
            Custom
        }
    }
}
