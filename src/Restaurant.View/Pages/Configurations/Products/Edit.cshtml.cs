using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Restaurant.Data.Data.Repository.Models;

namespace Restaurant.View.Pages.Configurations.Products
{
    public class Edit : PageModel
    {
        private readonly Context context;

        public Edit(Context context)
        {
            this.context = context;

            var categories = context.CategoryModel?.ToList();

            foreach (var category in categories ?? new())
            {
                this.categories.Add(new SelectListItem(category.Name, category.Id.ToString()));
            }
        }

        [BindProperty]
        public ProductModel? products { get; set; }

        public List<SelectListItem> categories { get; set; } = new();

        [BindProperty]
        public String? SelectedCategory { get; set; }

        public void OnGet(int id)
        {
            var productModel = context.ProductModel
                ?.Include(p => p.Category)
                .FirstOrDefault(p => p.Id == id);

            if (productModel != null)
            {
                this.products = productModel;
                this.SelectedCategory = productModel.Category?.Id.ToString();
            }
        }

        public IActionResult OnPost()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            var category = context.CategoryModel
                ?.Where(c => c.Id == int.Parse(SelectedCategory!))
                .FirstOrDefault();

            products!.Category = category;

            if (products != null)
            {
                context.ProductModel?.Update(products);
                context.SaveChanges();
                return RedirectToPage("Index");
            }
            return Page();
        }
    }
}
