internal class Program
{
    private static void Main()
    {
        // **W przypadku napotkania takiej samej nazwy w więcej niż jednym poleceniu dodaję liczbę na koniec jej nazwy.**

        // === Zadanie 2 ===

        Console.WriteLine("Podaj swoje imię:");
        var name = Console.ReadLine();
        Console.WriteLine("Hello " + name);


        // === Zadanie 3 === 


#pragma warning disable CS0219 // Zmienna jest przypisana, ale jej wartość nie jest nigdy używana
#pragma warning disable IDE0059 // Niepotrzebne przypisanie wartości
        int result = 5 + 9;
#pragma warning restore IDE0059 // Niepotrzebne przypisanie wartości
#pragma warning restore CS0219 // Zmienna jest przypisana, ale jej wartość nie jest nigdy używana


        // == Operatory ==
        // === Zadanie 1 ===

        int number = 123;
        float money = 1.23f;
        string text = "text";
        bool isLogged = false;
        char myChar = 'K';
        decimal price = 1.23456789m;
        Console.WriteLine($"numer={number}");
        Console.WriteLine($"money={money}");
        Console.WriteLine($"text={text}");
        Console.WriteLine($"isLogged={isLogged}");
        Console.WriteLine($"myChar={myChar}");
        Console.WriteLine($"price={price}");


        // === Zadanie 2 ===

        string myAge = "Age: ";
        int wifeAge = 18;
        var result2 = myAge + wifeAge;
        Console.WriteLine(result2);
        // Wnioski:
        // Dodanie zmiennej typu 'int' do zmiennej typu 'string' skutkuje wynikiem typu string, który jest równoważny
        // dodaniu do zmiennej typu 'string' wyniku wywołania metody 'ToString()' na wartości typu 'int'.
        // Uogólnienie wniosku: Dla typów innych niż 'string' dodanie typu innego niż 'string' skutkuje tego typu wynikiem.


        // === Zadanie 3 ===

        bool isTrue = true;
        bool isFalse = false;
        bool isReallyTrue = true;

        bool and = isTrue && isFalse;
        bool or = isTrue || isReallyTrue;
        bool negative = !isFalse;
        Console.WriteLine($"and={and}");
        Console.WriteLine($"or={or}");
        Console.WriteLine($"negative={negative}");


        // === Zadanie 4 ===

        double a = 5;
        double b = 12;

        double add = a + b;
        double sub = a - b;
        double div = a / b;
        double mod = a % b;

        Console.WriteLine($"add={add}");
        Console.WriteLine($"sub={sub}");
        Console.WriteLine($"div={div}");
        Console.WriteLine($"mod={mod}");


        // === Zadanie 5 ===

        string a5 = "Ala ", b5 = "ma ", c5 = "kota.";
        string result5 = a5 + b5 + c5;
        Console.WriteLine(result5);
        // Wnioski: Wynikiem wartości typu 'string' jest ciąg znaków ('string') zawierający treść pierwszego a następnie
        // drugiego ciągu znaków. Dodanie 3 ciagów znaków jest równoważne (pomijając utworzenie zmiennej 'temp'):
        // string temp = a + b;
        // string result = temp + c;
        // Więc wynikiem 'a + b' jest ciąg "Ala ma " po czym wykonuje się dodanie '"Ala ma " + c' czego wynikiem jest ciąg
        // "Ala ma kota.".


        // == Instrukcje sterujące i pętle ==
        // === Zadanie 1 === 


        int n1 = 10;
        int n2 = 20;
        if (n1 > n2)
        {
            Console.WriteLine("n1 jest większe od n2");
        }
        else if (n2 > n1)
        {
            Console.WriteLine("n2 jest większe od n1");
        }
        else
        {
            Console.WriteLine("n1 jest równe n2");
        }

        // === Zadanie 2 ===

        for (int i4 = 0; i4 < 10; i4++)
        {
            Console.WriteLine("C#");
        }

        int i2 = 0;
        while (i2 < 10)
        {
            Console.WriteLine("C#");
            i2++;
        }


        // === Zadanie 3 ===

        int i = 10;
        for (int j = 0; j <= i; j++)
        {
            string parity = j % 2 == 0 ? "Parzysta" : "Nieparzysta";
            Console.WriteLine($"{j} - {parity}");
        }

        // === Zadanie 4* ===

        int n = 5;
        string line = "*";
        for (int i3 = 1; i3 <= n; i3++)
        {
            Console.WriteLine(line);
            line += " *";
        }


        // === Zadanie 5* ===

        int exam = 57;

        string examResultMessage = exam switch
        {
            >= 0 and <= 39 => "Ocena Niedostateczna",
            >= 40 and <= 54 => "Ocena Dopuszczająca",
            >= 55 and <= 69 => "Ocena Dostateczna",
            >= 70 and <= 84 => "Ocena Dobra",
            >= 85 and <= 98 => "Ocena Bardzo Dobra",
            >= 99 and <= 100 => "Ocena Celująca",
            _ => "Wartość poza zakresem",
        };
        Console.WriteLine(examResultMessage);

        // == Kolekcje ==
        // === Zadanie 1 ===

        string[] color = { "czerwony", "zielony", "niebieski" };
        Console.WriteLine($"Mój pierwszy kolor to: {color[0]}");
#pragma warning disable IDE0056 // Użyj operatora indeksu
        Console.WriteLine($"Mój ostatni kolor to: {color[color.Length - 1]}");
#pragma warning restore IDE0056 // Użyj operatora indeksu

        // === Zadanie 2 ===

        int[] numbers = { 0, 1, 2, 3, 4, 5, 6, 7, 8, 9 };
        for (int i6 = 0; i6 < numbers.Length; i6++)
        {
            Console.WriteLine($"Liczba: {numbers[i6]}");
        }
        foreach (int num in numbers)
        {
            Console.WriteLine($"Liczba: {num}");
        }
        int i7 = 0;
        while (i7 < numbers.Length)
        {
            Console.WriteLine($"Liczba: {numbers[i7]}");
            i7++;
        }

        // === Zadanie 3 ===
        List<string> fruits = new() { "Pomidor", "Jabłko", "Banan", "Gruszka" };
        Console.WriteLine(string.Join(", ", fruits));
        fruits.Remove("Gruszka");
        fruits.RemoveAt(0);
        Console.WriteLine(string.Join(", ", fruits));
    }
}