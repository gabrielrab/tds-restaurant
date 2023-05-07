using Microsoft.AspNetCore.Mvc.RazorPages;
using Restaurant.Data.Data.Repository.Models;

namespace Restaurant.View.Pages.Configurations.Categories
{
    public class Index : PageModel
    {
        private readonly Context context;

        public Index(Context context)
        {
            this.context = context;
        }

        public List<CategoryModel> categories = new();

        public void OnGet()
        {
            categories = context.CategoryModel?.ToList() ?? new List<CategoryModel>();
        }
    }
}
