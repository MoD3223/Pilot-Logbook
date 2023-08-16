namespace PilotLogbook
{
    internal class Logbook
    {
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
        public TimeSpan? StickTime{ get; set; } //Cant be higher than flight duration
        public string PilotInCommand{ get; set; } //TODO: All autocomplete of Self
        public string? SecondInCommand{ get; set; }
        public bool CrossCountry{ get; set; }
        public bool? EngineType{ get; set; } //0 - Single engine, 1 - MultiEngine
        public TimeSpan? MultiPilotTime{ get; set; }
        public TimeSpan? NightFlyingTime{ get; set; }
        public TimeSpan? IFRFlyingTime{ get; set; }
        //Time piloted
        public TimeSpan? PIC{ get; set; }
        public TimeSpan? CoPilot{ get; set; }
        public TimeSpan? Dual{ get; set; }
        public TimeSpan? Instructor{ get; set; }
        //Landings
        public uint Day{ get; set; }
        public uint Night{ get; set; }
        public uint SingleEngineLand{ get; set; }
        public uint MultiEngineLand{ get; set; }




        public Logbook()
        {
            //Empty constructor required by Entity Framework
        }



        public Logbook(uint lid,PilotID pid, DateTime dept, DateTime arr, uint day = 0, uint night = 0, uint single = 0, uint multi = 0, DateTime date = default, string aircraft = null, string ident = null, string from = null, string to = null, TimeSpan? stick = null, string pilot = "Self", string second = null, bool cross = false, bool? engine = null, TimeSpan? dateTimePIC = null, TimeSpan? copilot = null, TimeSpan? dual = null, TimeSpan? ins = null, string? notes = null, TimeSpan? MultiTime = null, TimeSpan? NightTime = null, TimeSpan? IFRTime = null)
        {
            FlightDuration = ArrivalTime - DepartureTime;

            if (stick > FlightDuration || MultiTime > FlightDuration || NightTime > FlightDuration || IFRTime > FlightDuration || dateTimePIC > FlightDuration || copilot > FlightDuration || dual > FlightDuration || ins > FlightDuration)
            {
                //TODO: Add error
                //Error, none of these values can be higher than Flight Duration
            }



            if (date == default)
            {
                Date = DateTime.UtcNow;
            }
            else
            {
                Date = date.ToUniversalTime();
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
