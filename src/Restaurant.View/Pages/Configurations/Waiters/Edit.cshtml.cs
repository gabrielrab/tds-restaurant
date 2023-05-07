using System.Text;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Newtonsoft.Json;
using Restaurant.Data.Data.Models;

namespace Restaurant.View.Pages.Configurations.Waiters
{
    public class Edit : PageModel
    {
        [BindProperty]
        public WaiterModel? Waiter { get; set; }

        public async Task OnGetAsync(int id)
        {
            HttpClient client = new() { BaseAddress = new Uri("http://localhost:5183/api/") };

            var waiterResponse = await client.GetAsync($"Waiter/{id}");

            Waiter = JsonConvert.DeserializeObject<WaiterModel>(
                await waiterResponse.Content.ReadAsStringAsync()
            )!;
        }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            HttpClient client = new() { BaseAddress = new Uri("http://localhost:5183/api/Waiter") };

            var jsonContent = JsonConvert.SerializeObject(Waiter);
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
