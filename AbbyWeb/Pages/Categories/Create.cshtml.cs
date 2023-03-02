using AbbyWeb.Model;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace AbbyWeb.Pages.Categories
{
    public class CreateModel : PageModel
    {
        [BindProperty]
        public AbbyCategory Category { get; set; }

        private readonly AbbyCategoryDbContext _db;

        public CreateModel(AbbyCategoryDbContext db)
        {
            _db = db;
        }

        //In MVC Core we have actions, in Razor Pages we have handlers - all naming of all handlers
        //must have the prefix 'OnPost' or 'OnGet'. If there are multiple post methods('handlers') then
        //you can write e.g. OnPostCreate, OnPostNew etc.

        public void OnGet()
        {
        }

        //You do not need to say 'OnPost(AbbyCategory category)' because the Category property above
        //has '[BindProperty]'. So 'OnPost()' is enough
        public async Task<IActionResult> OnPost()
        {
            if(ModelState.IsValid)
            {
                await _db.AbbyCategories.AddAsync(Category);
                await _db.SaveChangesAsync();
                TempData["success"] = "New record created!";
                return RedirectToPage("Index");
            }
            return Page();
        }
    }
}
