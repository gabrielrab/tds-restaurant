using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Restaurant.View.Pages.Configurations.Waiters
{
    public class Delete : PageModel
    {
        public async Task<IActionResult> OnGetAsync(int id)
        {
            HttpClient client =
                new() { BaseAddress = new Uri("http://localhost:5183/api/Waiter/") };

            var response = await client.DeleteAsync($"{id}");

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
