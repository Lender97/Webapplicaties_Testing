using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace DonutQueen.Models
{
    public class Winkel
    {
        [Key]
        public int WinkelId { get; set; }

        public string Naam { get; set; }
        public string Straat { get; set; }
        public int Nummer { get; set; }
        public string Gemeente { get; set; }
        public int Postcode { get; set; }
        public double Longitude { get; set; }
        public double Latitude { get; set; }
    }
}