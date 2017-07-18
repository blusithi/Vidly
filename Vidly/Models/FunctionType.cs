using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Vidly.Models
{
    public class FunctionType
    {
        public byte Id { get; set; }
        public string Name { get; set; }

        public static readonly byte Private_Party = 1;
        public static readonly byte ClubOrLounge = 2;
        public static readonly byte Live_Music_bar = 3;
        public static readonly byte Awards_Ceremony = 4;
        public static readonly byte Business_Dinner = 5;
        public static readonly byte VIP = 6;
        public static readonly byte Wedding = 7;
    }
}