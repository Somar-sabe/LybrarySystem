using System.Collections.Generic;

namespace LybrarySystem.Models.Domain
{
    public class Subcategory
    {
        public int SubcategoryId { get; set; }
        public string Name { get; set; }
        public int CategoryId { get; set; }
        public Category Category { get; set; }
        public List<Book> Books { get; set; } // Add the Books property
    }
}

