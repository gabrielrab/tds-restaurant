using Microsoft.AspNetCore.Mvc.RazorPages;
using Restaurant.Data.Data.Models;
using Newtonsoft.Json;

namespace Restaurant.View.Pages.Configurations.Products
{
    public class Index : PageModel
    {
        public List<ProductModel> products = new();

        public async Task OnGetAsync()
        {
            HttpClient client =
                new() { BaseAddress = new Uri("http://localhost:5183/api/Product") };

            var response = await client.GetAsync("");

            if (response.IsSuccessStatusCode)
            {
                products = JsonConvert.DeserializeObject<List<ProductModel>>(
                    await response.Content.ReadAsStringAsync()
                )!;
            }
        }
    }
}
