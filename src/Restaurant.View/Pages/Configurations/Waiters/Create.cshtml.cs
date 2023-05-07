using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Restaurant.Data.Data.Models;
using Newtonsoft.Json;
using System.Text;

namespace Restaurant.View.Pages.Configurations.Waiters
{
    public class Create : PageModel
    {
        [BindProperty]
        public WaiterModel? waiter { get; set; }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            HttpClient client =
                new() { BaseAddress = new Uri("http://localhost:5183/api/Category") };

            var jsonContent = JsonConvert.SerializeObject(waiter);
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
