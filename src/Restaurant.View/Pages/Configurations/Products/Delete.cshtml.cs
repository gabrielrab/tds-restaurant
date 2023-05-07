using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Restaurant.View.Pages.Configurations.Products
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
            var productModel = context.ProductModel?.Find(id);

            if (productModel != null)
            {
                context.ProductModel?.Remove(productModel);
                context.SaveChanges();
            }
            return RedirectToPage("Index");
        }
    }
}
