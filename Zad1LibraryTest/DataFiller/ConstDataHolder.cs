﻿using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Net;
using Automatic_Library.Data.ObjectModel;
using Automatic_Library.Data.ObjectModel.BookEvent;

namespace LibraryTest.DataFiller
{
    class ConstDataHolder
    {
        public List<Reader> Readers;
        public List<BookDescription> BookDescriptions;
        public List<BookEvent> BookEvents;
        public List<BookCopy> BookCopies;

        public ConstDataHolder() 
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
            var book4 = new BookDescription("Pan Lodowego Ogrodu (tom 2)", "Jarosław Grzędowicz", "Fabryka Słów");
            BookDescriptions.Add(book4);

            BookCopies = new List<BookCopy>();
            BookCopies.Add(new BookCopy(book, new DateTime(2015, 5, 23),"1234567890123"));
            BookCopies.Add(new BookCopy(book, new DateTime(2005, 2, 22), "2234567890123"));
            BookCopies.Add(new BookCopy(book1, new DateTime(2012, 2, 1), "3234567890123"));
            BookCopies.Add(new BookCopy(book2, new DateTime(1999, 1, 13), "4234567890123"));
            BookCopies.Add(new BookCopy(book3, new DateTime(2003, 5, 27), "5234567890123"));

            BookEvents = new List<BookEvent>();
            BookEvents.Add(new Rent(BookCopies[0], Readers[2], new DateTime(2017, 4, 4)));
            BookEvents.Add(new Rent(BookCopies[4], Readers[0], new DateTime(2017, 11, 6)));
            BookEvents.Add(new Rent(BookCopies[2], Readers[1], new DateTime(2018, 3, 3)));
            BookEvents.Add(new Rent(BookCopies[1], Readers[3], new DateTime(2018, 4, 4)));
            BookEvents.Add(new Rent(BookCopies[3], Readers[2], new DateTime(2020, 5, 5)));

            BookEvents.Add(new Return(BookCopies[0], Readers[2], new DateTime(2020, 10, 10)));
            BookEvents.Add(new Return(BookCopies[1], Readers[3], new DateTime(2020, 11, 6)));

        }
    }
}
