using Microsoft.AspNetCore.Mvc.RazorPages;
using Newtonsoft.Json;
using Restaurant.Data.Data.Models;

namespace Restaurant.View.Pages.Configurations.Categories
{
    public class Index : PageModel
    {
        public List<CategoryModel> categories = new();

        public async Task OnGetAsync()
        {
                         HttpClient client = new()
        {
            BaseAddress = new Uri("http://localhost:5183/api/Category")
        };

      var response = await client.GetAsync("");


      if (response.IsSuccessStatusCode) {
            categories = JsonConvert.DeserializeObject<List<CategoryModel>>(await response.Content.ReadAsStringAsync())!;
      }
        }
    }
}
