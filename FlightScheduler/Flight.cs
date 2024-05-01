using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FlightScheduler.Interfaces;

namespace FlightScheduler
{
    /// <summary>
    /// Class that describes the flight
    /// </summary>
    public class Flight : IFlight
    {
        public int FlightNumber { get; set; }
        public string DepartureCity { get; set; }
        public string ArrivalCity { get; set; }

        public int Capcity { get; set; }
    }
}
