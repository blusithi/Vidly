using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Vidly.Models
{
    public class DressCode
    {
        public byte Id { get; set; }
        public string Name { get; set; }

        public static readonly byte Casual = 1;
        public static readonly byte Smart_Casual = 2;
        public static readonly byte Formal = 3;
    }
}