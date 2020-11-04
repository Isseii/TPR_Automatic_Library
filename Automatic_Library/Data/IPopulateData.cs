using System.Collections.Generic;

namespace Automatic_Library
{
    interface IPopulateData
    {
        IEnumerable<BookCopy> GetBookCopies();

        IEnumerable<BookDescription> GetBookDescriptions();

        IEnumerable<Reader> GetReaders();

        IEnumerable<Rent> GetRents();
    }
}
