using System;
using System.Collections.Generic;
using System.Text;

namespace Automatic_Library
{
    interface IRentBook
    {
        void RentBook(Reader reader, BookDescription bookDescription);

    }

    interface IReturnBook
    {
        void ReturnBook(BookState book);
    }
}
