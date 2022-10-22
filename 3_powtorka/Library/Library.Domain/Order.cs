using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.Domain
{
    public class Order
    {
        public DateTime Date { get; set; }
        public List<BookOrdered> BooksOrderedList { get; }
        public Order ()
        {
            Date = DateTime.Now;
            BooksOrderedList = new();
        }

        public override string ToString()
        {
            string result = $"Order: {Date}";
            foreach (var book in BooksOrderedList)
            {
                result += $"\n{book}";
            }
            return result;
        }
    }
}
