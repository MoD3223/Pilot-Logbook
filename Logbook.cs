using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

namespace PilotLogbook
{
    internal class Logbook
    {
        //TODO: Fix not creating table properly
        public uint LogbookID{ get; set; }
        public PilotID pilot{ get; set; }
        public string? NotesAndEndorsements{ get; set; }
        public DateTime Date{ get; set; } //In UTC, add displaying as 4 digit int
        public string? AircraftType{ get; set; } //Example: Airbus A-320, defaults to Unknown
        public string? AircraftIdent{ get; set; } //Example A-ABCD, defaults to Unknown
        public string? RouteFrom{ get; set; } //ICAO Code, defaults to Unknown
        public DateTime DepartureTime{ get; set; }
        public string? RouteTo{ get; set; } //ICAO Code, defaults to Unknown
        public DateTime ArrivalTime{ get; set; }
        public TimeSpan FlightDuration{ get; set; } //Total flight time
        public DateTime? StickTime{ get; set; } //Cant be higher than flight duration
        public string PilotInCommand{ get; set; } //TODO: All autocomplete of Self
        public string? SecondInCommand{ get; set; }
        public bool CrossCountry{ get; set; }
        public bool? EngineType{ get; set; } //0 - Single engine, 1 - MultiEngine
        public DateTime? MultiPilotTime{ get; set; }
        public DateTime? NightFlyingTime{ get; set; }
        public DateTime? IFRFlyingTime{ get; set; }
        //Time piloted
        public DateTime? PIC{ get; set; }
        public DateTime? CoPilot{ get; set; }
        public DateTime? Dual{ get; set; }
        public DateTime? Instructor{ get; set; }
        //Landings
        public uint Day{ get; set; }
        public uint Night{ get; set; }
        public uint SingleEngineLand{ get; set; }
        public uint MultiEngineLand{ get; set; }




        public Logbook()
        {
            //Empty constructor required by Entity Framework
        }



        public Logbook(uint lid,PilotID pid, DateTime dept, DateTime arr, uint day = 0, uint night = 0, uint single = 0, uint multi = 0, DateTime date = default, string aircraft = null, string ident = null, string from = null, string to = null, DateTime? stick = null, string pilot = "Self", string second = null, bool cross = false, bool? engine = null, DateTime? dateTimePIC = null, DateTime? copilot = null, DateTime? dual = null, DateTime? ins = null, string? notes = null, DateTime? MultiTime = null, DateTime? NightTime = null, DateTime? IFRTime = null)
        {
            if (date == default)
            {
                Date = DateTime.UtcNow;
            }
            else
            {
                Date = date;
            }
            LogbookID = lid;
            this.pilot = pid;
            NotesAndEndorsements = notes;
            DepartureTime = dept;
            ArrivalTime = arr;
            AircraftType = aircraft;
            AircraftIdent = ident;
            RouteFrom = from;
            RouteTo = to;
            FlightDuration = ArrivalTime - DepartureTime;
            StickTime = stick;
            PilotInCommand = pilot;
            SecondInCommand = second;
            CrossCountry = cross;
            EngineType = engine;
            MultiPilotTime = MultiTime;
            NightFlyingTime = NightTime;
            IFRFlyingTime = IFRTime;
            PIC = dateTimePIC;
            CoPilot = copilot;
            Dual = dual;
            Instructor = ins;
            Day = day;
            Night = night;
            SingleEngineLand = single;
            MultiEngineLand = multi;

        }
    }
}
