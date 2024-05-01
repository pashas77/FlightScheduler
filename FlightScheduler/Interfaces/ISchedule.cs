namespace FlightScheduler.Interfaces
{
    public interface ISchedule
    {
        string CheckFlightAvailibility(string destitnation);

        string GetFlightSchedule();
    }
}