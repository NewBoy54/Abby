using AbbyWeb.Model;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace AbbyWeb.Pages.Categories
{
    public class DeleteModel : PageModel
    {
        private readonly AbbyCategoryDbContext _db;

        public DeleteModel(AbbyCategoryDbContext db)
        {
            _db = db;
        }

        [BindProperty]
        public AbbyCategory category { get; set; }

        public void OnGet(int id)
        {
            category = _db.AbbyCategories.Find(id);
        }

        public async Task<IActionResult> OnPost()
        {
            var categoryInDb = _db.AbbyCategories.Find(category.Id);
            if(categoryInDb !=null)
            {
                _db.AbbyCategories.Remove(categoryInDb);
                await _db.SaveChangesAsync();

                return RedirectToPage("Index");
            }
            return Page();
        }
    }
}
