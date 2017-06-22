using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Vidly.Models
{
    public class Genre
    {
        public byte Id { get; set; }
        public string Name { get; set; }

        public static readonly byte Action = 1;
        public static readonly byte Comedy = 2;
        public static readonly byte SciFi = 3;
        public static readonly byte Drama = 4;
    }
}