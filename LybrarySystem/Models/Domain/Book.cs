namespace LybrarySystem.Models.Domain
{
    public class Book
    {
        public int BookId { get; set; }
        public string Title { get; set; }
        public int SubcategoryId { get; set; }
        public Subcategory Subcategory { get; set; }
    }
}

