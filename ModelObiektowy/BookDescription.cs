using System;
using System.Collections.Generic;
using System.Text;

namespace Automatic_Library
{
    class BookDescription
    {
        private string title;
        private string author;
        private string publisher;

        public BookDescription(string title, string author, string publisher)
        {
            this.title = title;
            this.author = author;
            this.publisher = publisher;
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

    }
}
