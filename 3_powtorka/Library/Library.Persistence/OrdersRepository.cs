using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Library.Domain;

namespace Library.Persistence
{
    public class OrdersRepository
    {
        readonly List<Order> database = new();

        public void Insert(Order order)
        {
            database.Add(order);
        }

        public List<Order> GetAll()
        {
            return database;
        }
    }
}
