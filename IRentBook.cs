namespace Automatic_Library
{
    interface IRentBook
    {
        void RentBook(Reader reader, BookDescription bookDescription);

    }

    interface IReturnBook
    {
        void ReturnBook(BookState book);
    }
}
