using Library.Persistence;
using Library.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.ConsoleApp
{
    internal class OrdersService
    {
        private const string MENU_PROMPT = "add - dodaj pozycje do zamowienia\nend - zamknij zamowienie";
        private readonly OrdersRepository _ordersRepository;
        private readonly BooksRepository _booksRepository;
        public OrdersService(OrdersRepository ordersRepository, BooksRepository booksRepository)
        {
            _ordersRepository = ordersRepository;
            _booksRepository = booksRepository;
        }

        public void PlaceOrder()
        {
            // TODO: Implement functioanlity
            Order order = new();
            while (true)
            {
                Console.WriteLine(MENU_PROMPT);
                string command = Console.ReadLine();
                Console.Clear();
                switch (command)
                {
                    case "add":
                        var bookOrdered = CreateOrderdBookFromInput();
                        if (bookOrdered.NumerOrdered > 0)
                        {
                            order.BooksOrderedList.Add(bookOrdered);
                        }
                        break;

                    case "end":
                        _ordersRepository.Insert(order);
                        return;

                    default:
                        Console.WriteLine(ConsoleHelper.COMMAND_NOT_RECOGNIZED_MESSAGE);
                        break;
                }

                Console.Clear();
            }
        }

        private BookOrdered CreateOrderdBookFromInput()
        {
            var books = _booksRepository.GetAll();
            int bookId;
            while (true)
            {
                bookId = ConsoleHelper.PromptNonnegativeInt("Id książki:");
                if (bookId < books.Count)
                {
                    break;
                }
                Console.WriteLine("Książka o takim ID nie istnieje w repozytorium");
            }
            int orderAmount;
            while (true)
            {
                orderAmount = ConsoleHelper.PromptNonnegativeInt("Ilość:");
                if (orderAmount <= books[bookId].ProductsAvailable) {
                    break;
                }
                Console.WriteLine("Nie można zamówić więcej kopii danej książek niż jest w repozytorium");
            }
            return new(bookId, orderAmount);
        }

        public void ListAll()
        {
            var orders = _ordersRepository.GetAll();
            foreach (var order in orders)
            {
                Console.WriteLine($"* {order}");
            }
        }
    }
}
