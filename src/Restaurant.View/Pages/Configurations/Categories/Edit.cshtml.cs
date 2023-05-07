using System.Text;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Newtonsoft.Json;
using Restaurant.Data.Data.Models;

namespace Restaurant.View.Pages.Configurations.Categories
{
    public class Edit : PageModel
    {
        [BindProperty]
        public CategoryModel? Category { get; set; }

        public async Task OnGetAsync(int id)
        {
            HttpClient client =
                new() { BaseAddress = new Uri("http://localhost:5183/api/Category/") };

            var response = await client.GetAsync(id.ToString());

            Category = JsonConvert.DeserializeObject<CategoryModel>(
                await response.Content.ReadAsStringAsync()
            )!;
        }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            HttpClient client =
                new() { BaseAddress = new Uri("http://localhost:5183/api/Category") };

            var jsonContent = JsonConvert.SerializeObject(Category);
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
