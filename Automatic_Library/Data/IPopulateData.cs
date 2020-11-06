using System.Collections.Generic;
using Automatic_Library.Data.ObjectModel;

namespace Automatic_Library.Data
{
    interface IPopulateData
    {
        IEnumerable<BookCopy> GetBookCopies();

        IEnumerable<BookDescription> GetBookDescriptions();

        IEnumerable<Reader> GetReaders();

        IEnumerable<Rent> GetRents();
    }
}
