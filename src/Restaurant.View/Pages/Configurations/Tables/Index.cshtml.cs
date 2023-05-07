using Microsoft.AspNetCore.Mvc.RazorPages;
using Newtonsoft.Json;
using Restaurant.Data.Data.Models;

namespace Restaurant.View.Pages.Configurations.Tables
{
    public class Index : PageModel
    {
        public List<TableModel> tables = new();

        public async Task OnGetAsync()
        {
            HttpClient client = new() { BaseAddress = new Uri("http://localhost:5183/api/Table") };

            var response = await client.GetAsync("");

            if (response.IsSuccessStatusCode)
            {
                tables = JsonConvert.DeserializeObject<List<TableModel>>(
                    await response.Content.ReadAsStringAsync()
                )!;
            }
        }
    }
}
