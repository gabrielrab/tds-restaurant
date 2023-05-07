using System.Text;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Newtonsoft.Json;
using Restaurant.Data.Data.Models;

namespace Restaurant.View.Pages.Orders
{
    public class Index : PageModel
    {
        public List<SelectListItem> products = new();
        public List<SelectListItem> waiters = new();
        public List<SelectListItem> tables = new();

        [BindProperty]
        public int TableId { get; set; }

        [BindProperty]
        public int ProductId { get; set; }

        [BindProperty]
        public int WaiterId { get; set; }

        [BindProperty]
        public int Quantity { get; set; }

        public async Task OnGetAsync()
        {
            HttpClient client = new() { BaseAddress = new Uri("http://localhost:5183/api/") };

            var response = await client.GetAsync("Product");

            var products = JsonConvert.DeserializeObject<List<ProductModel>>(
                await response.Content.ReadAsStringAsync()
            )!;

            foreach (var product in products ?? new())
            {
                this.products!.Add(
                    new SelectListItem(
                        $"{product.Name} - R${product.Price},00",
                        product.Id.ToString()
                    )
                );
            }

            response = await client.GetAsync("Waiter");

            var waiters = JsonConvert.DeserializeObject<List<WaiterModel>>(
                await response.Content.ReadAsStringAsync()
            )!;

            foreach (var waiter in waiters ?? new())
            {
                this.waiters!.Add(
                    new SelectListItem(
                        $"{waiter.FirstName} {waiter.LastName}",
                        waiter.Id.ToString()
                    )
                );
            }

            response = await client.GetAsync("Table");

            var tables = JsonConvert.DeserializeObject<List<TableModel>>(
                await response.Content.ReadAsStringAsync()
            )!;

            foreach (var table in tables ?? new())
            {
                this.tables!.Add(new SelectListItem($"Mesa {table.Code}", table.Id.ToString()));
            }
        }

        public async Task<IActionResult> OnPostAsync()
        {
            HttpClient client = new() { BaseAddress = new Uri("http://localhost:5183/api/") };

            var tableResponse = await client.GetAsync($"Table/{TableId}");

            var table = JsonConvert.DeserializeObject<TableModel>(
                await tableResponse.Content.ReadAsStringAsync()
            )!;

            Console.WriteLine(table);

            var service_id = table.Services?.LastOrDefault()?.Id ?? 1;

            if (table!.Status)
            {
                var jsonContent = JsonConvert.SerializeObject(
                    new ServiceLineModel(service_id, TableId, WaiterId, ProductId, Quantity)
                );
                var content = new StringContent(jsonContent, Encoding.UTF8, "application/json");

                await client.PostAsync("ServiceLine", content);
            }
            else
            {
                var jsonContent = JsonConvert.SerializeObject(
                    new ServiceModel(TableId, DateTime.Now, null)
                );
                var content = new StringContent(jsonContent, Encoding.UTF8, "application/json");

                var response = await client.PostAsync("Service", content);

                Console.WriteLine(await response.Content.ReadAsStringAsync());

                service_id = JsonConvert.DeserializeObject<int>(
                    await response.Content.ReadAsStringAsync()
                )!;

                table.Status = true;

                var jsonContentTable = JsonConvert.SerializeObject(table);

                var contentTable = new StringContent(
                    jsonContentTable,
                    Encoding.UTF8,
                    "application/json"
                );

                await client.PutAsync("Table", contentTable);

                jsonContent = JsonConvert.SerializeObject(
                    new ServiceLineModel(service_id, TableId, WaiterId, ProductId, Quantity)
                );
                content = new StringContent(jsonContent, Encoding.UTF8, "application/json");

                await client.PostAsync("ServiceLine", content);
            }
            return Redirect($"OrderDetails/{table.Id}");
        }
    }
}
