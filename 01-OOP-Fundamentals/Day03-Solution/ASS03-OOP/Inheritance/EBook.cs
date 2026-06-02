namespace ASS03_OOP.Inheritance
{
    internal class EBook : Book
    {
         
        //fillsize att
        public double FileSize { get; set; }


        public EBook(string title, string author, string isbn, double fileSize): base(title, author, isbn)
        {
  
             FileSize = fileSize;
        }

        public EBook(double fileSize):this("Unknown Title", "Unknown Author", "Unknown ISBN", fileSize)
        {
            FileSize = fileSize;
        }
    
       override public string ToString()
        {
            return base.ToString() + $"\nFile Size: {FileSize} MB";
        }

    }
}
