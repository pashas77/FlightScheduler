using FlightScheduler.Interfaces;
using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using System.Threading.Tasks;

namespace FlightScheduler
{
    /// <summary>
    /// Class to create flight schedule or in the future get flights from elsewhere
    /// </summary>
    public class FlightSchedule : ISchedule
    {
        private List<Dictionary<string, Flight>> flightDays; //list of days and the flights that occur there
        private Dictionary<string, string> CityNameConversion; 
        private const string FlightNotFound = "No matching flight found";
        private const string AllScheduledFlightsFull = "flightNumber: not scheduled";
        public FlightSchedule()
        {
            flightDays = new List<Dictionary<string, Flight>>();
            CreatreFlightSchedule();
            CityNameConversion = new Dictionary<string, string>()
            {
                {"YUL", "Montreal" },
                {"YYZ", "Toronto" },
                {"YVR",  "Vancouver" },
                {"YYC", "Calgary" }

            };
        }
        /// <summary>
        // Checks the availibility of on the day based on the destination, if it is availible decrement capacity, if capacity is full move to the next day
        // We do search everything, however the dictionary search limits the searching of all the elements
        /// </summary>
        /// <param name="destitnation"></param>
        /// <returns></returns>
        public string CheckFlightAvailibility(string destitnation)
        {
           for (int i=0; i< flightDays.Count; i++)
            {
                if (!flightDays[i].ContainsKey(destitnation))
                {
                    return destitnation + " "+ FlightNotFound;
                }

                if (flightDays[i][destitnation].Capcity > 0)
                {
                    flightDays[i][destitnation].Capcity--; //decrease the capacity
                    return GetFormattedString(flightDays[i][destitnation], i+1);
                }
           
            }

           return AllScheduledFlightsFull;
        }

        string GetFormattedString(Flight flight, int flightDay)
        {
            return ("Flight: " + flight.FlightNumber.ToString() + " departure:" + 
                flight.DepartureCity + " arrival: " + flight.ArrivalCity + " day: " + flightDay.ToString()) +
                Environment.NewLine;
        }

        // Method to schedule flights
        private void CreatreFlightSchedule()
        {
            var flightdayOne = new Dictionary<string, Flight>
            {
                {"YYZ", new Flight { FlightNumber = 1, DepartureCity = "YUL", ArrivalCity = "YYZ", Capcity = 20 } },
                {"YYC", new Flight { FlightNumber = 2, DepartureCity = "YUL", ArrivalCity = "YYC",  Capcity = 20 } },
                {"YVR", new Flight { FlightNumber = 3, DepartureCity = "YUL", ArrivalCity = "YVR" , Capcity = 20 } },

            };

            var flightdayTwo = new Dictionary<string, Flight>
            {
                { "YYZ", new Flight { FlightNumber = 4, DepartureCity = "YUL", ArrivalCity = "YYZ", Capcity = 20 } },
                { "YYC", new Flight { FlightNumber = 5, DepartureCity = "YUL", ArrivalCity = "YYC", Capcity = 20 } },
                { "YVR", new Flight { FlightNumber = 6, DepartureCity = "YUL", ArrivalCity = "YVR", Capcity = 20 } },
            };

            flightDays.Add(flightdayOne);
            flightDays.Add(flightdayTwo);
        }

        public string GetFlightSchedule()
        {
            string text = "";
            int day = 1;
            foreach (var flightDay in flightDays)
            {
                text += "Day : " + day.ToString() + Environment.NewLine;
                foreach(var flight in flightDay)
                {
                    text += "Flight " + flight.Value.FlightNumber + ": " + CityNameConversion[flight.Value.DepartureCity] +
                        "(" + flight.Value.DepartureCity + ")" + "to" + CityNameConversion[flight.Value.ArrivalCity] +
                        "(" + flight.Value.ArrivalCity + ")" + Environment.NewLine ;


                }
                day++;
            }
            return text;
        }
      
    }
}
