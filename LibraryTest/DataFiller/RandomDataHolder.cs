using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Automatic_Library.Data.ObjectModel;
using Automatic_Library.Data.ObjectModel.BookEvent;

namespace LibraryTest.DataFiller
{

    class RandomDataHolder
    {
        public List<Reader> Readers = new List<Reader>();
        public List<BookDescription> BookDescriptions = new List<BookDescription>();
        public List<BookCopy> BookCopies = new List<BookCopy>();
        public List<BookEvent> BookEvents = new List<BookEvent>();

        private List<string> _names = new List<string>();
        private List<string> _lastNames = new List<string>();
        private List<string> _titles = new List<string>();
        private List<string> _authors = new List<string>();
        private List<string> _publishers = new List<string>();
        private Random rnd = new Random();

        public RandomDataHolder()
        {
            populateLists();
            generateRandomReaders();
            generateRandomBookDescriptions();
            generateRandomBookCopies();
           //generateRandomBookEvents();
            
   
        }

        private void populateLists()
        {
            _names = new List<string> { "Dominik", "Sebastian","Janusz","Filip","Maciej","Roman","Pawel","Tomek","Izak","Andrzej","Juliusz" };
            _lastNames = new List<string> { "Kolwaski", "Nowak", "Cezar", "Karski", "Kujawski", "Baczynski", "Gruda", "Raj", "Makowski", "Nawrocki", "Fiszer" };
            _titles = new List<string> { "Eragon", "Wladca Pierscieni", "Hobbit", "Inny Swiat", "Archipelag Gulag", "Diuna", "Metro 2033", "Harry Potter", "Mitologia", "Maly Ksiaze" ,"Wiedzmin","Krzyzacy","Ogniem i Mieczem"};
            _authors = new List<string> { "J.R.R Tolkien", "Dimitry Gluhowsky", "Andrzej Sapkowski", "Christopher Paolini", "Frank Herbert", "Brent Weeks", "Antoine de Saint-Exupery", "J.K.Rowling", "Gustaw Herling Grudzinski", "Aleksander Solzenicyn" };
            _publishers = new List<string> { "Mag", "Nowy Swiat", "Fabryka Slow", "Bialy Kruk", "Drzeo Bable", "Biuro Literackie", "Harmonia", "Iskra", "Medyk", "Swiat Ksiazki" };

        }

        private void generateRandomReaders()
        {
   
            int index1;
            int index2;
            int oneToDelete;

            while (Readers.Count() < 6)
            {
                index1 = rnd.Next(0, _names.Count());
                index2 = rnd.Next(0, _lastNames.Count());
                Readers.Add(new Reader(_names[index1], _lastNames[index2]));
                oneToDelete = rnd.Next(0, 2);
                if(oneToDelete == 0)
                {
                    _names.Remove(_names[index1]);
                }
                else
                {
                    _lastNames.Remove(_lastNames[index2]);

                }
            }
        }

        private void generateRandomBookDescriptions()
        {
   
            int index1;
            int index2;
            int index3;
            int oneToDelete;

            while (BookDescriptions.Count() < 6)
            {
                index1 = rnd.Next(0, _titles.Count());
                index2 = rnd.Next(0, _authors.Count());
                index3 = rnd.Next(0, _publishers.Count());
                BookDescriptions.Add(new BookDescription(_titles[index1], _authors[index2], _publishers[index3]));
                _titles.Remove(_titles[index1]);        
            }
        }



        private void generateRandomBookCopies()
        {
           
            int index1;

            while (BookCopies.Count() < 10)
            {
                index1 = rnd.Next(0, BookDescriptions.Count());
                BookCopies.Add(new BookCopy(BookDescriptions[index1], DateTime.Now, randomIsbn()));

            }
        }


        private void generateRandomBookEvents()
        {
            throw new NotImplementedException();
        }

        private string randomIsbn()
        {
            string pool = "1234567890";
            StringBuilder holder = new StringBuilder(13);
            for (int i = 0; i < 13; i++)
            {
                holder.Append(pool[rnd.Next(0, 10)]);
            }
            string isbn = holder.ToString();

            return isbn;
        }

    }
}
