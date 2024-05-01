

// See https://aka.ms/new-console-template for more information


using FlightScheduler;
using FlightScheduler.Interfaces;
using Newtonsoft.Json.Serialization;
using System.Runtime.CompilerServices;

const string OrderList = "coding-assigment-orders.json";
const string EscapeCharacter = "xx";
string line;
try
{
    Console.WriteLine("Coding Assignment. Press 1 to User story 1.  Press 2 to see User Story 2" + Environment.NewLine);
    FlightSchedule flightSchedule= new FlightSchedule();
    Scheduler schedule = new Scheduler();
    IRepository repository = new FileOrderList(OrderList);

    while ((line = Console.ReadLine()) != EscapeCharacter)
    {
        if(line == "1")
        {
            Console.WriteLine(flightSchedule.GetFlightSchedule());
            line = string.Empty;
        }
        
        if (line == "2")
        {
            var retText = schedule.AssignOrders(repository.GetAllOrders());
            Console.WriteLine(retText);
            line = string.Empty;
        }
       
        
    }

}
catch(Exception e)
{ 
    Console.WriteLine(e.Message); 
}
