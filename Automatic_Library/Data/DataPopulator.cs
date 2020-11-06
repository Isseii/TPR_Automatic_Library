namespace Automatic_Library.Data
{
    class DataPopulator
    {
        private DataRepository _dataRepository;
        private IPopulateData _populateData;

        DataPopulator(DataRepository dataRepository, IPopulateData populateData)
        {
            this._dataRepository = dataRepository;
            this._populateData = populateData;
        }

        public void populate()
        {
            foreach (var bookCopy in _populateData.GetBookCopies())
            {
                _dataRepository.AddBookCopy(bookCopy);
            }

            foreach (var bookDescription in _populateData.GetBookDescriptions())
            {
                _dataRepository.AddBookDescription(bookDescription);
            }

            foreach (var reader in _populateData.GetReaders())
            {
                _dataRepository.AddReader(reader);
            }

            foreach (var rent in _populateData.GetRents())
            {
                _dataRepository.AddRent(rent);
            }

        }
    }
}
