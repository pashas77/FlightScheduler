using FlightScheduler.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlightScheduler
{
    public class Scheduler
    {
        private List<Flight> flights;
        private ISchedule flightSchedule;

        public Scheduler()
        {
            // Initialize flights
            flights = new List<Flight>();
            flightSchedule = new FlightSchedule();


    }


    // Method to assign orders to flights
    public string AssignOrders(Dictionary<string, OrderData> orders)
        {
            try
            {
                string text = string.Empty;
                foreach (var order in orders)
                {
                    var scheduleStatus = "order: " + order.Key + ", " + flightSchedule.CheckFlightAvailibility(order.Value.destination) + Environment.NewLine;
                    text += scheduleStatus;

                }
                return text;
            }
            catch
            {
                throw;

            }
           
        }
    }
}
