using Microsoft.AspNetCore.Mvc.RazorPages;
using Newtonsoft.Json;
using Restaurant.Data.Data.Models;

namespace Restaurant.View.Pages.OrderDetails
{
    public class OrderDetail : PageModel
    {
        public double total { get; set; }

        public int serviceID { get; set; }

        public ServiceModel? service { get; set; }

        public List<ServiceLineModel>? serviceLines { get; set; }

        public TableModel? table { get; set; }

        public async Task OnGetAsync(int? id)
        {
            HttpClient client = new() { BaseAddress = new Uri("http://localhost:5183/api/") };

            var tableResponse = await client.GetAsync($"Table/{id}");

            var tableModel = JsonConvert.DeserializeObject<TableModel>(
                await tableResponse.Content.ReadAsStringAsync()
            )!;

            if (tableModel != null)
            {
                table = tableModel;
                if (table.Status && tableModel?.Services?.Count > 0)
                {
                    total = 0;
                    var serviceResponse = await client.GetAsync(
                        $"Service/{tableModel.Services!.LastOrDefault()!.Id}"
                    );

                    service = JsonConvert.DeserializeObject<ServiceModel>(
                        await serviceResponse.Content.ReadAsStringAsync()
                    )!;

                    serviceLines = service.ServiceLines;

                    foreach (var item in serviceLines ?? new())
                    {
                        total += item.Product!.Price * item.Quantity;
                    }
                }
            }
        }
    }
}
