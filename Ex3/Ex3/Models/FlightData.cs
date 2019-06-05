using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.IO;
using System.Linq;
using System.Web;

namespace Ex3.Models
{
    // Data type for the sql schema, main data used by the project.
    public class FlightData
    {
        // Key value for route order.
        public int Id { get; set; }
        [Required]

        // Other data which used by the program.
        public double Lon { get; set; }
        [Required]
        public double Lat { get; set; }
        [Required]
        public double Rudder { get; set; }
        [Required]
        public double Throttle { get; set; }


    }
}