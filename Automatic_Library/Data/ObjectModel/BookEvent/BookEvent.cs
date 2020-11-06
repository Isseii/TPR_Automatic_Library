using System;
using System.Collections.Generic;
using System.Text;

namespace Automatic_Library.Data.ObjectModel.BookEvent
{
    abstract class BookEvent
    {
        public BookCopy BookCopy { set; get; }
        public Reader Reader { set; get; }
        public DateTime EventTime { set; get; }

        protected BookEvent(BookCopy bookCopy, Reader reader, DateTime bookEventTime)
        {
            this.BookCopy = bookCopy;
            this.Reader = reader;
            this.EventTime = bookEventTime;
        }

    


    }
}
