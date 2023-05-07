using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Restaurant.Data.Data.Repository.Models;

namespace Restaurant.View.Pages.Configurations.Categories
{
    public class Create : PageModel
    {
        private readonly Context context;

        public Create(Context context)
        {
            this.context = context;
        }

        [BindProperty]
        public CategoryModel? category { get; set; }

        public IActionResult OnPost()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            int id = 0;
            var lastCategory = context.CategoryModel?.OrderByDescending(p => p.Id).FirstOrDefault();

            if (lastCategory != null)
            {
                id = lastCategory.Id + 1;
            }

            if (category != null)
            {
                context.CategoryModel?.Add(
                    new CategoryModel(id, category.Name, category.Description)
                );
                context.SaveChanges();
                return RedirectToPage("Index");
            }
            return Page();
        }
    }
}
