using Microsoft.AspNetCore.Mvc.RazorPages;
using Restaurant.Data.Data.Repository.Models;
using Microsoft.EntityFrameworkCore;

namespace Restaurant.View.Pages.Configurations.Products
{
    public class Index : PageModel
    {
        private readonly Context context;

        public Index(Context context)
        {
            this.context = context;
        }

        public List<ProductModel> products = new();

        public void OnGet()
        {
            products =
                context.ProductModel?.Include(p => p.Category).ToList() ?? new List<ProductModel>();
        }
    }
}
