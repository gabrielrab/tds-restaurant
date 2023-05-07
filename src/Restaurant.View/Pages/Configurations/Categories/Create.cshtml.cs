using System.Text;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Newtonsoft.Json;
using Restaurant.Data.Data.Models;

namespace Restaurant.View.Pages.Configurations.Categories {
  public class Create: PageModel {
    [BindProperty]
    public CategoryModel ? Category {get;
      set;
    }

    public async Task <IActionResult> OnPostAsync() {
      if (!ModelState.IsValid) {
        return Page();
      }

        HttpClient client = new()
        {
            BaseAddress = new Uri("http://localhost:5183/api/Category")
        };

            var jsonContent = JsonConvert.SerializeObject(Category);
      var content = new StringContent(jsonContent, Encoding.UTF8, "application/json");

      var response = await client.PostAsync("", content);

      if (response.IsSuccessStatusCode) {
        return RedirectToPage("Index");
      } else {
        return Page();
      }
    }
  }
}
