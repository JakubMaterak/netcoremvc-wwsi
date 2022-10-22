using Library.ConsoleApp;
using Library.Domain;
using Library.Persistence;

internal class Program
{
    const string ADMIN_LOGIN = "Admin";
    const string ADMIN_PASSWORD = "password";

    private static void Main(string[] args)
    {
        Book book = new Book("C# 10 and .NET 6 – Modern Cross-Platform Development", "Mark J. Price", 2021, "978-1801077361", 9001, 219.22m);
        BooksRepository repository = new BooksRepository();
        string login = ConsoleHelper.Prompt("Login:");
        string password = ConsoleHelper.Prompt("Hasło:");
        if (login == ADMIN_LOGIN && password == ADMIN_PASSWORD)
        {
            Console.WriteLine("Access Granted");
        } else
        {
            Console.WriteLine("Access Denied");
            return;
        }

        BooksRepository booksRepository = new();
        BooksService booksService = new(booksRepository);

        OrdersRepository ordersRepository = new();
        OrdersService ordersService = new(ordersRepository, booksRepository);
        string inputLine;
        while (true)
        {
            Console.WriteLine("Możwlie komendy to: 'wyjdz', 'dodaj', 'usun', 'wypisz' ,'zmien' ,'dodaj zamowienie', 'lista zamowien'");
            Console.Write("Podaj komendę:");
            inputLine = Console.ReadLine().Trim();

            Console.Clear();

            if (inputLine == "wyjdz")
            {
                break;
            }

            switch (inputLine)
            {
                case "dodaj":
                    booksService.AddBook();
                    break;

                case "usun":
                    booksService.RemoveBook();
                    break;

                case "wypisz":
                    booksService.ListBooks();
                    break;

                case "zmien":
                    booksService.ChangeState();
                    break;

                case "dodaj zamowienie":
                    ordersService.PlaceOrder();
                    break;

                case "lista zamowien":
                    ordersService.ListAll();
                    break;

                default:
                    Console.WriteLine(ConsoleHelper.COMMAND_NOT_RECOGNIZED_MESSAGE);
                    break;
            }

            Console.WriteLine("Perss AnyKey");
            Console.ReadKey();
            Console.Clear();
        }
    }
}