﻿using System;
using System.Collections.Generic;
using System.Linq;
using Automatic_Library.Data;
using Automatic_Library.Data.ObjectModel;

namespace Automatic_Library.Logic
{
    class DataService
    {
        private AbstractDataRepository _dataRepository;
        
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
            throw new NotImplementedException();
        }
        

    }
}