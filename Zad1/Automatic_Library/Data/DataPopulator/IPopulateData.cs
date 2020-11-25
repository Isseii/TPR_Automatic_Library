using System.Collections.Generic;
using Automatic_Library.Data.ObjectModel;
using Automatic_Library.Data.ObjectModel.BookEvent;

namespace Automatic_Library.Data.DataPopulator
{
    public interface IPopulateData
    {
        IEnumerable<BookCopy> GetBookCopies();

        IEnumerable<BookDescription> GetBookDescriptions();

        IEnumerable<Reader> GetReaders();

        IEnumerable<BookEvent> GetBookEvents();
    }
}
