using Library.Domain;
using Library.Persistence;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;

namespace Library.ConsoleApp
{
    internal class BooksService
    {
        private readonly BooksRepository _repository;
        public BooksService(BooksRepository _repository)
        {
            this._repository = _repository;
        }
        public void AddBook()
        {
            string title = ConsoleHelper.Prompt("Tytuł:");
            string author = ConsoleHelper.Prompt("Autor:");
            int publicationYear = ConsoleHelper.PromptNonnegativeInt("Rok publikacji:");
            string isbn = ConsoleHelper.Prompt("ISBN:");
            int productsAvailable = ConsoleHelper.PromptNonnegativeInt("Ilość dostępnych kopii:");
            decimal price = ConsoleHelper.PromptNonnegativeDecimal("Cena:");
            Book book = new(title, author, publicationYear, isbn, productsAvailable, price);
            _repository.Insert(book);
        }

        public void RemoveBook()
        {
            string title = ConsoleHelper.Prompt("Tytuł książki do usunięcia:");
            try
            {
                _repository.RemoveByTitle(title);
            }
            catch (KeyNotFoundException)
            {
                Console.WriteLine("BŁAD: Nie znaleziono książki");
            }
        }

        public void ListBooks()
        {
            foreach (var book in _repository.GetAll())
            {
                Console.WriteLine($"* {book}");
            }
        }

        public void ChangeState()
        {
            string title = ConsoleHelper.Prompt("Tytuł książki do zmiany stanu:");
            int state = ConsoleHelper.PromptInt("Zmiana stanu magazynowego(np. -1 by odjąć jedną książkę od obecnego, +1 by dodać):");
            try
            {
                _repository.ChangeState(title, state);
            } catch (KeyNotFoundException)
            {
                Console.WriteLine("BŁAD: Nie znaleziono książki");
            }
        }
    }
}
