using LybrarySystem.Data;
using LybrarySystem.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace LybrarySystem.Controllers
{
    public class LibraryController : Controller
    {
        private readonly MyDbContext dbContext;

        public LibraryController(MyDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        [HttpGet]
        public IActionResult Add()
        {
            var viewModel = new LibraryViewModel
            {
                Categories = dbContext.Categories
                    .Select(c => new SelectListItem { Value = c.CategoryId.ToString(), Text = c.Name }),
                Subcategories = Enumerable.Empty<SelectListItem>()
            };

            return View(viewModel);
        }

        [HttpGet]
        public IActionResult GetSubcategories(int categoryId)
        {
            var subcategories = dbContext.Subcategories
                .Where(s => s.CategoryId == categoryId)
                .Select(s => new SelectListItem { Value = s.SubcategoryId.ToString(), Text = s.Name });

            return PartialView("_SubcategoriesPartial", subcategories);
        }
    }
}
