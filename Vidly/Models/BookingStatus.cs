using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Vidly.Models
{
    public class BookingStatus
    {
        public byte Id { get; set; }
        public string Name { get; set; }

        public static readonly byte Booked = 1;
        public static readonly byte Reserved = 2;
        public static readonly byte Available = 3;
        
    }
}