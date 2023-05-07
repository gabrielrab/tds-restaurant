using System.Text;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Newtonsoft.Json;
using Restaurant.Data.Data.Models;

namespace Restaurant.View.Pages.Configurations.Products
{
    public class Create : PageModel
    {
        [BindProperty]
        public ProductModel? product { get; set; }

        public List<SelectListItem> Categories { get; set; } = new();

        [BindProperty]
        public String? SelectedCategory { get; set; }

        public async Task OnGetAsync()
        {
            HttpClient client =
                new() { BaseAddress = new Uri("http://localhost:5183/api/Category") };

            var response = await client.GetAsync("");

            var categories = JsonConvert.DeserializeObject<List<CategoryModel>>(
                await response.Content.ReadAsStringAsync()
            )!;

            foreach (var category in categories ?? new())
            {
                Categories!.Add(new SelectListItem(category.Name, category.Id.ToString()));
            }
        }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            HttpClient client =
                new() { BaseAddress = new Uri("http://localhost:5183/api/Product") };

            var jsonContent = JsonConvert.SerializeObject(product);
            var content = new StringContent(jsonContent, Encoding.UTF8, "application/json");

            var response = await client.PostAsync("", content);

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
