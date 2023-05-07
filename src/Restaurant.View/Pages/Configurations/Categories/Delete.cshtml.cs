using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Restaurant.View.Pages.Configurations.Categories
{
    public class Delete : PageModel
    {
        private readonly Context context;

        public Delete(Context context)
        {
            this.context = context;
        }

        public IActionResult OnGet(int id)
        {
            var categoryModel = context.CategoryModel?.Find(id);

            if (categoryModel != null)
            {
                context.CategoryModel?.Remove(categoryModel);
                context.SaveChanges();
            }
            return RedirectToPage("Index");
        }
    }
}
