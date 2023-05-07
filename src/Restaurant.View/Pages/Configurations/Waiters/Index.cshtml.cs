using Microsoft.AspNetCore.Mvc.RazorPages;
using Newtonsoft.Json;
using Restaurant.Data.Data.Models;

namespace Restaurant.View.Pages.Configurations.Waiters
{
    public class Index : PageModel
    {
        public List<WaiterModel> waiters = new();

        public async Task OnGetAsync()
        {
            HttpClient client = new() { BaseAddress = new Uri("http://localhost:5183/api/Waiter") };

            var response = await client.GetAsync("");

            if (response.IsSuccessStatusCode)
            {
                waiters = JsonConvert.DeserializeObject<List<WaiterModel>>(
                    await response.Content.ReadAsStringAsync()
                )!;
            }
        }
    }
}
