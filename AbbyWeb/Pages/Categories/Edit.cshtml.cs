using AbbyWeb.Model;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace AbbyWeb.Pages.Categories
{
    public class EditModel : PageModel
    {
        private readonly AbbyCategoryDbContext _db;

        public EditModel(AbbyCategoryDbContext db)
        {
            _db = db;
        }

        [BindProperty]
        public AbbyCategory category { get; set; }

        public void OnGet(int id)
        {
            category = _db.AbbyCategories.Find(id);
        }

        //You do not need to say 'OnPost(AbbyCategory category)' because the Category property above
        //has '[BindProperty]'. So 'OnPost()' is enough
        public async Task<IActionResult> OnPost()
        {
            if (ModelState.IsValid)
            {
                _db.AbbyCategories.Update(category);
                await _db.SaveChangesAsync();
                return RedirectToPage("Index");
            }
            return Page();
        }
    }
}
