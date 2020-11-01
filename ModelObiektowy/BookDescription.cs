﻿using System;

namespace Automatic_Library
{
    class BookDescription
    {
        public string Title { get; }
        public string Author { get; }
        public string Publisher { get; }
        private Guid id;

        public BookDescription(string title, string author, string publisher)
        {
            this.Title = title;
            this.Author = author;
            this.Publisher = publisher;
            this.id = Guid.NewGuid();
        }

        public string Id
        {
            get { return id.ToString(); }
        }

    }
}
