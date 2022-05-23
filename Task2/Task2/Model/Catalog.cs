namespace Task2.Presentation.Model
{

    public class Catalog
    {
        public string Author { get; set; }
        public string Title { get; set; }

        public Catalog(string title, string author)
        {
            Author = author;
            Title = title;
        }

        public override string ToString()
        {
            return Title + " | " + Author;
        }
    }
}