
namespace ASS03_OOP.Inheritance

{
    public class Book
    {

        #region properties

        //Title, Author, and ISBN.
        public string Title { get; set; }
        public string Author { get; set; }
        public string ISBN { get; set; }

        #endregion

        #region constructor
        public Book(string title, string author, string iSBN)
        {
            Title = title;
            Author = author;
            ISBN = iSBN;
        }
        #endregion

        #region methods
        //tostring override

        public override string ToString()
        {
            return $"Title: {Title}\nAuthor: {Author}\nISBN: {ISBN}";
        }
        #endregion

    }
}
