using AbbyWeb.Model;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace AbbyWeb.Pages.Categories
{
    public class IndexModel : PageModel
    {
        private readonly AbbyCategoryDbContext _db;

        public IEnumerable<AbbyCategory> categories;

        public IndexModel(AbbyCategoryDbContext db)
        {
            _db = db;
        }

        public void OnGet()
        {
            categories = _db.AbbyCategories;
        }
    }
}
