using System.Text;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Newtonsoft.Json;
using Restaurant.Data.Data.Models;

namespace Restaurant.View.Pages.Configurations.Tables
{
    public class Edit : PageModel
    {
        [BindProperty]
        public TableModel? Table { get; set; }

        public async Task OnGetAsync(int id)
        {
            HttpClient client = new() { BaseAddress = new Uri("http://localhost:5183/api/") };

            var tableResponse = await client.GetAsync($"Table/{id}");

            Table = JsonConvert.DeserializeObject<TableModel>(
                await tableResponse.Content.ReadAsStringAsync()
            )!;
        }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            HttpClient client = new() { BaseAddress = new Uri("http://localhost:5183/api/Table") };

            var jsonContent = JsonConvert.SerializeObject(Table);
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
