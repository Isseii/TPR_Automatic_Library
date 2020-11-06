using System;
using System.Collections.Generic;
using System.Text;

namespace Automatic_Library.Data.ObjectModel.BookEvent
{
    class Return : BookEvent
    {
        public Return(BookCopy book, Reader reader, DateTime returnDate) : base(book, reader, returnDate) 
        {

        }
    }
}
