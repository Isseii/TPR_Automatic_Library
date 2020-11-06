using System.Linq;

namespace Automatic_Library.Data
{
    class DataPopulator
    {
        private AbstractDataRepository _dataRepository;
        private IPopulateData _populateData;

        DataPopulator(AbstractDataRepository dataRepository, IPopulateData populateData)
        {
            this._dataRepository = dataRepository;
            this._populateData = populateData;
        }

        public void populate()
        {
            var bookCopies = _populateData.GetBookCopies();
            for (int i = 0; i < bookCopies.Count(); i++)
            {
                var a = bookCopies.ElementAt(i);
                _dataRepository.AddBookCopy(ref a);
            }

            var bookDescriptions = _populateData.GetBookDescriptions();
            for (int i = 0; i < bookDescriptions.Count(); i++)
            {
                var a = bookDescriptions.ElementAt(i);
                _dataRepository.AddBookDescription(ref a);
            }

            var readers = _populateData.GetReaders();
            for (int i = 0; i < readers.Count(); i++)
            {
                var a = readers.ElementAt(i);
                _dataRepository.AddReader(ref a);
            }

            var Actions = _populateData.GetActions();
            for (int i = 0; i < Actions.Count(); i++)
            {
                var a = Actions.ElementAt(i);
                _dataRepository.AddBookEvent(ref a);
            }
        }
    }
}
