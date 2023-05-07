using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Restaurant.Data.Data.Repository.Models;

namespace Restaurant.View.Pages.Configurations.Products
{
    public class Create : PageModel
    {
        private readonly Context context;

        public Create(Context context)
        {
            this.context = context;
            var categories = context.CategoryModel?.ToList();

            foreach (var category in categories ?? new())
            {
                this.categories.Add(new SelectListItem(category.Name, category.Id.ToString()));
            }
        }

        [BindProperty]
        public ProductModel? product { get; set; }

        public List<SelectListItem> categories { get; set; } = new();

        [BindProperty]
        public String? SelectedCategory { get; set; }

        public IActionResult OnPost()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            int id = 0;

            var lastProduct = context.ProductModel?.OrderByDescending(p => p.Id).FirstOrDefault();

            var category = context.CategoryModel
                ?.Where(c => c.Id == int.Parse(SelectedCategory!))
                .FirstOrDefault();

            if (lastProduct != null)
            {
                id = lastProduct.Id + 1;
            }

            if (product != null)
            {
                context.ProductModel?.Add(
                    new ProductModel(id, product.Name, product.Description, product.Price, category)
                );
                context.SaveChanges();
                return RedirectToPage("Index");
            }
            return Page();
        }
    }
}
