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
        public OrdersService(OrdersRepository ordersRepository)
        {
            _ordersRepository = ordersRepository;
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
                        order.BooksOrderedList.Add(bookOrdered);
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
            int bookId = ConsoleHelper.PromptNonnegativeInt("Id książki:");
            int orderAmount = ConsoleHelper.PromptNonnegativeInt("Ilość:");
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
