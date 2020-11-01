using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;

namespace Automatic_Library.Logic
{
    class DataService
    {
        private DataRepository _dataRepository;
        
        IEnumerable<BookDescription> AllBookDescriptions()
        {
            return _dataRepository.GetAllBookDescriptions();
        }

        IEnumerable<Rent> ReaderRents(Reader reader)
        {
            return _dataRepository.GetAllRents().Where(x => x.Reader == reader);
        }

        IEnumerable<Rent> RentsBetweenDates(DateTime start, DateTime end)
        {
            return _dataRepository.GetAllRents().Where( x => x.RentalDate > start && x.RentalDate < end);
        }

        Rent AddRent(BookCopy bookCopy, Reader reader)
        {
            if(_dataRepository.GetReader(reader.Id) == null || _dataRepository.GetBookCopy(bookCopy.Id) == null)
            {
                return null;
            }
            Rent rent = new Rent(bookCopy, reader, DateTime.Now);
            _dataRepository.AddRent(rent);
            return rent;
        }
        

    }
}
