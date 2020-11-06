using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Net;
using Automatic_Library.Data.ObjectModel;
using Automatic_Library.Data.ObjectModel.BookEvent;

namespace Automatic_Library.Data.DataPopulator
{
    class DataHolder
    {
        public List<Reader> Readers;
        public List<BookDescription> BookDescriptions;
        public List<BookEvent> BookEvents;
        public List<BookCopy> BookCopies;

        public DataHolder() 
        {
            Readers = new List<Reader>();
            Readers.Add(new Reader("Dominik", "Karski"));
            Readers.Add(new Reader("Sebastian", "Kujawski"));
            Readers.Add(new Reader("Joe","Biden"));
            Readers.Add(new Reader("Donald","Trump"));

            BookDescriptions = new List<BookDescription>();
            var book = new BookDescription("Metro 2033", "Dmitry Glukhovsky","Insignis");
            BookDescriptions.Add(book);
            var book1 = new BookDescription("Diuna", "Frank Herbert", "Rebis");
            BookDescriptions.Add(book1);
            var book2 = new BookDescription("Harry Potter", "J.K.Rowling", "Media Rodzina");
            BookDescriptions.Add(book2);
            var book3 = new BookDescription("Pan Lodowego Ogrodu (tom 1)", "Jarosław Grzędowicz", "Fabryka Słów");
            BookDescriptions.Add(book3);

            BookCopies = new List<BookCopy>();
            BookCopies.Add(new BookCopy(book, new DateTime(2018, 5, 23)));
            BookCopies.Add(new BookCopy(book, new DateTime(2005, 2, 22)));
            BookCopies.Add(new BookCopy(book1, new DateTime(2012, 2, 1)));
            BookCopies.Add(new BookCopy(book2, new DateTime(1999, 1, 13)));
            BookCopies.Add(new BookCopy(book3, new DateTime(2003, 5, 27)));

            BookEvents = new List<BookEvent>();
            BookEvents.Add(new Rent(BookCopies[0], Readers[2], new DateTime(2020, 4, 4)));
            BookEvents.Add(new Rent(BookCopies[4], Readers[0], new DateTime(2020, 11, 6)));



        }
    }
}
