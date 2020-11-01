using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace Automatic_Library
{
    class DataContext : IRentBook, IReturnBook
    {
        private List<Reader> readers;
        private Dictionary<int, BookDescription> bookDescriptions;
        private ObservableCollection<Rent> rents;    //TODO MAKE USE OF OBSERVABLE COLLECTION 
        private List<BookCopy> bookStates;


        public DataContext() {}


        public void RentBook(Reader reader, BookDescription bookDescription)
        {
            foreach(var x in bookStates)
            {
                if(x.Book.Id == bookDescription.Id && x.State == BookCopy.Availability.Available)
                {
                    rents.Add(new Rent(x, reader, System.DateTime.Now));
                    x.State = BookCopy.Availability.Unavailable;
                    return;
                }
            }
        }

        public void ReturnBook(BookCopy book)
        {
            if(book.State == BookCopy.Availability.Available)
            {
                return;
            }
            for(int i = 0; i < rents.Count; i++)
            {
                if(rents[i].ReturnDate.Equals(default(DateTime)) && book.Id == rents[i].Book.Id)
                {
                    book.State = BookCopy.Availability.Available;
                    rents[i].ReturnDate = System.DateTime.Now;
                    return;
                }
            }
        }
    }
}
