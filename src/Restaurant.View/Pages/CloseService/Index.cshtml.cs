using System.Text;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Newtonsoft.Json;
using Restaurant.Data.Data.Models;

namespace Restaurant.View.Pages.CloseService
{
    public class CloseService : PageModel
    {
        public int ServiceID { get; set; }

        public TableModel? Table { get; set; }

        public ServiceModel? Service { get; set; }

        public async Task OnGetAsync(int id)
        {
            HttpClient client = new()
            {
                BaseAddress = new Uri("http://localhost:5183/api/")
            };

            var tableResponse = await client.GetAsync($"Table/{id}");

            var tableModel = JsonConvert.DeserializeObject<TableModel>(await tableResponse.Content.ReadAsStringAsync())!;

            if (tableModel != null)
            {
                Table = tableModel;
                ServiceID = Table.Services!.LastOrDefault()!.Id;

                var serviceResponse = await client.GetAsync($"Service/{ServiceID}");

                Service = JsonConvert.DeserializeObject<ServiceModel>(await serviceResponse.Content.ReadAsStringAsync())!;
            }

            Table!.Status = false;
            Service!.EndAt = DateTime.Now;

                    var jsonContent = JsonConvert.SerializeObject(Table);
        var content = new StringContent(jsonContent, Encoding.UTF8, "application/json");

      await client.PutAsync("Table", content);

                          jsonContent = JsonConvert.SerializeObject(Service);
        content = new StringContent(jsonContent, Encoding.UTF8, "application/json");

        await client.PutAsync("Service", content);
        }
    }
}
