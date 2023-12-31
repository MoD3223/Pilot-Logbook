﻿namespace PilotLogbook
{
    public class PilotID
    {
        public int? PhoneNumber { get; set; }
        public string? Address { get; set; }
        [System.ComponentModel.DataAnnotations.Key]
        public string Login { get; set; } //Login is also name of the profile
        public string? Password { get; set; }

        //ICollection is preferred interface by Entity Framework
        internal ICollection<Logbook> Logbooks { get; set; }
        internal ICollection<Ratings> Ratings { get; set; }
        internal ICollection<Certifications> Certifications { get; set; }
        internal ICollection<SyntheticLogbook> Synths { get; set; }
        internal ICollection<MedicalCertificates> Med { get; set; }


        public PilotID()
        {

        }

        public PilotID(string login, string? pass, int? phone = null, string? address = null)
        {
            Login = login;
            Password = pass;
            PhoneNumber = phone;
            Address = address;
        }
    }
}
