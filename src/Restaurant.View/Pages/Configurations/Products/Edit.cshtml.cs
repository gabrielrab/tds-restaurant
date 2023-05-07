using System.Text;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Newtonsoft.Json;
using Restaurant.Data.Data.Models;

namespace Restaurant.View.Pages.Configurations.Products
{
    public class Edit : PageModel
    {
        [BindProperty]
        public ProductModel? Product { get; set; }

        [BindProperty]
        public String? SelectedCategory { get; set; }

        public List<SelectListItem> Categories { get; set; } = new();

        public async Task OnGetAsync(int id)
        {
            HttpClient client = new() { BaseAddress = new Uri("http://localhost:5183/api/") };

            var response = await client.GetAsync("Category");

            var categories = JsonConvert.DeserializeObject<List<CategoryModel>>(
                await response.Content.ReadAsStringAsync()
            )!;

            foreach (var category in categories ?? new())
            {
                Categories!.Add(new SelectListItem(category.Name, category.Id.ToString()));
            }

            var productResponse = await client.GetAsync($"Product/{id}");

            Product = JsonConvert.DeserializeObject<ProductModel>(
                await productResponse.Content.ReadAsStringAsync()
            )!;
        }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            HttpClient client =
                new() { BaseAddress = new Uri("http://localhost:5183/api/Product") };

            var jsonContent = JsonConvert.SerializeObject(Product);
            var content = new StringContent(jsonContent, Encoding.UTF8, "application/json");

            var response = await client.PutAsync("", content);

            if (response.IsSuccessStatusCode)
            {
                return RedirectToPage("Index");
            }
            else
            {
                return Page();
            }
        }
    }
}
