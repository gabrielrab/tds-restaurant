using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Restaurant.Data.Data.Repository.Models;

namespace Restaurant.View.Pages.Configurations.Categories
{
    public class Edit : PageModel
    {
        private readonly Context context;

        public Edit(Context context)
        {
            this.context = context;
        }

        [BindProperty]
        public CategoryModel? category { get; set; }

        public void OnGet(int id)
        {
            var categoryModel = context.CategoryModel?.Find(id);

            if (categoryModel != null)
            {
                this.category = categoryModel;
            }
        }

        public IActionResult OnPost()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            if (category != null)
            {
                context.CategoryModel?.Update(category);
                context.SaveChanges();
                return RedirectToPage("Index");
            }
            return Page();
        }
    }
}
