using System;
using System.Collections.Generic;
using System.Text;

namespace Automatic_Library.Data.ObjectModel.BookEvent
{
    public abstract class BookEvent
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

        public override bool Equals(object obj)
        {
            if ((obj == null) || !this.GetType().Equals(obj.GetType()))
            {
                return false;
            }

            var tmp = (BookEvent)obj;
            
            if(tmp.BookCopy.Equals(this.BookCopy) && tmp.Reader.Equals(this.Reader) && tmp.EventTime.Equals(this.EventTime))
            {
                return true;
            }
            return false;
        }
    }
}
