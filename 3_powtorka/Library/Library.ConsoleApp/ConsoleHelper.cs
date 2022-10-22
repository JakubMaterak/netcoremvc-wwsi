using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.ConsoleApp
{
    internal class ConsoleHelper
    {
        public const string COMMAND_NOT_RECOGNIZED_MESSAGE = "Podana komenda nie jest wspierana!";
        public static string Prompt(string promptText)
        {
            Console.Write(promptText);
            return Console.ReadLine();
        }

        public static int PromptInt(string promptText, Func<int, bool> validator)
        {
            int result;
            while (true)
            {
                Console.Write(promptText);
                try
                {
                    result = Convert.ToInt32(Console.ReadLine());
                }
                catch
                {
                    Console.WriteLine("Podana wartość musi być liczbą, spróbuj jeszcze raz");
                    continue;
                }
                if (validator(result))
                {
                    return result;
                }
            }
        }

        public static int PromptInt(string promptText)
        {
            return PromptInt(promptText, _ => true);
        }

        public static int PromptNonnegativeInt(string propmtText)
        {
            return PromptInt(propmtText, v => v >= 0);
        }

        public static decimal PromptDecimal(string promptText, Func<decimal, bool> validator)
        {
            decimal result;
            while (true)
            {
                Console.Write(promptText);
                try
                {
                    result = Convert.ToDecimal(Console.ReadLine());
                } catch
                {
                    Console.WriteLine("Podana wartość musi być liczbą, spróbuj jeszcze raz");
                    continue;
                }
                if (validator(result)) {
                    return result;
                }
            }
        }

        public static decimal PromptDecimal(string promptText)
        {
            return PromptDecimal(promptText, _ => true);
        }

        public static decimal PromptNonnegativeDecimal(string promptText)
        {
            return PromptDecimal(promptText, d => d >= 0);
        }
    }
}
