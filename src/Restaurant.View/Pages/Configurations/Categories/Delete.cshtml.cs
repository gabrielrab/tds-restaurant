using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Restaurant.View.Pages.Configurations.Categories
{
    public class Delete : PageModel
    {
        public async Task<IActionResult> OnGetAsync(int id)
        {
            HttpClient client =
                new() { BaseAddress = new Uri("http://localhost:5183/api/Category/") };

            var response = await client.DeleteAsync($"/{id}");

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
