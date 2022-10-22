using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.Domain
{
    public class BookOrdered
    {
        public int BookId { get; set; }
        public int NumerOrdered { get; set; }

        public BookOrdered(int bookId, int numerOrdered)
        {
            BookId = bookId;
            NumerOrdered = numerOrdered;
        }

        public override string ToString()
        {
            return $"Book: {BookId} Count: {NumerOrdered}";
        }
    }
}
