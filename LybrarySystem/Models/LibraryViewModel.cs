using Microsoft.AspNetCore.Mvc.Rendering;

namespace LybrarySystem.Models
{
    public class LibraryViewModel
    {
        public int SelectedCategoryId { get; set; }
        public IEnumerable<SelectListItem> Categories { get; set; }
        public IEnumerable<SelectListItem> Subcategories { get; set; }
    }
}
