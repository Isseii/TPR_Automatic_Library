using System.Linq;

namespace Automatic_Library.Data.DataPopulator
{
    public class DataPopulator
    {
        private AbstractDataRepository _dataRepository;
        private IPopulateData _populateData;

        public DataPopulator(AbstractDataRepository dataRepository, IPopulateData populateData)
        {
            this._dataRepository = dataRepository;
            this._populateData = populateData;
        }

         public void populate()
        {
            foreach (var bookDescription in _populateData.GetBookDescriptions())
            {
                _dataRepository.AddBookDescription(bookDescription);
            }

            foreach (var bookCopy in _populateData.GetBookCopies())
            {
                _dataRepository.AddBookCopy(bookCopy);
            }

            foreach (var reader in _populateData.GetReaders())
            {
                _dataRepository.AddReader(reader);
            }

            foreach (var bookEvent in _populateData.GetBookEvents())
            {
                _dataRepository.AddBookEvent(bookEvent);
            }

        
        }
    }
}
