using System;

namespace Automatic_Library
{
    class BookDescription
    {
        private string title;
        private string author;
        private string publisher;
        private Guid id;

        public BookDescription(string title, string author, string publisher)
        {
            this.title = title;
            this.author = author;
            this.publisher = publisher;
            this.id = Guid.NewGuid();
        }

        public string Title
        {
            get { return title; }
        }

        public string Author
        {
            get { return author; }
        }

        public string Publisher
        {
            get { return publisher; }
        }

        public string Id
        {
            get { return id.ToString(); }
        }

    }
}
