using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlightScheduler.Interfaces
{
    public interface IRepository
    {
        Dictionary<string, OrderData> GetAllOrders();
    }
}
