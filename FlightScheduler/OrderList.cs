using FlightScheduler.Interfaces;
using System.Text.Json;
using System.Text.Json.Nodes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlightScheduler
{

    /// <summary>
    /// Currently we get data from a file but in the future we may get it from a database hence the reposotory pattern
    /// </summary>
    public class FileOrderList : IRepository
    {
        private string _filePath;
        public FileOrderList(string filePath) 
        {
            _filePath = filePath;
        }

        public Dictionary<string, OrderData> GetAllOrders()
        {
            try
            {
                var orders = JsonSerializer.Deserialize<Dictionary<string, OrderData>>(File.ReadAllText(_filePath));
               
                return orders;
            }
            catch
            {
                throw; // throw the exception up to the higher level to deal with also log
            }
        }
    }


    public class DatabaseOrderList : IRepository
    {
        public Dictionary<string, OrderData> GetAllOrders()
        {
            throw new NotImplementedException();
        }
    }
}
