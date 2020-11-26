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
        private readonly Random rnd = new Random();

        public RandomDataHolder()
        {
            PopulateLists();
            GenerateRandomReaders();
            GenerateRandomBookDescriptions();
            GenerateRandomBookCopies();
            GenerateRandomBookEvents();
            
   
        }

        private void PopulateLists()
        {
            _names = new List<string> { "Dominik", "Sebastian","Janusz","Filip","Maciej","Roman","Pawel","Tomek","Izak","Andrzej","Juliusz" };
            _lastNames = new List<string> { "Kolwaski", "Nowak", "Cezar", "Karski", "Kujawski", "Baczynski", "Gruda", "Raj", "Makowski", "Nawrocki", "Fiszer" };
            _titles = new List<string> { "Eragon", "Wladca Pierscieni", "Hobbit", "Inny Swiat", "Archipelag Gulag", "Diuna", "Metro 2033", "Harry Potter", "Mitologia", "Maly Ksiaze" ,"Wiedzmin","Krzyzacy","Ogniem i Mieczem"};
            _authors = new List<string> { "J.R.R Tolkien", "Dimitry Gluhowsky", "Andrzej Sapkowski", "Christopher Paolini", "Frank Herbert", "Brent Weeks", "Antoine de Saint-Exupery", "J.K.Rowling", "Gustaw Herling Grudzinski", "Aleksander Solzenicyn" };
            _publishers = new List<string> { "Mag", "Nowy Swiat", "Fabryka Slow", "Bialy Kruk", "Drzeo Bable", "Biuro Literackie", "Harmonia", "Iskra", "Medyk", "Swiat Ksiazki" };

        }

        private void GenerateRandomReaders()
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

        private void GenerateRandomBookDescriptions()
        {
   
            int index1;
            int index2;
            int index3;

            while (BookDescriptions.Count() < 6)
            {
                index1 = rnd.Next(0, _titles.Count());
                index2 = rnd.Next(0, _authors.Count());
                index3 = rnd.Next(0, _publishers.Count());
                BookDescriptions.Add(new BookDescription(_titles[index1], _authors[index2], _publishers[index3]));
                _titles.Remove(_titles[index1]);        
            }
        }



        private void GenerateRandomBookCopies()
        {
           
            int index1;

            while (BookCopies.Count() < 10)
            {
                index1 = rnd.Next(0, BookDescriptions.Count());
                string isbn;

                bool unique = false;

                while (!unique) {
                    isbn = RandomIsbn();
                    foreach (var item in BookCopies)
                    {
                        if (isbn == item.Isbn)
                        {
                            unique = false;
                            continue;
                        }
                        unique = true;
                    }
                    unique = true;
                }

                BookCopies.Add(new BookCopy(BookDescriptions[index1], DateTime.Now, RandomIsbn()));

            }
        }


        private void GenerateRandomBookEvents()
        {
            int book1 = 0;
            int book2 = 0;
            int book3 = 0;
            int book4 = 0;

            bool unique = false;
            while (!unique) 
            {
                book1 = rnd.Next(0, BookCopies.Count());
                book2 = rnd.Next(0, BookCopies.Count());
                book3 = rnd.Next(0, BookCopies.Count());
                book4 = rnd.Next(0, BookCopies.Count());
                if (book1 == book2 || book1 == book3 || book1 == book4 || book2 == book3 || book3 == book4 || book2 == book4)
                {
                    unique = false;
                }
                else
                {
                    unique = true;
                }
            }

            int book2Reader = rnd.Next(0, Readers.Count());
            int book3Reader = rnd.Next(0, Readers.Count());

            BookEvents.Add(new Rent(BookCopies[book1], Readers[rnd.Next(0, Readers.Count())], new DateTime(2020, 1, 20)));
            BookEvents.Add(new Rent(BookCopies[book2], Readers[book2Reader], new DateTime(2020, 2, 13)));
            BookEvents.Add(new Rent(BookCopies[book3], Readers[book3Reader], new DateTime(2020, 4, 1)));
            BookEvents.Add(new Return(BookCopies[book2], Readers[book2Reader], new DateTime(2020, 5, 2)));
            BookEvents.Add(new Rent(BookCopies[book4], Readers[rnd.Next(0, Readers.Count())], new DateTime(2020, 7, 3)));
            BookEvents.Add(new Return(BookCopies[book3], Readers[book3Reader], new DateTime(2020, 12, 4)));
        }

        private string RandomIsbn()
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
