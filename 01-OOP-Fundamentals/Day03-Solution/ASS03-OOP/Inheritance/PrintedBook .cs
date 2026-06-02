using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ASS03_OOP.Inheritance
{
    internal class PrintedBook : Book
    {
        public int PageCount { get; set; }

        public PrintedBook(string title, string author, string isbn, int pageCount) : base(title, author, isbn)
        {
            PageCount = pageCount;
        }

        public PrintedBook(int pageCount) : this("Unknown Title", "Unknown Author", "Unknown ISBN", pageCount)
        {
            PageCount = pageCount;
        }

        public override string ToString()
        {
            return base.ToString() + $"\nPage Count: {PageCount}";
        }

         


    }
}
