using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PilotLogbook
{
    public class Ratings
    {
        public uint RatingID;
        public PilotID pilot { get; set; }
        public DateTime DateOfIssue { get; set; }
        public string? CustomRating { get; set; }

        //TODO: Complete this
    }
}
